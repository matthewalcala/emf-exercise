using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Emf.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    DepartmentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<string>(maxLength: 10, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false),
                    Address1 = table.Column<string>(maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    State = table.Column<string>(maxLength: 2, nullable: false),
                    Zipcode = table.Column<string>(maxLength: 10, nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentType", "Description", "Name" },
                values: new object[] { 1, 1, "Internal Web App Division", "IT Web Internal" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentType", "Description", "Name" },
                values: new object[] { 2, 1, "Sitecore Web Development Division", "Sitecore Web Dev" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentType", "Description", "Name" },
                values: new object[] { 3, 2, "News division", "News" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Address1", "Address2", "City", "DepartmentId", "Email", "FirstName", "LastName", "Phone", "State", "Zipcode" },
                values: new object[,]
                {
                    { 1, "1000 Main Street", "", "Lincoln", 1, "mattalcala@gmail.com", "Mateo", "Alcala", "1234567890", "CA", "95648" },
                    { 4, "1000 Main Street", "", "Lincoln", 1, "mattalcala@gmail.com", "John", "Rapid", "1234567890", "CA", "95648" },
                    { 7, "1000 Main Street", "", "Lincoln", 1, "mattalcala@gmail.com", "Bob", "Bee", "1234567890", "CA", "95648" },
                    { 10, "1000 Main Street", "", "Lincoln", 1, "mattalcala@gmail.com", "Steve", "Gates", "1234567890", "CA", "95648" },
                    { 2, "1000 Blues St", "", "Folsom", 2, "jc@gmail.com", "Johnny", "Cash", "1234567890", "CA", "95887" },
                    { 3, "1000 Blues St", "", "Folsom", 2, "jc@gmail.com", "George", "Lucas", "1234567890", "CA", "95887" },
                    { 5, "1000 Blues St", "", "Folsom", 2, "jc@gmail.com", "Max", "Power", "1234567890", "CA", "95887" },
                    { 6, "1000 Blues St", "", "Folsom", 2, "jc@gmail.com", "Kid", "Man", "1234567890", "CA", "95887" },
                    { 8, "1000 Blues St", "", "Folsom", 2, "jc@gmail.com", "Koda", "Tuko", "1234567890", "CA", "95887" },
                    { 9, "1000 Blues St", "", "Folsom", 3, "jc@gmail.com", "Luke", "Skywalker", "1234567890", "CA", "95887" },
                    { 11, "1000 Blues St", "", "Folsom", 3, "jc@gmail.com", "Billy", "Jobs", "1234567890", "CA", "95887" },
                    { 12, "1000 Blues St", "", "Folsom", 3, "jc@gmail.com", "Outa", "Names", "1234567890", "CA", "95887" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
