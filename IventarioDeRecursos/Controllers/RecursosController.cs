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
        private readonly IRecursoService<Recurso> _service;

        public RecursosController(IRecursoService<Recurso> service)
        {
            _service = service;
        }

        // GET: Recursos
        public async Task<IActionResult> Index()
        {
            var recursos = await _service.PegarTodosOsRecursos();

            return View(recursos);
        }

        // GET: Recursos/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
          

            var recurso = await _service.PegarRecurso(id);
            
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
        public async Task<IActionResult> Create([Bind("Id,Descricao,Quantidade,Observacao")] Recurso recurso)
        {
            if (ModelState.IsValid)
            {
                recurso.Id = Guid.NewGuid();

               await _service.InserirRecurso(recurso);                
               
                return RedirectToAction(nameof(Index));
            }
            return View(recurso);
        }

        // GET: Recursos/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
           


            var recurso = await _service.PegarRecurso(id);
            if (recurso == null)
            {
                return NotFound();
            }
            return View(recurso);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Descricao,Quantidade,Observacao")] Recurso recurso)
        {
            if (id != recurso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {


                await _service.AtualizarRecurso(recurso);
              
                return RedirectToAction(nameof(Index));
            }
            return View(recurso);
        }

        // GET: Recursos/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {



            var recurso = await _service.PegarRecurso(id);
          
            if (recurso == null)
            {
                return NotFound();
            }

            return View(recurso);
        }

        // POST: Recursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _service.DeletarRecurso(id);
            
            return RedirectToAction(nameof(Index));
        }

        
    }
}
