using IventarioDeRecursos.Models;
using IventarioDeRecursos.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IventarioDeRecursos.Service
{
    public class RecursoService :IRecursoService<Recurso>
    {

        private readonly IRecursoRepository<Recurso> _repository;

        public RecursoService(IRecursoRepository<Recurso> repository)
        {
            _repository = repository;
        }

        public async Task AtualizarRecurso(Recurso entidade)
        {
            await _repository.AtualizarRecurso(entidade);

        }

        public  async Task DeletarRecurso(Guid id)
        {
           await _repository.DeletarRecurso(id);
        }

        public async Task InserirRecurso(Recurso entidade)
        {
            await _repository.InserirRecurso(entidade);

        }

        public async Task<Recurso> PegarRecurso(Guid id)
        {
            return await _repository.PegarRecurso(id);

        }

        public async Task<List<Recurso>> PegarTodosOsRecursos()
        {
           return await _repository.PegarTodosOsRecursos();

        }
    }
}
