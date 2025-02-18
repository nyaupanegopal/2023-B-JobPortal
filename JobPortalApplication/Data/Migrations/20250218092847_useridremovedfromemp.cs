using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPortalApplication.Data.Migrations
{
    /// <inheritdoc />
    public partial class useridremovedfromemp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "EmployerDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployerDetails_IdentityUserId",
                table: "EmployerDetails",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployerDetails_AspNetUsers_IdentityUserId",
                table: "EmployerDetails",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployerDetails_AspNetUsers_IdentityUserId",
                table: "EmployerDetails");

            migrationBuilder.DropIndex(
                name: "IX_EmployerDetails_IdentityUserId",
                table: "EmployerDetails");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "EmployerDetails");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "EmployerDetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
