using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortalApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class fkaddedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "EmployerDetails",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_EmployerDetails_UserId",
                table: "EmployerDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployerDetails_AspNetUsers_UserId",
                table: "EmployerDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployerDetails_AspNetUsers_UserId",
                table: "EmployerDetails");

            migrationBuilder.DropIndex(
                name: "IX_EmployerDetails_UserId",
                table: "EmployerDetails");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "EmployerDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
