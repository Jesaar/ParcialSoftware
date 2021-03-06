using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParcialSoftware.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entrances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Document = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WasUsed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketsEntrance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    EntranceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketsEntrance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketsEntrance_Entrances_EntranceId",
                        column: x => x.EntranceId,
                        principalTable: "Entrances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketsEntrance_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrances_Id_Description",
                table: "Entrances",
                columns: new[] { "Id", "Description" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Id",
                table: "Tickets",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketsEntrance_EntranceId",
                table: "TicketsEntrance",
                column: "EntranceId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsEntrance_TicketId_EntranceId",
                table: "TicketsEntrance",
                columns: new[] { "TicketId", "EntranceId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketsEntrance");

            migrationBuilder.DropTable(
                name: "Entrances");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
