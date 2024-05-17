using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace proyectoef.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "peso" },
                values: new object[,]
                {
                    { new Guid("ee24c066-d0bb-4a47-8bdd-ff3b6651cc02"), null, "Actividades personales", 50 },
                    { new Guid("ee24c066-d0bb-4a47-8bdd-ff3b6651ccea"), null, "Actividades pendientes", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("ee24c066-d0bb-4a47-8bdd-ff3b66512c11"), new Guid("ee24c066-d0bb-4a47-8bdd-ff3b6651cc02"), null, new DateTime(2024, 5, 17, 11, 48, 32, 852, DateTimeKind.Local).AddTicks(2396), 0, "Terminar de ver pelicula en Netflix" },
                    { new Guid("ee24c066-d0bb-4a47-8bdd-ff3b66512cea"), new Guid("ee24c066-d0bb-4a47-8bdd-ff3b6651ccea"), null, new DateTime(2024, 5, 17, 11, 48, 32, 852, DateTimeKind.Local).AddTicks(2382), 1, "Revisar pago de servicios publicos" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("ee24c066-d0bb-4a47-8bdd-ff3b66512c11"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("ee24c066-d0bb-4a47-8bdd-ff3b66512cea"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("ee24c066-d0bb-4a47-8bdd-ff3b6651cc02"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("ee24c066-d0bb-4a47-8bdd-ff3b6651ccea"));
        }
    }
}
