using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingPassManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMeetingPassTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MeetingPasses",
                table: "MeetingPasses");

            migrationBuilder.RenameTable(
                name: "MeetingPasses",
                newName: "MeetingPass");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MeetingPass",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "MeetingDateTime",
                table: "MeetingPass",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PassCount",
                table: "MeetingPass",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeetingPass",
                table: "MeetingPass",
                column: "PassID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MeetingPass",
                table: "MeetingPass");

            migrationBuilder.DropColumn(
                name: "MeetingDateTime",
                table: "MeetingPass");

            migrationBuilder.DropColumn(
                name: "PassCount",
                table: "MeetingPass");

            migrationBuilder.RenameTable(
                name: "MeetingPass",
                newName: "MeetingPasses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "MeetingPasses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeetingPasses",
                table: "MeetingPasses",
                column: "PassID");
        }
    }
}
