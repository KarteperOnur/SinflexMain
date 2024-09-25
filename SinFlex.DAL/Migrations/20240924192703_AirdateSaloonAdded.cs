using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sinflex.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AirdateSaloonAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SaloonId",
                table: "AirDates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AirDates_SaloonId",
                table: "AirDates",
                column: "SaloonId");

            migrationBuilder.AddForeignKey(
                name: "FK_AirDates_Saloons_SaloonId",
                table: "AirDates",
                column: "SaloonId",
                principalTable: "Saloons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AirDates_Saloons_SaloonId",
                table: "AirDates");

            migrationBuilder.DropIndex(
                name: "IX_AirDates_SaloonId",
                table: "AirDates");

            migrationBuilder.DropColumn(
                name: "SaloonId",
                table: "AirDates");
        }
    }
}
