using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIPlanoDeReficoes.Migrations
{
    /// <inheritdoc />
    public partial class updateValuesOfFood : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Update Foods set sizeOfPortion = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
