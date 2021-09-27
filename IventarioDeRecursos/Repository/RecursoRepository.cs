using IventarioDeRecursos.Data;
using IventarioDeRecursos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IventarioDeRecursos.Repository
{
    public class RecursoRepository :IRecursoRepository<Recurso>
    {
        private readonly RecursoContext _context;

        public RecursoRepository(RecursoContext context)
        {
            _context = context;
        }


        public async Task AtualizarRecurso(Recurso recurso)
        {

            var entry = _context.Recursos.First(e => e.Descricao == recurso.Descricao) ;
            _context.Entry(entry).CurrentValues.SetValues(recurso);

            await _context.SaveChangesAsync();

          
        }


        public async Task<Recurso> PegarRecurso(string recurso)
        {
         
                return await _context.Recursos.FindAsync(recurso);
            

        }
        public async Task<List<Recurso>> PegarTodosOsRecursos()
        {

            return await _context.Recursos.ToListAsync();

        }
        

        public async Task InserirRecurso(Recurso recurso)
        {
            _context.Recursos.Add(recurso);

            await _context.SaveChangesAsync();
           
        }


       


        public async Task DeletarRecurso(string id )
        {
            var entidade = await _context.Recursos.FindAsync(id);

    
            _context.Remove(entidade);

            await _context.SaveChangesAsync();
        }

        

     
        
        
        
    }
}
