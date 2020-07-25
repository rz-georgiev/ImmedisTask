using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmedisTask.Data.Migrations
{
    public partial class LineManagerNowNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_LineManagerEmployeeId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "LineManagerEmployeeId",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_LineManagerEmployeeId",
                table: "Employees",
                column: "LineManagerEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_LineManagerEmployeeId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "LineManagerEmployeeId",
                table: "Employees",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_LineManagerEmployeeId",
                table: "Employees",
                column: "LineManagerEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
