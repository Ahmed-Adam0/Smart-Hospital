using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_Hospital.Data.Migrations
{
    public partial class Starter_Dataase_new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_Address_AddressId",
                table: "person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "addresses");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Speciality",
                table: "person",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_addresses",
                table: "addresses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "medicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    admssiondate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dischargedate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicalRecords_person_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicalRecords_person_PatientId",
                        column: x => x.PatientId,
                        principalTable: "person",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_medicalRecords_DoctorId",
                table: "medicalRecords",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_medicalRecords_PatientId",
                table: "medicalRecords",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_person_addresses_AddressId",
                table: "person",
                column: "AddressId",
                principalTable: "addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_addresses_AddressId",
                table: "person");

            migrationBuilder.DropTable(
                name: "medicalRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_addresses",
                table: "addresses");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "person");

            migrationBuilder.DropColumn(
                name: "Speciality",
                table: "person");

            migrationBuilder.RenameTable(
                name: "addresses",
                newName: "Address");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_person_Address_AddressId",
                table: "person",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
