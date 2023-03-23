using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaGustavoBatista.Migrations
{
    /// <inheritdoc />
    public partial class removingFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "Movimientos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Saldo",
                table: "Movimientos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
