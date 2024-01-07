using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiClientesProdutosOracle.Migrations
{
    public partial class PopulaProdutos : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Produtos\"(\"Nome\", \"Categoria\", \"Descricao\", \"DataCompra\", \"ClienteId\") VALUES('Notebook Vivobook 16x', 'Notebooks', 'Notebook equipado com o Intel Core I5 de 12° geração 8/12 (8 núcleos e 12 threads)', TO_DATE('24/12/2023', 'DD/MM/YYYY'), 1)");

            migrationBuilder.Sql("INSERT INTO \"Produtos\"(\"Nome\", \"Categoria\", \"Descricao\", \"DataCompra\", \"ClienteId\") VALUES('RX 580 8gb', 'Placas gráficas dedicadas', 'Placa de vídeo AMD RX 580 Powercolor com 8gb GDDR5. Dois anos de garantia', TO_DATE('22/09/2023', 'DD/MM/YYYY'), 2)");

            migrationBuilder.Sql("INSERT INTO \"Produtos\"(\"Nome\", \"Categoria\", \"Descricao\", \"DataCompra\", \"ClienteId\") VALUES('Notebook Acer Nitro 5 17,5 polegadas', 'Notebooks', 'Notebook equipado com o Intel Core I5 11300h Tela 144hz Led e 512gb SSD',TO_DATE('27/03/2023', 'DD/MM/YYYY'), 3)");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Produtos\"");
        }
    }
}
