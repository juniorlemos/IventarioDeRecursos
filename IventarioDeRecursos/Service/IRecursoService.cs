using System.Collections.Generic;
using System.Threading.Tasks;

namespace IventarioDeRecursos.Service
{
    public interface IRecursoService<TEntity> where TEntity : class
    {

        Task DeletarRecurso(string id );
        Task InserirRecurso(TEntity entidade);
        
        Task AtualizarRecurso(TEntity entidade);
        Task<List<TEntity>> PegarTodosOsRecursos();
        Task<TEntity> PegarRecurso(string id);

    }
}
