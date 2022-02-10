using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Infrastructure.Migrations
{
    public partial class support : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupportCases_Users_SupportId",
                table: "SupportCases");

            migrationBuilder.DropIndex(
                name: "IX_SupportCases_SupportId",
                table: "SupportCases");

            migrationBuilder.DropColumn(
                name: "SupportId",
                table: "SupportCases");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "SupportCases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupportCases_UserId",
                table: "SupportCases",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SupportCases_Users_UserId",
                table: "SupportCases",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupportCases_Users_UserId",
                table: "SupportCases");

            migrationBuilder.DropIndex(
                name: "IX_SupportCases_UserId",
                table: "SupportCases");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SupportCases");

            migrationBuilder.AddColumn<int>(
                name: "SupportId",
                table: "SupportCases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SupportCases_SupportId",
                table: "SupportCases",
                column: "SupportId");

            migrationBuilder.AddForeignKey(
                name: "FK_SupportCases_Users_SupportId",
                table: "SupportCases",
                column: "SupportId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
