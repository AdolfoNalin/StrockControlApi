using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockControlApi.Migrations
{
    /// <inheritdoc />
    public partial class Create_Brand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brand",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Brand",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Brand",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Brand",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Brand",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Brand",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Brand_UserId",
                table: "Brand",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brand_User_UserId",
                table: "Brand",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brand_User_UserId",
                table: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Brand_UserId",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Brand");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brand",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);
        }
    }
}
