using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Amoozeshyar.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FileAdding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("71fb40ed-c2b3-4169-a792-1efaddd715a4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9d7a7041-7a9f-4830-b4a5-df3c4c317af0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a2b4cf86-0bdd-40c3-90b6-7979cd790fd6"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("04e2bac0-754c-46d6-a6ff-d686ea6cb9f6"), "d4d92349-b00b-47f4-ac42-cc6c56eb22ee", "Admin", "ADMIN" },
                    { new Guid("a97023d1-67b1-4252-8918-d2f04804b6f2"), "a85ac51c-ec9f-4ffa-a3e5-2ac3d44c827d", "Teacher", "TEACHER" },
                    { new Guid("ec8a1c2b-117f-4865-abe4-8cd0c04bfcd9"), "6d3ff7ce-fb73-40bb-b908-09be7638439f", "Student", "STUDENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("04e2bac0-754c-46d6-a6ff-d686ea6cb9f6"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a97023d1-67b1-4252-8918-d2f04804b6f2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ec8a1c2b-117f-4865-abe4-8cd0c04bfcd9"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("71fb40ed-c2b3-4169-a792-1efaddd715a4"), "9eb5fa80-2498-438d-aff3-b0d468504d64", "Teacher", "TEACHER" },
                    { new Guid("9d7a7041-7a9f-4830-b4a5-df3c4c317af0"), "ef51c03b-2276-43c3-8752-84436451ed2e", "Student", "STUDENT" },
                    { new Guid("a2b4cf86-0bdd-40c3-90b6-7979cd790fd6"), "c364af61-0d69-48fb-b937-9e814a03ca34", "Admin", "ADMIN" }
                });
        }
    }
}
