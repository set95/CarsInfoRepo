using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarsInfoWeb.Migrations
{
    public partial class AddedColectionToAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Cars_CarId1",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarId1",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarId1",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Cars",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ApplicationUserId",
                table: "Cars",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_ApplicationUserId",
                table: "Cars",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_ApplicationUserId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ApplicationUserId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarId1",
                table: "Cars",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarId1",
                table: "Cars",
                column: "CarId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Cars_CarId1",
                table: "Cars",
                column: "CarId1",
                principalTable: "Cars",
                principalColumn: "CarId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
