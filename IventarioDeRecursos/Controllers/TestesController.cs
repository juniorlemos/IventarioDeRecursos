using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IventarioDeRecursos.Data;
using IventarioDeRecursos.Models;

namespace IventarioDeRecursos.Controllers
{
    public class TestesController : Controller
    {
        private readonly RecursoContext _context;

        public TestesController(RecursoContext context)
        {
            _context = context;
        }

        // GET: Testes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recursos.ToListAsync());
        }

        // GET: Testes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recurso = await _context.Recursos
                .FirstOrDefaultAsync(m => m.Descricao == id);
            if (recurso == null)
            {
                return NotFound();
            }

            return View(recurso);
        }

        // GET: Testes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Testes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao,Quantidade,Observacao,NomeResponsavel")] Recurso recurso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recurso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recurso);
        }

        // GET: Testes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recurso = await _context.Recursos.FindAsync(id);
            if (recurso == null)
            {
                return NotFound();
            }
            return View(recurso);
        }

        // POST: Testes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Descricao,Quantidade,Observacao,NomeResponsavel")] Recurso recurso)
        {
            if (id != recurso.Descricao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recurso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecursoExists(recurso.Descricao))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recurso);
        }

        // GET: Testes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recurso = await _context.Recursos
                .FirstOrDefaultAsync(m => m.Descricao == id);
            if (recurso == null)
            {
                return NotFound();
            }

            return View(recurso);
        }

        // POST: Testes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var recurso = await _context.Recursos.FindAsync(id);
            _context.Recursos.Remove(recurso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecursoExists(string id)
        {
            return _context.Recursos.Any(e => e.Descricao == id);
        }
    }
}
