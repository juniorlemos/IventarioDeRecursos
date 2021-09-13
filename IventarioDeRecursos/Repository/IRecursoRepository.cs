using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IventarioDeRecursos.Repository
{
   public interface IRecursoRepository<TEntity> where TEntity : class
    {

        Task DeletarRecurso(Guid id);
        Task InserirRecurso(TEntity entidade);
        Task AtualizarRecurso(TEntity entidade);
        Task<List<TEntity>> PegarTodosOsRecursos();
        Task<TEntity> PegarRecurso(Guid id);

    }
}
