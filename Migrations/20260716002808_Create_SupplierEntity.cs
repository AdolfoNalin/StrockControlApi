using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockControlApi.Migrations
{
    /// <inheritdoc />
    public partial class Create_SupplierEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Supplier",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CellPhone",
                table: "Supplier",
                type: "character varying(18)",
                maxLength: 18,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cnpj",
                table: "Supplier",
                type: "character varying(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Supplier",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Supplier",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Supplier",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Supplier",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observation",
                table: "Supplier",
                type: "character varying(400)",
                maxLength: 400,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Supplier",
                type: "character varying(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateRegistration",
                table: "Supplier",
                type: "character varying(14)",
                maxLength: 14,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrandName",
                table: "Supplier",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Supplier",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Supplier",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Cnpj",
                table: "Supplier",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_UserId",
                table: "Supplier",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_User_UserId",
                table: "Supplier",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_User_UserId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_Cnpj",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_UserId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CellPhone",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Cnpj",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Observation",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "StateRegistration",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "TrandName",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Supplier");
        }
    }
}
