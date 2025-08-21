using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Infrastructure.Migrations;

/// <inheritdoc />
public partial class InitialMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Property",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Property", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Reservations",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                PropertyId = table.Column<int>(type: "int", nullable: false),
                RoomTypeId = table.Column<int>(type: "int", nullable: false),
                ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                ArrivalTime = table.Column<TimeSpan>(type: "time", nullable: false),
                DepartureTime = table.Column<TimeSpan>(type: "time", nullable: false),
                PersonCount = table.Column<int>(type: "int", nullable: false),
                GuestName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                GuestPhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Reservations", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "RoomTypes",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                PropertyId = table.Column<int>(type: "int", nullable: false),
                Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                DailyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, defaultValue: "USD"),
                MinPersonCount = table.Column<int>(type: "int", nullable: false),
                MaxPersonCount = table.Column<int>(type: "int", nullable: false),
                Services = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Amenities = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_RoomTypes", x => x.Id);
                table.ForeignKey(
                    name: "FK_RoomTypes_Property_PropertyId",
                    column: x => x.PropertyId,
                    principalTable: "Property",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Property_City",
            table: "Property",
            column: "City");

        migrationBuilder.CreateIndex(
            name: "IX_Property_Country",
            table: "Property",
            column: "Country");

        migrationBuilder.CreateIndex(
            name: "IX_RoomTypes_DailyPrice",
            table: "RoomTypes",
            column: "DailyPrice");

        migrationBuilder.CreateIndex(
            name: "IX_RoomTypes_PropertyId",
            table: "RoomTypes",
            column: "PropertyId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Reservations");

        migrationBuilder.DropTable(
            name: "RoomTypes");

        migrationBuilder.DropTable(
            name: "Property");
    }
}
