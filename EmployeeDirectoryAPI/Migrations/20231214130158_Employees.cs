using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeDirectoryAPI.Migrations
{
    public partial class Employees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "Department", "FirstName", "JobTitle", "LastName", "Location" },
                values: new object[,]
                {
                    { 1, "IT", "Anthony", "SharePoint Practice Head", "Morris", "Seattle" },
                    { 2, "IT", "Helen", "Operations Manager", "Zimmerman", "Seattle" },
                    { 3, "IT", "Joanthon", "Product Manager", "Smith", "Seattle" },
                    { 4, "IT", "Tami", "Lead Engineer", "Hopkins", "Seattle" },
                    { 5, "IT", "Franklin", "Network Engineer", "Humark", "Seattle" },
                    { 6, "HR", "Angela", "Talent Manager", "Bailey", "Seattle" },
                    { 7, "IT", "Robert", "Software Engineer", "Mitchell", "Seattle" },
                    { 8, "UX", "Olivia", "UI Designer", "Watson", "India" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
