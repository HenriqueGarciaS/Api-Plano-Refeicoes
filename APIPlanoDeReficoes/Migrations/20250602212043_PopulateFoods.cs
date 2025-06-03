using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIPlanoDeReficoes.Migrations
{
    /// <inheritdoc />
    public partial class PopulateFoods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Foods(Name, Calories) " +
                "values('coca-cola 350ml', 144)");
            migrationBuilder.Sql("Insert into Foods(Name, Calories) " +
                "values('water 100ml', 0)");
            migrationBuilder.Sql("Insert into Foods(Name, Calories) " +
                "values('spaghetti 100g', 158)");
            migrationBuilder.Sql("Insert into Foods(Name, Calories) " +
                "values('carrot 100g', 41)");
            migrationBuilder.Sql("Insert into Foods(Name, Calories) " +
                "values('coca-cola 100g', 52)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
