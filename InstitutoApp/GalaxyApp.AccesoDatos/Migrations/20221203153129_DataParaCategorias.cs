using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GalaxyApp.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class DataParaCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Estado", "FechaActualizacion", "FechaCreacion", "Nombre" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2022, 12, 3, 10, 31, 29, 627, DateTimeKind.Local).AddTicks(7821), "Java" },
                    { 2, true, null, new DateTime(2022, 12, 3, 10, 31, 29, 627, DateTimeKind.Local).AddTicks(7838), ".NET" },
                    { 3, true, null, new DateTime(2022, 12, 3, 10, 31, 29, 627, DateTimeKind.Local).AddTicks(7839), "Azure" },
                    { 4, true, null, new DateTime(2022, 12, 3, 10, 31, 29, 627, DateTimeKind.Local).AddTicks(7840), "AWS" },
                    { 5, true, null, new DateTime(2022, 12, 3, 10, 31, 29, 627, DateTimeKind.Local).AddTicks(7841), "Microservicios .NET" },
                    { 6, true, null, new DateTime(2022, 12, 3, 10, 31, 29, 627, DateTimeKind.Local).AddTicks(7843), "Microservicios Java" },
                    { 7, true, null, new DateTime(2022, 12, 3, 10, 31, 29, 627, DateTimeKind.Local).AddTicks(7844), "Frontend Angular" },
                    { 8, true, null, new DateTime(2022, 12, 3, 10, 31, 29, 627, DateTimeKind.Local).AddTicks(7845), "React" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
