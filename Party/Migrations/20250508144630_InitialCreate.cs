using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Party.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "party_request",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Applicant = table.Column<string>(type: "TEXT", nullable: false),
                    ApplicantPN = table.Column<string>(type: "TEXT", nullable: false),
                    BirthdayPerson = table.Column<string>(type: "TEXT", nullable: false),
                    BirthdayPersonAge = table.Column<int>(type: "INTEGER", nullable: false),
                    Birthday = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Partydate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Baloons = table.Column<int>(type: "INTEGER", nullable: false),
                    BaloonsWithHelium = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_party_request", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_party_request_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuestAge = table.Column<int>(type: "INTEGER", nullable: false),
                    GuestName = table.Column<string>(type: "TEXT", nullable: false),
                    PartyRequestRequestId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guests_party_request_PartyRequestRequestId",
                        column: x => x.PartyRequestRequestId,
                        principalTable: "party_request",
                        principalColumn: "RequestId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guests_PartyRequestRequestId",
                table: "Guests",
                column: "PartyRequestRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_party_request_OrderId",
                table: "party_request",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "party_request");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
