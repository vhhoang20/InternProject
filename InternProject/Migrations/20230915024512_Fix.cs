using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternProject.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_department_id",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Jobs_job_id",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_department_id",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_job_id",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employees_department_id",
                table: "Employees",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_job_id",
                table: "Employees",
                column: "job_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_department_id",
                table: "Employees",
                column: "department_id",
                principalTable: "Departments",
                principalColumn: "department_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Jobs_job_id",
                table: "Employees",
                column: "job_id",
                principalTable: "Jobs",
                principalColumn: "job_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
