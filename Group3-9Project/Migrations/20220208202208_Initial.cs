using Microsoft.EntityFrameworkCore.Migrations;

namespace Group3_9Project.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "TaskEntries",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Task = table.Column<string>(nullable: false),
                    DueDate = table.Column<string>(nullable: true),
                    Quadrant = table.Column<byte>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskEntries", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_TaskEntries_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "School" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Work" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 4, "Church" });

            migrationBuilder.InsertData(
                table: "TaskEntries",
                columns: new[] { "TaskId", "CategoryId", "Completed", "DueDate", "Quadrant", "Task" },
                values: new object[] { 1, 2, false, "February 9, 2022", (byte)1, "Mission 6" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskEntries_CategoryId",
                table: "TaskEntries",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskEntries");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
