using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIPlanoDeReficoes.Migrations
{
    /// <inheritdoc />
    public partial class updatePatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Patients");
        }
    }
}
