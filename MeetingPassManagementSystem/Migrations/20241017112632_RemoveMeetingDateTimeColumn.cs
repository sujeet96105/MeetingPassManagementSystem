using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingPassManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMeetingDateTimeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeetingDateTime",
                table: "MeetingPass");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MeetingDateTime",
                table: "MeetingPass",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
