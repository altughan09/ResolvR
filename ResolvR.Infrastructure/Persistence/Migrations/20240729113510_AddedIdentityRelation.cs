using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResolvR.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedIdentityRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("a8d83044-31ad-4485-920b-5ad338185093"));

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Complaints",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedAt", "Description", "LogoUrl", "Name", "WebsiteUrl" },
                values: new object[] { new Guid("48680ca1-135b-4271-9772-f9a8085804bd"), new DateTime(2024, 7, 29, 11, 35, 10, 315, DateTimeKind.Utc).AddTicks(4160), "Tradycyjny, działający od lat sieciowy fast food znany z burgerów i frytek.", "https://cdn.mcdonalds.pl/public/build/images/header/logo3.19d7d61fd29210afe458d0de4d0a7ca6.svg", "McDonald's", "https://mcdonalds.pl" });

            migrationBuilder.CreateIndex(
                name: "IX_Complaints_CreatorId",
                table: "Complaints",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Complaints_AspNetUsers_CreatorId",
                table: "Complaints",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complaints_AspNetUsers_CreatorId",
                table: "Complaints");

            migrationBuilder.DropIndex(
                name: "IX_Complaints_CreatorId",
                table: "Complaints");

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: new Guid("48680ca1-135b-4271-9772-f9a8085804bd"));

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Complaints");

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedAt", "Description", "LogoUrl", "Name", "WebsiteUrl" },
                values: new object[] { new Guid("a8d83044-31ad-4485-920b-5ad338185093"), new DateTime(2024, 7, 29, 8, 59, 33, 862, DateTimeKind.Utc).AddTicks(4810), "Tradycyjny, działający od lat sieciowy fast food znany z burgerów i frytek.", "https://cdn.mcdonalds.pl/public/build/images/header/logo3.19d7d61fd29210afe458d0de4d0a7ca6.svg", "McDonald's", "https://mcdonalds.pl" });
        }
    }
}
