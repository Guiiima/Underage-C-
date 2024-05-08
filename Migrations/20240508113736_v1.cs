using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Underage.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "DadosPessoais");

            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "DadosPessoais",
                newName: "Cpf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "DadosPessoais",
                newName: "Senha");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "DadosPessoais",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
