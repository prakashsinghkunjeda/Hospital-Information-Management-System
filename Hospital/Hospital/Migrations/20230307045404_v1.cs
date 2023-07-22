using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Doctors",
               columns: table => new
               {
                   DoctorId = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Specialist = table.Column<string>(type: "nvarchar(max)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Doctors", x => x.DoctorId);
               });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
