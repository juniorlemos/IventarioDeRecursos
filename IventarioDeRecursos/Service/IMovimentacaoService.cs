using IventarioDeRecursos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IventarioDeRecursos.Service
{
    public interface IMovimentacaoService<TEntity> where TEntity : class
    {
        Task InserirMovimentacao(Recurso entidade);
        Task<TEntity> PegarMovimentacao(string  id);
        Task<List<TEntity>> PegarTodasMovimentacoes();
        Task SaidaMovimentacao(TEntity movimento, string pessoaNome);


    }
}
