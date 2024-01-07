using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClientesProdutosOracle.Models;

[Table("Clientes")]
public class Cliente
{
    public Cliente()
    {
        Produtos = new Collection<Produto>();
    }

    [Key]
    public int ClienteId { get; set; }

    [Required, StringLength(80, MinimumLength = 5)]
    public string? Nome { get; set; }

    [Required, StringLength(80)]
    public string? Email { get; set; }

    [Required, StringLength(50, MinimumLength = 5)]
    public string? NomeUsuario { get; set; }

    public Collection<Produto> Produtos { get; set; }
}
