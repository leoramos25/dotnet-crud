using devio_fundamentos.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace devio_fundamentos.Controller;

[ApiController]
[Route("api/fornecedores")]
public class FornecedorController : ControllerBase
{
    private readonly ApiDbContext _context;

    public FornecedorController(ApiDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Fornecedor>>> BuscarTodosFornecedores()
    {
        return await _context.Fornecedores.ToListAsync();
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult<Fornecedor>> BuscarFornecedorPorId(Guid id)
    {
        var fornecedor = await _context.Fornecedores.FindAsync(id);

        if (fornecedor == null) return BadRequest();

        return fornecedor;
    }

    [HttpPost]
    public async Task<ActionResult<Fornecedor>> CriarFornecedor(Fornecedor fornecedor)
    {
        _context.Fornecedores.Add(fornecedor);
        await _context.SaveChangesAsync();

        return CreatedAtAction("BuscarFornecedorPorId", new { id = fornecedor.Id }, fornecedor);
    }

    [HttpPut]
    public async Task<ActionResult<Fornecedor>> AtualizarForncedor(Guid id, Fornecedor fornecedor)
    {
        if (id != fornecedor.Id)
        {
            return BadRequest();
        }

        _context.Entry(fornecedor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VerificarSeFornecedorExiste(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    public async Task<ActionResult<Fornecedor>> DeletarFornecedor(Guid id)
    {
        var fornecedor = await _context.Fornecedores.FindAsync(id);
        if (fornecedor == null)
        {
            return NotFound();
        }

        _context.Fornecedores.Remove(fornecedor);
        await _context.SaveChangesAsync();

        return fornecedor;
    }

    public bool VerificarSeFornecedorExiste(Guid id)
    {
        return _context.Fornecedores.Any(fornecedor => fornecedor.Id == id);
    }
}