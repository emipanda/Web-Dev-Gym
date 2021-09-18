using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Dev_Proj_Gym.Migrations
{
    public partial class _180three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropColumn(
                name: "Manager",
                table: "Branch");

            migrationBuilder.AddColumn<int>(
                name: "CustomersBranchID",
                table: "Customer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThisBranchsManagerID",
                table: "Branch",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BranchManager",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BMUserName = table.Column<int>(type: "int", nullable: false),
                    BMPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BMName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchManager", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SuperAdmin",
                columns: table => new
                {
                    SMUserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SMpassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperAdmin", x => x.SMUserName);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_CustomersBranchID",
                table: "Customer",
                column: "CustomersBranchID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Branch_CustomersBranchID",
                table: "Customer",
                column: "CustomersBranchID",
                principalTable: "Branch",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branch_BranchManager_ThisBranchsManagerID",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Branch_CustomersBranchID",
                table: "Customer");

            migrationBuilder.DropTable(
                name: "BranchManager");

            migrationBuilder.DropTable(
                name: "SuperAdmin");

            migrationBuilder.DropIndex(
                name: "IX_Customer_CustomersBranchID",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Branch_ThisBranchsManagerID",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "CustomersBranchID",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ThisBranchsManagerID",
                table: "Branch");

            migrationBuilder.AddColumn<string>(
                name: "Manager",
                table: "Branch",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminUserName = table.Column<int>(type: "int", nullable: false),
                    ManagersBranchID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Admin_Branch_ManagersBranchID",
                        column: x => x.ManagersBranchID,
                        principalTable: "Branch",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_ManagersBranchID",
                table: "Admin",
                column: "ManagersBranchID");
        }
    }
}
