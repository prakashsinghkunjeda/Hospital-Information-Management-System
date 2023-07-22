using Hospital.DAL;
using Hospital.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public HospitalDbContext db;
        public readonly IConfiguration _config; 
        public AuthenticationController(HospitalDbContext _db, IConfiguration config)
        {
            this.db = _db;
            _config = config;
        }

        // GET: api/<AuthenticationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthenticationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthenticationController>
 
     [Route("Login")]
    // POST api/<AunthenticationController>
     [HttpPost]
      public IActionResult Login([FromBody] UserCredential loginRequest)
      {
          var userCredential = db.UserCredentials.FirstOrDefault();
            var userName = userCredential.Username;
            var password = userCredential.Password;
            if (loginRequest.Username == userName && loginRequest.Password == password)
            {
                var authClaims = new List<System.Security.Claims.Claim>
                {
                    new Claim (ClaimTypes.Name, userName),
                    new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                var authSignKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
                var token = new JwtSecurityToken(
                    issuer: _config["JWT:ValidIssuer"],
                    audience: _config["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSignKey, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();

        }
      [Route("Register")]
      // POST api/<AunthenticationController>
      [HttpPost]
       public IActionResult Register([FromBody] UserCredential userCredential)
      {
          UserCredential obj = new UserCredential();
          obj.Username = userCredential.Username;
          obj.Password = userCredential.Password;
          db.Add(obj);
          db.SaveChanges();
          return Ok();

      }
    // PUT api/<AuthenticationController>/5
     [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthenticationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
