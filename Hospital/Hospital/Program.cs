using Hospital.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
//all the services are kept here 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<HospitalDbContext>(option =>
{   
    option.UseSqlServer(builder.Configuration.GetConnectionString("DbString"));
});

// cros policy 

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("https://localhost:7241", "http://localhost:4200") //cross platform frontend and backend
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});
builder.Services.AddAuthentication(O =>
{
    O.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    O.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    O.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    O.RequireAuthenticatedSignIn = false;
}).AddJwtBearer(Options =>
{
    Options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        ValidAudience = builder.Configuration["JWT:ValidAudience"]
    };
});

builder.Services.AddControllers()
     .AddJsonOptions(options =>     // it wont allow to change PascalCasing  to camelCasing while sending data from client to server
     options.JsonSerializerOptions.PropertyNamingPolicy=null);//since we are using PascalCasing
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowOrigin");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
