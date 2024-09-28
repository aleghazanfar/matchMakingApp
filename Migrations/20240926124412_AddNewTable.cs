using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RishtaWebApp.Migrations
{
    public partial class AddNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonDetails");

            migrationBuilder.CreateTable(
                name: "MemberDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RegistrationNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parantage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    MotherLanguageId = table.Column<int>(type: "int", nullable: false),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BodyTypeId = table.Column<int>(type: "int", nullable: false),
                    ComplexId = table.Column<int>(type: "int", nullable: false),
                    QualificationId = table.Column<int>(type: "int", nullable: false),
                    CasteId = table.Column<int>(type: "int", nullable: false),
                    SectId = table.Column<int>(type: "int", nullable: false),
                    JobPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonthlyIncome = table.Column<int>(type: "int", nullable: false),
                    NatureOfJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuturePlans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherOccupationId = table.Column<int>(type: "int", nullable: false),
                    MotherOccupationId = table.Column<int>(type: "int", nullable: false),
                    Brothers = table.Column<int>(type: "int", nullable: false),
                    Sisters = table.Column<int>(type: "int", nullable: false),
                    DependsSibling = table.Column<int>(type: "int", nullable: false),
                    BrSisMarried = table.Column<int>(type: "int", nullable: false),
                    KidsDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeDistricts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Residence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ReqCasteId = table.Column<int>(type: "int", nullable: false),
                    ReqSectId = table.Column<int>(type: "int", nullable: false),
                    ReqMaritalStatusId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReqNationalityId = table.Column<int>(type: "int", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReqQualificationId = table.Column<int>(type: "int", nullable: false),
                    Income = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberDetails");

            migrationBuilder.CreateTable(
                name: "PersonDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BodyTypeId = table.Column<int>(type: "int", nullable: false),
                    BrSisMarried = table.Column<int>(type: "int", nullable: false),
                    Brothers = table.Column<int>(type: "int", nullable: false),
                    CasteId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplexId = table.Column<int>(type: "int", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DependsSibling = table.Column<int>(type: "int", nullable: false),
                    FatherOccupationId = table.Column<int>(type: "int", nullable: false),
                    FuturePlans = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HomeDistricts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    Income = table.Column<int>(type: "int", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobPosition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KidsDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: false),
                    MonthlyIncome = table.Column<int>(type: "int", nullable: false),
                    MotherLanguageId = table.Column<int>(type: "int", nullable: false),
                    MotherOccupationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalityId = table.Column<int>(type: "int", nullable: false),
                    NatureOfJob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parantage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualificationId = table.Column<int>(type: "int", nullable: false),
                    ReqCasteId = table.Column<int>(type: "int", nullable: false),
                    ReqMaritalStatusId = table.Column<int>(type: "int", nullable: false),
                    ReqNationalityId = table.Column<int>(type: "int", nullable: false),
                    ReqQualificationId = table.Column<int>(type: "int", nullable: false),
                    ReqSectId = table.Column<int>(type: "int", nullable: false),
                    Residence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SectId = table.Column<int>(type: "int", nullable: false),
                    Sisters = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDetails", x => x.Id);
                });
        }
    }
}
