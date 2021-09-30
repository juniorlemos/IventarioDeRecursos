using System.Collections.Generic;
using System.Threading.Tasks;

namespace IventarioDeRecursos.Repository
{
    public interface IMovimentacaoRepository<TEntity> where TEntity : class
    {
        Task InserirMovimento(TEntity entidade);
        Task <TEntity>PegarMovimentacao(string id);
        Task<List<TEntity>> PegarTodasMovimentacoes();
        Task AtualizarSaidaMovimentacao(TEntity movimento, string pessoaNome);
       
    }
}
