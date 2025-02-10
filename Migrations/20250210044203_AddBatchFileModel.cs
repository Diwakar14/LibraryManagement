using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddBatchFileModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookIssuers_Books_BookId",
                table: "bookIssuers");

            migrationBuilder.DropForeignKey(
                name: "FK_bookIssuers_Issuers_IssuerId",
                table: "bookIssuers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookIssuers",
                table: "bookIssuers");

            migrationBuilder.RenameTable(
                name: "bookIssuers",
                newName: "BookIssuers");

            migrationBuilder.RenameIndex(
                name: "IX_bookIssuers_IssuerId",
                table: "BookIssuers",
                newName: "IX_BookIssuers_IssuerId");

            migrationBuilder.RenameIndex(
                name: "IX_bookIssuers_BookId",
                table: "BookIssuers",
                newName: "IX_BookIssuers_BookId");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Issuers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MembershipType",
                table: "Issuers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MembershipExpireDate",
                table: "Issuers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "IsMembershipActive",
                table: "Issuers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Issuers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookIssuers",
                table: "BookIssuers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BatchFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BookIssuers_Books_BookId",
                table: "BookIssuers",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookIssuers_Issuers_IssuerId",
                table: "BookIssuers",
                column: "IssuerId",
                principalTable: "Issuers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookIssuers_Books_BookId",
                table: "BookIssuers");

            migrationBuilder.DropForeignKey(
                name: "FK_BookIssuers_Issuers_IssuerId",
                table: "BookIssuers");

            migrationBuilder.DropTable(
                name: "BatchFiles");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookIssuers",
                table: "BookIssuers");

            migrationBuilder.RenameTable(
                name: "BookIssuers",
                newName: "bookIssuers");

            migrationBuilder.RenameIndex(
                name: "IX_BookIssuers_IssuerId",
                table: "bookIssuers",
                newName: "IX_bookIssuers_IssuerId");

            migrationBuilder.RenameIndex(
                name: "IX_BookIssuers_BookId",
                table: "bookIssuers",
                newName: "IX_bookIssuers_BookId");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Issuers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MembershipType",
                table: "Issuers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MembershipExpireDate",
                table: "Issuers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IsMembershipActive",
                table: "Issuers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Issuers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookIssuers",
                table: "bookIssuers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bookIssuers_Books_BookId",
                table: "bookIssuers",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookIssuers_Issuers_IssuerId",
                table: "bookIssuers",
                column: "IssuerId",
                principalTable: "Issuers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
