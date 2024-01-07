using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiClientesProdutosOracle.Migrations
{
    /// <inheritdoc />
    public partial class PopulaClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO \"Clientes\"(\"Nome\", \"Email\", \"NomeUsuario\") VALUES ('Paulo Souza Telles Filho', 'paulinho.email@.com', 'paulo_telles23')");
            migrationBuilder.Sql($"INSERT INTO \"Clientes\"(\"Nome\", \"Email\", \"NomeUsuario\") VALUES ('Décio Carvalho Faria', 'decio.email@.com', 'decinho_dograu24')");
            migrationBuilder.Sql($"INSERT INTO \"Clientes\"(\"Nome\", \"Email\", \"NomeUsuario\") VALUES ('Leandro Dias Silva', 'leandrogamer123.email@.com', 'leoDias_25')");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Clientes\"");
        }
    }
}
