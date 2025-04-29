using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetsTrain.API.Migrations
{
    /// <inheritdoc />
    public partial class Alterandonomecolunaparaalunosnatabelaaula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoAula_Alunos_AlunoId",
                table: "AlunoAula");

            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "AlunoAula",
                newName: "AlunosId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoAula_Alunos_AlunosId",
                table: "AlunoAula",
                column: "AlunosId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoAula_Alunos_AlunosId",
                table: "AlunoAula");

            migrationBuilder.RenameColumn(
                name: "AlunosId",
                table: "AlunoAula",
                newName: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoAula_Alunos_AlunoId",
                table: "AlunoAula",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
