using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LetsTrain.API.Migrations
{
    /// <inheritdoc />
    public partial class Adicionandoautentificacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Alunos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_UserId",
                table: "Alunos",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_AspNetUsers_UserId",
                table: "Alunos",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_AspNetUsers_UserId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_UserId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Alunos");
        }
    }
}
