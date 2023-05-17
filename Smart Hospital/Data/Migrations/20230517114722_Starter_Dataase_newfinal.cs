using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smart_Hospital.Data.Migrations
{
    public partial class Starter_Dataase_newfinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicalRecords_person_DoctorId",
                table: "medicalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_medicalRecords_person_PatientId",
                table: "medicalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_person_addresses_AddressId",
                table: "person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_person",
                table: "person");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "person");

            migrationBuilder.DropColumn(
                name: "Speciality",
                table: "person");

            migrationBuilder.RenameTable(
                name: "person",
                newName: "patients");

            migrationBuilder.RenameIndex(
                name: "IX_person_AddressId",
                table: "patients",
                newName: "IX_patients_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_patients",
                table: "patients",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_doctors_addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_doctors_AddressId",
                table: "doctors",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_medicalRecords_doctors_DoctorId",
                table: "medicalRecords",
                column: "DoctorId",
                principalTable: "doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medicalRecords_patients_PatientId",
                table: "medicalRecords",
                column: "PatientId",
                principalTable: "patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_addresses_AddressId",
                table: "patients",
                column: "AddressId",
                principalTable: "addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicalRecords_doctors_DoctorId",
                table: "medicalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_medicalRecords_patients_PatientId",
                table: "medicalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_patients_addresses_AddressId",
                table: "patients");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_patients",
                table: "patients");

            migrationBuilder.RenameTable(
                name: "patients",
                newName: "person");

            migrationBuilder.RenameIndex(
                name: "IX_patients_AddressId",
                table: "person",
                newName: "IX_person_AddressId");

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
                name: "PK_person",
                table: "person",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_medicalRecords_person_DoctorId",
                table: "medicalRecords",
                column: "DoctorId",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medicalRecords_person_PatientId",
                table: "medicalRecords",
                column: "PatientId",
                principalTable: "person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_person_addresses_AddressId",
                table: "person",
                column: "AddressId",
                principalTable: "addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
