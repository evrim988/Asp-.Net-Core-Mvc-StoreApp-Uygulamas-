using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init_SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedOn", "IsActive", "IsDeleted", "LastModifiedOn", "ProductDescription", "ProductName", "ProductPrice" },
                values: new object[] { 1, new DateTime(2024, 4, 24, 21, 6, 5, 506, DateTimeKind.Local).AddTicks(4310), true, false, new DateTime(2024, 4, 24, 21, 6, 5, 506, DateTimeKind.Local).AddTicks(4321), "Apple Macbook Air M1", "Mac", 28000m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
