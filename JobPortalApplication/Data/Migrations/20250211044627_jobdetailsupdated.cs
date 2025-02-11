using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortalApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class jobdetailsupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Province",
                table: "JobDetails",
                newName: "VacancyNo");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "JobDetails",
                newName: "OtherSpecification");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "JobDetails",
                newName: "OfferedSalary");

            migrationBuilder.RenameColumn(
                name: "Municipality",
                table: "JobDetails",
                newName: "JobWorkDescription");

            migrationBuilder.RenameColumn(
                name: "District",
                table: "JobDetails",
                newName: "JobTitle");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "JobDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ComapnayId",
                table: "JobDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DeadLine",
                table: "JobDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EducationLevel",
                table: "JobDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ExperienceRequired",
                table: "JobDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobLevel",
                table: "JobDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobLocation",
                table: "JobDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "JobTypeId",
                table: "JobDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "JobDetails");

            migrationBuilder.DropColumn(
                name: "ComapnayId",
                table: "JobDetails");

            migrationBuilder.DropColumn(
                name: "DeadLine",
                table: "JobDetails");

            migrationBuilder.DropColumn(
                name: "EducationLevel",
                table: "JobDetails");

            migrationBuilder.DropColumn(
                name: "ExperienceRequired",
                table: "JobDetails");

            migrationBuilder.DropColumn(
                name: "JobLevel",
                table: "JobDetails");

            migrationBuilder.DropColumn(
                name: "JobLocation",
                table: "JobDetails");

            migrationBuilder.DropColumn(
                name: "JobTypeId",
                table: "JobDetails");

            migrationBuilder.RenameColumn(
                name: "VacancyNo",
                table: "JobDetails",
                newName: "Province");

            migrationBuilder.RenameColumn(
                name: "OtherSpecification",
                table: "JobDetails",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "OfferedSalary",
                table: "JobDetails",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "JobWorkDescription",
                table: "JobDetails",
                newName: "Municipality");

            migrationBuilder.RenameColumn(
                name: "JobTitle",
                table: "JobDetails",
                newName: "District");
        }
    }
}
