using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIPlanoDeReficoes.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFoodsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sizeOfPortion",
                table: "Meal_Plans");

            migrationBuilder.AddColumn<long>(
                name: "SizeOfPortion",
                table: "Foods",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SizeOfPortion",
                table: "Foods");

            migrationBuilder.AddColumn<int>(
                name: "sizeOfPortion",
                table: "Meal_Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
