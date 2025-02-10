using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBookIssuer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "bookIssuers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "bookIssuers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "bookIssuers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "bookIssuers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "bookIssuers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "bookIssuers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "bookIssuers");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "bookIssuers");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "bookIssuers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "bookIssuers");
        }
    }
}
