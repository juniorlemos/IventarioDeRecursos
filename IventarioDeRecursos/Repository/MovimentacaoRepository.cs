using IventarioDeRecursos.Data;
using IventarioDeRecursos.Models;
using Microsoft.EntityFrameworkCore;
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


        public async Task<Movimentacao> PegarMovimentacao(string id)
        {
           

            //var entidade = await _context.Recursos.FindAsync(id);

            var entidade =  _context.Recursos.First(e => e.Descricao == id);

            //var movimentacao = await _context.Movimentacao.FindAsync(entidade.Descricao);
            var movimentacao =  _context.Movimentacao.OrderByDescending(i =>i.MovimentacaoID).First(e => e.Descricao == entidade.Descricao);

            

            return  movimentacao;


        }
        public async Task<List<Movimentacao>> PegarTodasMovimentacoes()
        {
           
            return await _context.Movimentacao.AsNoTracking().OrderBy(d=>d.DataEntrada).ToListAsync();
           
        }

        public async Task AtualizarSaidaMovimentacao(Movimentacao movimento, string pessoaNome)
        {
           
           
            movimento.DataSaida = DateTime.Now;
            movimento.NomeSaidaRecurso = pessoaNome;
           
            await _context.SaveChangesAsync();
        }

       

    }
    }

