using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingPassManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "MeetingPasses");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "MeetingPasses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "MeetingPasses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "MeetingPasses",
                type: "datetime2",
                nullable: true);
        }
    }
}
