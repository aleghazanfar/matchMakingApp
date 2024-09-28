using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RishtaWebApp.Migrations
{
    public partial class UPdateMemberTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MotherOccupationId",
                table: "MemberDetails",
                newName: "ReqHeight");

            migrationBuilder.RenameColumn(
                name: "FatherOccupationId",
                table: "MemberDetails",
                newName: "GenderId");

            migrationBuilder.AddColumn<string>(
                name: "FatherOccupation",
                table: "MemberDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherOccupation",
                table: "MemberDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherProperties",
                table: "MemberDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCaste",
                table: "MemberDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FatherOccupation",
                table: "MemberDetails");

            migrationBuilder.DropColumn(
                name: "MotherOccupation",
                table: "MemberDetails");

            migrationBuilder.DropColumn(
                name: "OtherProperties",
                table: "MemberDetails");

            migrationBuilder.DropColumn(
                name: "SubCaste",
                table: "MemberDetails");

            migrationBuilder.RenameColumn(
                name: "ReqHeight",
                table: "MemberDetails",
                newName: "MotherOccupationId");

            migrationBuilder.RenameColumn(
                name: "GenderId",
                table: "MemberDetails",
                newName: "FatherOccupationId");
        }
    }
}
