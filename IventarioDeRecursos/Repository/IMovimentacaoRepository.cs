using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IventarioDeRecursos.Repository
{
    public interface IMovimentacaoRepository<TEntity> where TEntity : class
    {
        Task InserirMovimento(TEntity entidade);
        Task <TEntity>PegarMovimentacao(string id);
        Task AtualizarMovimentacao(TEntity movimento, string pessoaNome);
    }
}
