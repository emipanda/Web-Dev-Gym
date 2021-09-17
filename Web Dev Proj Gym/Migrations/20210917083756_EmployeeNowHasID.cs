using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Dev_Proj_Gym.Migrations
{
    public partial class EmployeeNowHasID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateID",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StateID",
                table: "Employee");
        }
    }
}
