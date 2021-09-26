using IventarioDeRecursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IventarioDeRecursos.Service
{
   public interface IMovimentacaoService<TEntity> where TEntity : class
    {
        Task InserirMovimentacao(Recurso entidade);
        Task<TEntity> PegarMovimentacao(string id, string p);
        Task SaidaMovimentacao(TEntity movimento, string p);


    }
}
