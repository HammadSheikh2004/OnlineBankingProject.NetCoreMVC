using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBankingSystem.Migrations.MyDb
{
    public partial class Migration8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Account_User_State",
                table: "BankAccounts",
                newName: "Account_User_Phone_Number");

            migrationBuilder.AddColumn<string>(
                name: "Account_User_Country",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Account_User_Country",
                table: "BankAccounts");

            migrationBuilder.RenameColumn(
                name: "Account_User_Phone_Number",
                table: "BankAccounts",
                newName: "Account_User_State");
        }
    }
}
