using devio_fundamentos.Model;
using Microsoft.EntityFrameworkCore;

namespace devio_fundamentos;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }

    public DbSet<Fornecedor> Fornecedores { get; set; }
}