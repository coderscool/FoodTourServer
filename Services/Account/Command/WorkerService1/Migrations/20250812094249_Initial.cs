using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkerService1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    AggregateId = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false),
                    AggregateType = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    EventType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Event = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => new { x.Version, x.AggregateId });
                });

            migrationBuilder.CreateTable(
                name: "Snapshots",
                columns: table => new
                {
                    Timestamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AggregateId = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: false),
                    AggregateType = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Aggregate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snapshots", x => x.Timestamp);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Snapshots");
        }
    }
}
