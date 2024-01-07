using ApiClientesProdutosOracle.Context;
using ApiClientesProdutosOracle.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiClientesProdutosOracle.Controllers;

[Route("[controller]")]
[ApiController] 
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
        try
        {
            var context = _context.Produtos.AsNoTracking().ToList();

            if (context is null)
            {
                return BadRequest();
            }

            return Ok(context);
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro na sua solicitação");
        }
        
    }

    [HttpGet("{id:int}")]
    public ActionResult<Produto> GetProdutoId(int id)
    {
        try
        {
            var produto = _context.Produtos.AsNoTracking().SingleOrDefault(x => x.ProdutoId == id);

            if (produto is null)
            {
                return NotFound($"Id = {id} não encontrado");
            }

            return Ok(produto);
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro na sua solicitação");
        }
        
    }

    [HttpPost]
    public ActionResult<Produto> PostProduto(Produto produto)
    {
        try
        {

            _context.Produtos.Add(produto);

            _context.SaveChanges();

            return Ok(produto);
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro na sua solicitação");
        }
        
    }

    [HttpPut("{id:int}")]
    public ActionResult<Produto> PutProduto(int id, Produto produto)
    {
        try
        {
            if (id != produto.ProdutoId)
            {
                return NotFound($"Id = {id} não encontrado");
            }

            _context.Produtos.Entry(produto).State = EntityState.Modified;

            _context.SaveChanges();

            return Ok(produto);
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro na sua solicitação");
        }
        
    }

    [HttpDelete("{id:int}")]
    public ActionResult<Produto> DeleteProduto(int id)
    {
        try
        {
            var produto = _context.Produtos.FirstOrDefault(x => x.ProdutoId == id);

            if (produto is null)
            {
                return NotFound($"Id = {id} não encontrado");
            }

            _context.Produtos.Remove(produto);

            _context.SaveChanges();

            return Ok(produto);
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro na sua solicitação");
        }
        
    }
}
