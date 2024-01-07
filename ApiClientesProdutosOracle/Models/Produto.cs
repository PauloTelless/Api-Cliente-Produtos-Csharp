using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text.Json.Serialization;

namespace ApiClientesProdutosOracle.Models;

[Table("Produtos")]
public class Produto
{
    [Key]
    public int ProdutoId { get; set; }

    [Required, StringLength(80, MinimumLength = 5)]
    public string? Nome { get; set; }

    [Required, StringLength(60)]
    public string? Categoria { get; set; }

    [Required, StringLength(300)]
    public string? Descricao { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
    public DateTime DataCompra { get; set; }

    public int ClienteId { get; set; }

    [JsonIgnore]
    public Cliente? Clientes { get; set; }
}
