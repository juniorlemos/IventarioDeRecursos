using IventarioDeRecursos.Data;
using IventarioDeRecursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IventarioDeRecursos.Repository
{
    public class MovimentacaoRepository : IMovimentacaoRepository<Movimentacao>
    {
        private readonly RecursoContext _context;

        public MovimentacaoRepository(RecursoContext context)
        {
            _context = context;
        }

        
            public async Task InserirMovimento(Movimentacao recurso)
            {


                _context.Movimentacao.Add(recurso);

                await _context.SaveChangesAsync();
            }


        public async Task<Movimentacao> PegarMovimentacao(string id, string p)
        {
            var entidade = await _context.Recursos.FindAsync(id);
            var movimentacao = await _context.Movimentacao.FindAsync(entidade.Descricao);

            return movimentacao;


        }

        public async Task AtualizarMovimentacao(Movimentacao movimento, string p)
        {
           
           
            movimento.DataSaida = DateTime.Now;
            movimento.NomeSaidaRecurso = p;
           
            await _context.SaveChangesAsync();
        }



    }
    }

