using IventarioDeRecursos.Models;
using Microsoft.EntityFrameworkCore;

namespace IventarioDeRecursos.Data
{
    public class RecursoContext : DbContext
    {
        public RecursoContext(DbContextOptions<RecursoContext> options)
            : base(options)
        {
        }

        public DbSet<Recurso> Recursos { get; set; }

        public DbSet<Movimentacao> Movimentacao { get; set; }
      
    }
}
