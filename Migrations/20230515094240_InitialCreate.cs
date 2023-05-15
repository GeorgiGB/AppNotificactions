using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppNotificactions.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Datos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Msg = table.Column<string>(type: "TEXT", nullable: false),
                    FechaEnvio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TopicId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Datos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Datos_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Topic",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "test" },
                    { 2, "prueba" }
                });

            migrationBuilder.InsertData(
                table: "Datos",
                columns: new[] { "Id", "FechaEnvio", "Msg", "Titulo", "TopicId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Texto de prueba", "Titulo de prueba", 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Texto de prueba", "Titulo de prueba", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Datos_TopicId",
                table: "Datos",
                column: "TopicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Datos");

            migrationBuilder.DropTable(
                name: "Topic");
        }
    }
}
