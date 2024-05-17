using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoef.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDefaultValueDateTarea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Tarea",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 17, 11, 57, 55, 308, DateTimeKind.Local).AddTicks(8499),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("ee24c066-d0bb-4a47-8bdd-ff3b66512c11"),
                column: "FechaCreacion",
                value: new DateTime(2024, 5, 17, 11, 57, 55, 308, DateTimeKind.Local).AddTicks(6673));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("ee24c066-d0bb-4a47-8bdd-ff3b66512cea"),
                column: "FechaCreacion",
                value: new DateTime(2024, 5, 17, 11, 57, 55, 308, DateTimeKind.Local).AddTicks(6662));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Tarea",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2024, 5, 17, 11, 57, 55, 308, DateTimeKind.Local).AddTicks(8499));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("ee24c066-d0bb-4a47-8bdd-ff3b66512c11"),
                column: "FechaCreacion",
                value: new DateTime(2024, 5, 17, 11, 48, 32, 852, DateTimeKind.Local).AddTicks(2396));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("ee24c066-d0bb-4a47-8bdd-ff3b66512cea"),
                column: "FechaCreacion",
                value: new DateTime(2024, 5, 17, 11, 48, 32, 852, DateTimeKind.Local).AddTicks(2382));
        }
    }
}
