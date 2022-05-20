using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Netpower.Intern2022.Responsitories.Migrations
{
    public partial class demo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_DEPARTMENT",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DEPARTMENT", x => x.ID);
                    table.UniqueConstraint("AK_TB_DEPARTMENT_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "TB_USER",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FK_profile = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USER", x => x.ID);
                    table.UniqueConstraint("AK_TB_USER_Mail", x => x.Mail);
                    table.UniqueConstraint("AK_TB_USER_UserName", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "TB_POSITION",
                columns: table => new
                {
                    ID_Position = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FK_Department = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_POSITION", x => x.ID_Position);
                    table.UniqueConstraint("AK_TB_POSITION_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_TB_POSITION_TB_DEPARTMENT_FK_Department",
                        column: x => x.FK_Department,
                        principalTable: "TB_DEPARTMENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_PROFILE",
                columns: table => new
                {
                    FK_User = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_Role = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROFILE", x => x.FK_User);
                    table.ForeignKey(
                        name: "FK_TB_PROFILE_TB_POSITION_FK_Role",
                        column: x => x.FK_Role,
                        principalTable: "TB_POSITION",
                        principalColumn: "ID_Position",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PROFILE_TB_USER_FK_User",
                        column: x => x.FK_User,
                        principalTable: "TB_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_POSITION_FK_Department",
                table: "TB_POSITION",
                column: "FK_Department");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PROFILE_FK_Role",
                table: "TB_PROFILE",
                column: "FK_Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PROFILE");

            migrationBuilder.DropTable(
                name: "TB_POSITION");

            migrationBuilder.DropTable(
                name: "TB_USER");

            migrationBuilder.DropTable(
                name: "TB_DEPARTMENT");
        }
    }
}
