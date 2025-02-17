using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortalApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class fkadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_JobDetails_CategoryId",
                table: "JobDetails",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobDetails_ComapnayId",
                table: "JobDetails",
                column: "ComapnayId");

            migrationBuilder.CreateIndex(
                name: "IX_JobDetails_JobTypeId",
                table: "JobDetails",
                column: "JobTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobDetails_EmployerDetails_ComapnayId",
                table: "JobDetails",
                column: "ComapnayId",
                principalTable: "EmployerDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobDetails_JobCategory_CategoryId",
                table: "JobDetails",
                column: "CategoryId",
                principalTable: "JobCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobDetails_JobType_JobTypeId",
                table: "JobDetails",
                column: "JobTypeId",
                principalTable: "JobType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobDetails_EmployerDetails_ComapnayId",
                table: "JobDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_JobDetails_JobCategory_CategoryId",
                table: "JobDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_JobDetails_JobType_JobTypeId",
                table: "JobDetails");

            migrationBuilder.DropIndex(
                name: "IX_JobDetails_CategoryId",
                table: "JobDetails");

            migrationBuilder.DropIndex(
                name: "IX_JobDetails_ComapnayId",
                table: "JobDetails");

            migrationBuilder.DropIndex(
                name: "IX_JobDetails_JobTypeId",
                table: "JobDetails");
        }
    }
}
