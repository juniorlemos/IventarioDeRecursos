using IventarioDeRecursos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IventarioDeRecursos.Data
{
    public class RecursoContext : DbContext
    {
        public RecursoContext(DbContextOptions<RecursoContext> options)
            : base(options)
        {
        }

        public DbSet<Recurso> Recursos { get; set; }
      
    }
}
