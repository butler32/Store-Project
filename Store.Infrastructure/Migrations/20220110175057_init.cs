using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Discont = table.Column<int>(type: "int", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    Developer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsSupport = table.Column<bool>(type: "bit", nullable: false),
                    IsDeveloper = table.Column<bool>(type: "bit", nullable: false),
                    IsModerator = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupportCases",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SupportId = table.Column<int>(type: "int", nullable: false),
                    MessageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportCases", x => new { x.UserId, x.SupportId, x.MessageId });
                });

            migrationBuilder.CreateTable(
                name: "SupportMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SupportCaseUserId = table.Column<int>(type: "int", nullable: false),
                    SupportCaseSupportId = table.Column<int>(type: "int", nullable: false),
                    SupportCaseMessageId = table.Column<int>(type: "int", nullable: false),
                    SupportCaseId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportMessages_SupportCases_SupportCaseUserId_SupportCaseSupportId_SupportCaseMessageId",
                        columns: x => new { x.SupportCaseUserId, x.SupportCaseSupportId, x.SupportCaseMessageId },
                        principalTable: "SupportCases",
                        principalColumns: new[] { "UserId", "SupportId", "MessageId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nchar(128)", fixedLength: true, maxLength: 128, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupportCaseMessageId = table.Column<int>(type: "int", nullable: true),
                    SupportCaseMessageId1 = table.Column<int>(type: "int", nullable: true),
                    SupportCaseSupportId = table.Column<int>(type: "int", nullable: true),
                    SupportCaseSupportId1 = table.Column<int>(type: "int", nullable: true),
                    SupportCaseUserId = table.Column<int>(type: "int", nullable: true),
                    SupportCaseUserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_SupportCases_SupportCaseUserId_SupportCaseSupportId_SupportCaseMessageId",
                        columns: x => new { x.SupportCaseUserId, x.SupportCaseSupportId, x.SupportCaseMessageId },
                        principalTable: "SupportCases",
                        principalColumns: new[] { "UserId", "SupportId", "MessageId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_SupportCases_SupportCaseUserId1_SupportCaseSupportId1_SupportCaseMessageId1",
                        columns: x => new { x.SupportCaseUserId1, x.SupportCaseSupportId1, x.SupportCaseMessageId1 },
                        principalTable: "SupportCases",
                        principalColumns: new[] { "UserId", "SupportId", "MessageId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    FirstUserId = table.Column<int>(type: "int", nullable: false),
                    SecondUserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => new { x.FirstUserId, x.SecondUserId, x.Status });
                    table.ForeignKey(
                        name: "FK_Friends_Users_FirstUserId",
                        column: x => x.FirstUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Friends_Users_SecondUserId",
                        column: x => x.SecondUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameUser",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameUser", x => new { x.GamesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_GameUser_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_SecondUserId",
                table: "Friends",
                column: "SecondUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GameUser_UsersId",
                table: "GameUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportMessages_SupportCaseUserId_SupportCaseSupportId_SupportCaseMessageId",
                table: "SupportMessages",
                columns: new[] { "SupportCaseUserId", "SupportCaseSupportId", "SupportCaseMessageId" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SupportCaseUserId_SupportCaseSupportId_SupportCaseMessageId",
                table: "Users",
                columns: new[] { "SupportCaseUserId", "SupportCaseSupportId", "SupportCaseMessageId" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SupportCaseUserId1_SupportCaseSupportId1_SupportCaseMessageId1",
                table: "Users",
                columns: new[] { "SupportCaseUserId1", "SupportCaseSupportId1", "SupportCaseMessageId1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "GameUser");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "SupportMessages");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SupportCases");
        }
    }
}
