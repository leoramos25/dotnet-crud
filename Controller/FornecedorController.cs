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
}