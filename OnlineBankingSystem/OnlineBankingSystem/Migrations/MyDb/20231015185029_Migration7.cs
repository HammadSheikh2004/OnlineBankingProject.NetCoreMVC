using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBankingSystem.Migrations.MyDb
{
    public partial class Migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Account_User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account_User_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_User_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_User_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_User_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_User_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Account_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_CNIC = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Account_User_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccounts");
        }
    }
}
