using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sinflex.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SessionUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SaloonsId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_SaloonsId",
                table: "Sessions",
                column: "SaloonsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Saloons_SaloonsId",
                table: "Sessions",
                column: "SaloonsId",
                principalTable: "Saloons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Saloons_SaloonsId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_SaloonsId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "SaloonsId",
                table: "Sessions");
        }
    }
}
