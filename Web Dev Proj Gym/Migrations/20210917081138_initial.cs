using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Dev_Proj_Gym.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumOfEmployees = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TrainingProgram",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramDuration = table.Column<int>(type: "int", nullable: false),
                    ProgramPurpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeightGoal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingProgram", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BranchEmployee",
                columns: table => new
                {
                    EmployeeBranchListID = table.Column<int>(type: "int", nullable: false),
                    EmployeeListID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchEmployee", x => new { x.EmployeeBranchListID, x.EmployeeListID });
                    table.ForeignKey(
                        name: "FK_BranchEmployee_Branch_EmployeeBranchListID",
                        column: x => x.EmployeeBranchListID,
                        principalTable: "Branch",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchEmployee_Employee_EmployeeListID",
                        column: x => x.EmployeeListID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lesson",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonDuration = table.Column<int>(type: "int", nullable: false),
                    CalorieBurn = table.Column<int>(type: "int", nullable: false),
                    MaxParticipants = table.Column<int>(type: "int", nullable: false),
                    LessonType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LessonTrainerID = table.Column<int>(type: "int", nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lesson_Branch_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branch",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lesson_Employee_LessonTrainerID",
                        column: x => x.LessonTrainerID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTrainings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChosenLessonID = table.Column<int>(type: "int", nullable: true),
                    Timing = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrainingLocationID = table.Column<int>(type: "int", nullable: true),
                    CustomerUserName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TrainingProgramID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTrainings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerTrainings_Branch_TrainingLocationID",
                        column: x => x.TrainingLocationID,
                        principalTable: "Branch",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerTrainings_Customer_CustomerUserName",
                        column: x => x.CustomerUserName,
                        principalTable: "Customer",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerTrainings_Lesson_ChosenLessonID",
                        column: x => x.ChosenLessonID,
                        principalTable: "Lesson",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerTrainings_TrainingProgram_TrainingProgramID",
                        column: x => x.TrainingProgramID,
                        principalTable: "TrainingProgram",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchEmployee_EmployeeListID",
                table: "BranchEmployee",
                column: "EmployeeListID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTrainings_ChosenLessonID",
                table: "CustomerTrainings",
                column: "ChosenLessonID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTrainings_CustomerUserName",
                table: "CustomerTrainings",
                column: "CustomerUserName");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTrainings_TrainingLocationID",
                table: "CustomerTrainings",
                column: "TrainingLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTrainings_TrainingProgramID",
                table: "CustomerTrainings",
                column: "TrainingProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_BranchID",
                table: "Lesson",
                column: "BranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_LessonTrainerID",
                table: "Lesson",
                column: "LessonTrainerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchEmployee");

            migrationBuilder.DropTable(
                name: "CustomerTrainings");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Lesson");

            migrationBuilder.DropTable(
                name: "TrainingProgram");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
