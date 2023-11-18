using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBankingSystem.Migrations.MyDb
{
    public partial class Migration19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BankAccounts_BankAccountAccount_User_Id",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_BankAccountAccount_User_Id",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BankAccountAccount_User_Id",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "ToAccountId",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FromAccountId",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ToAccountId",
                table: "Transactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "FromAccountId",
                table: "Transactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "BankAccountAccount_User_Id",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BankAccountAccount_User_Id",
                table: "Transactions",
                column: "BankAccountAccount_User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BankAccounts_BankAccountAccount_User_Id",
                table: "Transactions",
                column: "BankAccountAccount_User_Id",
                principalTable: "BankAccounts",
                principalColumn: "Account_User_Id");
        }
    }
}
