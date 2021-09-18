using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Dev_Proj_Gym.Migrations
{
    public partial class _189four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_BranchManager_ThisBranchsManagerID",
                table: "Branch");

            migrationBuilder.DropIndex(
                name: "IX_Branch_ThisBranchsManagerID",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "ThisBranchsManagerID",
                table: "Branch");

            migrationBuilder.AddColumn<int>(
                name: "BranchID",
                table: "BranchManager",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BranchManager_BranchID",
                table: "BranchManager",
                column: "BranchID");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchManager_Branch_BranchID",
                table: "BranchManager",
                column: "BranchID",
                principalTable: "Branch",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchManager_Branch_BranchID",
                table: "BranchManager");

            migrationBuilder.DropIndex(
                name: "IX_BranchManager_BranchID",
                table: "BranchManager");

            migrationBuilder.DropColumn(
                name: "BranchID",
                table: "BranchManager");

            migrationBuilder.AddColumn<int>(
                name: "ThisBranchsManagerID",
                table: "Branch",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branch_ThisBranchsManagerID",
                table: "Branch",
                column: "ThisBranchsManagerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Branch_BranchManager_ThisBranchsManagerID",
                table: "Branch",
                column: "ThisBranchsManagerID",
                principalTable: "BranchManager",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
