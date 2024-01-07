using ApiClientesProdutosOracle.Context;
using ApiClientesProdutosOracle.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Security.Policy;

namespace ApiClientesProdutosOracle.Controllers;

[Route("[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClientesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Cliente>> Get()
    {
        try
        {
            var context = _context.Clientes.AsNoTracking().ToList();

            return context;
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro na sua solicitação");
        }
        
    }

    [HttpGet("{id:int}")]
    public ActionResult<Cliente> GetClienteId(int id)
    {
        try
        {
            var cliente = _context.Clientes.FirstOrDefault(x => x.ClienteId == id);

            if (cliente is null)
            {
                return NotFound($"Id = {id} não encontrado");
            }

            return Ok(cliente);
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro na sua solicitação");
        }
        
    }

    [HttpGet("Produtos")]
    public ActionResult<IEnumerable<Cliente>> GetClienteProdutos()
    {
        try
        {
            var clientesProdutos = _context.Clientes.AsNoTracking().Include(x => x.Produtos).ToList();

            return clientesProdutos;
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro na sua solicitação");
        }
        

    }

    [HttpGet("Produtos/{id:int}")]
    public ActionResult<IEnumerable<Cliente>> GetClienteProdutosId(int id)
    {
        try
        {
            var clienteProduto = _context.Clientes.FirstOrDefault(x => x.ClienteId == id);

            if (clienteProduto is null)
            {
                return NotFound($"Id = {id} não encontrado");
            }

            return _context.Clientes.Include(x => x.Produtos).Where(y => y.ClienteId == id).AsNoTracking().ToList();
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro na sua solicitação");
        }
        

    }

    [HttpPost]
    public ActionResult<Cliente> PostCliente(Cliente cliente)
    {
        try
        {
            _context.Clientes.Add(cliente);

            _context.SaveChanges();

            return cliente;
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro na sua solicitação");
        }
        
    }

    [HttpPut("{id:int}")]
    public ActionResult<Cliente> PutCliente(int id, Cliente cliente)
    {
        try
        {
            if (id != cliente.ClienteId)
            {
                return NotFound($"Id = {id} não encontrado");
            }

            _context.Clientes.Entry(cliente).State = EntityState.Modified;

            _context.SaveChanges();

            return Ok(cliente);
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro na sua solicitação");
        }
        
    }

    [HttpDelete("{id:int}")]
    public ActionResult<Cliente> DeleteCliente(int id)
    {
        try
        {
            var cliente = _context.Clientes.FirstOrDefault(x => x.ClienteId == id);

            if (cliente is null)
            {
                return NotFound($"Id = {id} não encontrado");
            }

            _context.Clientes.Remove(cliente);

            _context.SaveChanges();

            return Ok(cliente);
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro na sua solicitação");
        }
        
    }
}
