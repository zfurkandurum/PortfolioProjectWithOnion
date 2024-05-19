using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionProtfolioProject.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "WhoAmIs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "WhoAmIs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "WhoAmIs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "WhoAmIs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "WhoAmIs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "WhoAmIs",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "WhoAmIs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "WhoAmIs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "WhoAmIs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "WhoAmIs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "WhoAmIs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "WhoAmIs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "WhoAmIs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "WhoAmIs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "WhoAmIs");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "WhoAmIs");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "WhoAmIs");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "WhoAmIs");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "WhoAmIs");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "WhoAmIs");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "WhoAmIs");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "WhoAmIs");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "WhoAmIs");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "WhoAmIs");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "WhoAmIs");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "WhoAmIs");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "WhoAmIs");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "WhoAmIs");
        }
    }
}
