
using IventarioDeRecursos.Models;
using IventarioDeRecursos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IventarioDeRecursos.Service
{
    public class MovimentacaoService : IMovimentacaoService<Movimentacao>
    {
        private readonly IMovimentacaoRepository<Movimentacao> _repository;

        public MovimentacaoService(IMovimentacaoRepository<Movimentacao> repository)
        {
            _repository = repository;
        }
        public async Task InserirMovimentacao(Recurso entidade)
        {


            var movimento = new Movimentacao
            {
                Descricao = entidade.Descricao,
                NomeEntradaRecurso = entidade.NomeResponsavel,
                NomeSaidaRecurso="",
               

            };

            await _repository.InserirMovimento(movimento);

        }
        public async Task<Movimentacao> PegarMovimentacao(string id)
        {
            return await _repository.PegarMovimentacao(id);
        }

        public async Task<List<Movimentacao>> PegarTodasMovimentacoes()
        {

            return await _repository.PegarTodasMovimentacoes();
        }

        public async Task SaidaMovimentacao(Movimentacao movimento, string pessoaNome)
        {
            await _repository.AtualizarSaidaMovimentacao(movimento, pessoaNome);
        }

       

    }
}
