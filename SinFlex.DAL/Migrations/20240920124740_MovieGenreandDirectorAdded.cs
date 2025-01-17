﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sinflex.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MovieGenreandDirectorAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Actors",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AgeRestriction",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Actors",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "AgeRestriction",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Movies");
        }
    }
}
