using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IventarioDeRecursos.Data;
using IventarioDeRecursos.Models;
using IventarioDeRecursos.Service;

namespace IventarioDeRecursos.Controllers
{
    public class RecursosController : Controller
    {
        private readonly IRecursoService<Recurso> _serviceRecurso;
        private readonly IMovimentacaoService<Movimentacao> _serviceMovimentacao;

        public RecursosController(IRecursoService<Recurso> serviceRecurso,
            IMovimentacaoService<Movimentacao> serviceMovimentacao)
        {
            _serviceRecurso = serviceRecurso;
            _serviceMovimentacao = serviceMovimentacao;
        }

        // GET: Recursos
        public async Task<IActionResult> Index()
        {
            var recursos = await _serviceRecurso.PegarTodosOsRecursos();

            return View(recursos);
        }

        // GET: Recursos/Details/5
        public async Task<IActionResult> Details(string id)
        {
          

            var recurso = await _serviceRecurso.PegarRecurso(id);
            
            if (recurso == null)
            {
                return NotFound();
            }

            return View(recurso);
        }

        // GET: Recursos/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao,Quantidade,Observacao,NomeResponsavel")] Recurso recurso)
        {
            if (ModelState.IsValid)
            {
                

               await _serviceRecurso.InserirRecurso(recurso);

                await _serviceMovimentacao.InserirMovimentacao(recurso);

                return RedirectToAction(nameof(Index));
            }
            return View(recurso);
        }

        // GET: Recursos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
           


            var recurso = await _serviceRecurso.PegarRecurso(id);
            if (recurso == null)
            {
                return NotFound();
            }
            return View(recurso);
        }

              
       
     [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( int id, [Bind("Id,Descricao,Quantidade,Observacao")] Recurso recurso)
        {
            

            if (ModelState.IsValid)
            {


                await _serviceRecurso.AtualizarRecurso(recurso);
              
                return RedirectToAction(nameof(Index));
            }
            return View(recurso);
        }

        // GET: Recursos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {



            var recurso = await _serviceRecurso.PegarRecurso(id);
          
            if (recurso == null)
            {
                return NotFound();
            }

            return View(recurso);
        }

        // POST: Recursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id,string txtName)
        {

            var p = txtName;

           var movimentacao= await _serviceMovimentacao.PegarMovimentacao(id, p);
            
            await _serviceRecurso.DeletarRecurso(id,p);

            await _serviceMovimentacao.SaidaMovimentacao(movimentacao, p);
            
            return RedirectToAction(nameof(Index));
        }

        
    }
}
