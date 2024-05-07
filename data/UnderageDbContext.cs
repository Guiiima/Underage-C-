using Underage.models;
using Microsoft.EntityFrameworkCore;

namespace Underage.data;

public class UnderageDbContext : DbContext {
    public DbSet<DadosPessoais>? DadosPessoais {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlite("datasource=underage.db; Cache=shared");
    }
}