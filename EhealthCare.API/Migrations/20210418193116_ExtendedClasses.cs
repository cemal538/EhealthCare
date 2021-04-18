using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EhealthCare.API.Migrations
{
    public partial class ExtendedClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Patient",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActive",
                table: "Patient",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Phonenumber",
                table: "Patient",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Doctor",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActive",
                table: "Doctor",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Phonenumber",
                table: "Doctor",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TypeofDoctor",
                table: "Doctor",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "LastActive",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Phonenumber",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "LastActive",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "Phonenumber",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "TypeofDoctor",
                table: "Doctor");
        }
    }
}
