using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC.Migrations
{
    /// <inheritdoc />
    public partial class CreateExport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExportReceipt",
                columns: table => new
                {
                    ExportID = table.Column<string>(type: "TEXT", nullable: false),
                    ExportDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportReceipt", x => x.ExportID);
                });

            migrationBuilder.CreateTable(
                name: "ExportDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExportID = table.Column<string>(type: "TEXT", nullable: false),
                    DeviceID = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportDetail_Device_DeviceID",
                        column: x => x.DeviceID,
                        principalTable: "Device",
                        principalColumn: "DeviceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExportDetail_ExportReceipt_ExportID",
                        column: x => x.ExportID,
                        principalTable: "ExportReceipt",
                        principalColumn: "ExportID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetail_DeviceID",
                table: "ExportDetail",
                column: "DeviceID");

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetail_ExportID",
                table: "ExportDetail",
                column: "ExportID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExportDetail");

            migrationBuilder.DropTable(
                name: "ExportReceipt");
        }
    }
}
