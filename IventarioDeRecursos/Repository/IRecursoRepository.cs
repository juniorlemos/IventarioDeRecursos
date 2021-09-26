using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IventarioDeRecursos.Repository
{
   public interface IRecursoRepository<TEntity> where TEntity : class
    {

        Task DeletarRecurso(string id ,string p);
        Task InserirRecurso(TEntity entidade);
        Task AtualizarRecurso(TEntity entidade);
        Task<List<TEntity>> PegarTodosOsRecursos();
        Task<TEntity> PegarRecurso(string id);
        
    }
}
