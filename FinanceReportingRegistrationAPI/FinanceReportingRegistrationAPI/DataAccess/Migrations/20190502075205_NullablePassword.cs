using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class NullablePassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                maxLength: 65,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 65);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                maxLength: 65,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 65,
                oldNullable: true);
        }
    }
}
