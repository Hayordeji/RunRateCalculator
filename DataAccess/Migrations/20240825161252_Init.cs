using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonthsCompleted = table.Column<int>(type: "int", nullable: false),
                    MonthRemaining = table.Column<int>(type: "int", nullable: false),
                    AnnualBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlyBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YearTillDateAchieved = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YearTillDateBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    YearTillDateVariance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemainingBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RunRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");
        }
    }
}
