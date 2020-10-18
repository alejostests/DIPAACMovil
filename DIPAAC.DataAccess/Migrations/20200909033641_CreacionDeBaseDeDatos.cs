using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class CreacionDeBaseDeDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Dipaac");

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "Dipaac",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(maxLength: 16, nullable: false),
                    NombreCompleto = table.Column<string>(maxLength: 100, nullable: false),
                    Edad = table.Column<byte>(nullable: false),
                    Contraseña = table.Column<string>(maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuestionario",
                schema: "Dipaac",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Tipo = table.Column<byte>(nullable: false),
                    Conclusion = table.Column<string>(maxLength: 200, nullable: false),
                    Calificacion = table.Column<byte>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuestionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuestionario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "Dipaac",
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respuesta",
                schema: "Dipaac",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EsCorrecta = table.Column<bool>(nullable: false),
                    RespuestaIngresada = table.Column<string>(maxLength: 32, nullable: false),
                    CuestionarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuesta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respuesta_Cuestionario_CuestionarioId",
                        column: x => x.CuestionarioId,
                        principalSchema: "Dipaac",
                        principalTable: "Cuestionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuestionario_UsuarioId",
                schema: "Dipaac",
                table: "Cuestionario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuesta_CuestionarioId",
                schema: "Dipaac",
                table: "Respuesta",
                column: "CuestionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Respuesta",
                schema: "Dipaac");

            migrationBuilder.DropTable(
                name: "Cuestionario",
                schema: "Dipaac");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "Dipaac");
        }
    }
}
