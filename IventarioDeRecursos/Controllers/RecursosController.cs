using IventarioDeRecursos.Models;
using IventarioDeRecursos.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

                
                var rec = await _serviceRecurso.PegarRecurso(recurso.Descricao);

                if (rec == null) {
                    await _serviceRecurso.InserirRecurso(recurso);

                    await _serviceMovimentacao.InserirMovimentacao(recurso);
                    TempData["Mensagem"] = "sucesso";

                    return RedirectToAction(nameof(Create));
                }
                
                TempData["Mensagem"] = "erroChaveDuplicada";
                return View();


            }
            TempData["Mensagem"] = "erro";
            return View();
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
        public async Task<IActionResult> Edit( string id, [Bind("Quantidade,Observacao")] Recurso recurso)
        {



            var recursoAntigo = await _serviceRecurso.PegarRecurso(id);

            recurso.Descricao = recursoAntigo.Descricao;
            recurso.NomeResponsavel = recursoAntigo.NomeResponsavel;

                await _serviceRecurso.AtualizarRecurso(recurso);
            TempData["Mensagem"] = "editadosucesso";
            return RedirectToAction(nameof(Index));
           
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

            var pessoaNome = txtName;

         

            var movimentacao= await _serviceMovimentacao.PegarMovimentacao(id);

           
            await _serviceRecurso.DeletarRecurso(id);

            await _serviceMovimentacao.SaidaMovimentacao(movimentacao, pessoaNome);

            TempData["Mensagem"] = "deletesucesso";

            return RedirectToAction(nameof(Index));
        }


        
    }
}
