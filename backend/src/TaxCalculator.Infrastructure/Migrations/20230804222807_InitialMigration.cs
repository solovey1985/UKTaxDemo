using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaxCalculator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxBands",
                columns: table => new
                {
                    LowerLimit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpperLimit = table.Column<int>(type: "int", nullable: true),
                    TaxRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxBands", x => x.LowerLimit);
                });
            migrationBuilder.InsertData(
            table: "TaxBands",
            columns: new[] { "LowerLimit", "Name", "UpperLimit", "TaxRate" },
            values: new object[,]
            {
                { 0, "Tax Band A", 5000, 0 },
                { 5000, "Tax Band B", 20000, 20 },
                { 20000, "Tax Band C", null, 40 }
            });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxBands");
        }
    }
}
