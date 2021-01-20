using Microsoft.EntityFrameworkCore.Migrations;

namespace Colegio.Infraestructure.Data.Migrations
{
    public partial class v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Colegio");

            migrationBuilder.CreateTable(
                name: "Alumno",
                schema: "Colegio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(maxLength: 21, nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false),
                    Apellido = table.Column<string>(maxLength: 200, nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(maxLength: 500, nullable: true),
                    Telefono = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Asignatura",
                schema: "Colegio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignatura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                schema: "Colegio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<string>(maxLength: 21, nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false),
                    Apellido = table.Column<string>(maxLength: 200, nullable: false),
                    Edad = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(maxLength: 500, nullable: true),
                    Telefono = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlumnoAsignatura",
                schema: "Colegio",
                columns: table => new
                {
                    AlumnoId = table.Column<int>(nullable: false),
                    AsignaturaId = table.Column<int>(nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    CalificacionFinal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoAsignatura", x => new { x.AlumnoId, x.AsignaturaId, x.Ano });
                    table.ForeignKey(
                        name: "FK_AlumnoAsignatura_Alumno_AlumnoId",
                        column: x => x.AlumnoId,
                        principalSchema: "Colegio",
                        principalTable: "Alumno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnoAsignatura_Asignatura_AsignaturaId",
                        column: x => x.AsignaturaId,
                        principalSchema: "Colegio",
                        principalTable: "Asignatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfesorAsignatura",
                schema: "Colegio",
                columns: table => new
                {
                    ProfesorId = table.Column<int>(nullable: false),
                    AsignaturaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesorAsignatura", x => x.ProfesorId);
                    table.ForeignKey(
                        name: "FK_ProfesorAsignatura_Asignatura_AsignaturaId",
                        column: x => x.AsignaturaId,
                        principalSchema: "Colegio",
                        principalTable: "Asignatura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfesorAsignatura_Profesor_ProfesorId",
                        column: x => x.ProfesorId,
                        principalSchema: "Colegio",
                        principalTable: "Profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoAsignatura_AsignaturaId",
                schema: "Colegio",
                table: "AlumnoAsignatura",
                column: "AsignaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesorAsignatura_AsignaturaId",
                schema: "Colegio",
                table: "ProfesorAsignatura",
                column: "AsignaturaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnoAsignatura",
                schema: "Colegio");

            migrationBuilder.DropTable(
                name: "ProfesorAsignatura",
                schema: "Colegio");

            migrationBuilder.DropTable(
                name: "Alumno",
                schema: "Colegio");

            migrationBuilder.DropTable(
                name: "Asignatura",
                schema: "Colegio");

            migrationBuilder.DropTable(
                name: "Profesor",
                schema: "Colegio");
        }
    }
}
