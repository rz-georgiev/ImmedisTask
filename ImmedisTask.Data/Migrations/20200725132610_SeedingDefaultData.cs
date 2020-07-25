using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ImmedisTask.Data.Migrations
{
    public partial class SeedingDefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_LineManagerEmployeeId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_LineManagerEmployeeId",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address", "Amount", "CreatedDateTime", "DateJoinedCompany", "Department", "FirstName", "IsActive", "IsMonthly", "JobTitle", "LastName", "LastUpdatedDateTime", "LineManagerEmployeeId" },
                values: new object[,]
                {
                    { 9, "Sofia", 1300.00m, new DateTime(2020, 7, 25, 16, 16, 13, 561, DateTimeKind.Unspecified).AddTicks(2570), new DateTime(2020, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "HR", "Tom", true, true, "HR specialist", "Hanks", new DateTime(2020, 7, 25, 16, 17, 57, 337, DateTimeKind.Unspecified).AddTicks(1830), 8 },
                    { 8, "Varna", 1200.00m, new DateTime(2020, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", "Nicolas", true, false, "Developer", "Cage", new DateTime(2020, 7, 25, 16, 18, 28, 505, DateTimeKind.Unspecified).AddTicks(2170), 9 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Author", "CommentContent", "CreatedDateTime", "EmployeeId", "IsActive", "LastUpdatedDateTime" },
                values: new object[,]
                {
                    { 6, "Jennifer Aniston", "Achievement #1 unlocked", new DateTime(2020, 7, 25, 16, 16, 55, 353, DateTimeKind.Unspecified).AddTicks(80), 9, true, new DateTime(2020, 7, 25, 16, 19, 23, 873, DateTimeKind.Unspecified).AddTicks(3560) },
                    { 7, "Tom Cruise", "Achievement #2 unlocked", new DateTime(2020, 7, 25, 16, 19, 39, 235, DateTimeKind.Unspecified).AddTicks(5800), 9, true, new DateTime(2020, 7, 25, 16, 19, 46, 839, DateTimeKind.Unspecified).AddTicks(4990) },
                    { 5, "John Travolta", "Achievement #3 unlocked", new DateTime(2020, 7, 25, 16, 15, 9, 382, DateTimeKind.Unspecified).AddTicks(5260), 8, true, new DateTime(2020, 7, 25, 16, 20, 12, 24, DateTimeKind.Unspecified).AddTicks(1870) },
                    { 4, "Meg Ryen", "Achievement #4 unlocked", new DateTime(2020, 7, 25, 15, 19, 10, 847, DateTimeKind.Unspecified).AddTicks(9050), 8, true, new DateTime(2020, 7, 25, 16, 20, 39, 95, DateTimeKind.Unspecified).AddTicks(3540) },
                    { 8, "Louis de Funes", "Achievement #5 unlocked", new DateTime(2020, 7, 25, 16, 21, 7, 573, DateTimeKind.Unspecified).AddTicks(8040), 8, true, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LineManagerEmployeeId",
                table: "Employees",
                column: "LineManagerEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_LineManagerEmployeeId",
                table: "Employees",
                column: "LineManagerEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
