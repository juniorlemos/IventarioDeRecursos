using IventarioDeRecursos.Models;
using IventarioDeRecursos.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace IventarioDeRecursos.Controllers
{
    public class MovimentacaosController : Controller
    {
        
        private readonly IMovimentacaoService<Movimentacao> _service;

        public MovimentacaosController(IMovimentacaoService<Movimentacao> service)
        {
            _service = service;
        }

        // GET: Movimentacaos
        public async Task<IActionResult> Index()
        {
            var movimentacao = await _service.PegarTodasMovimentacoes();
          
            return View(movimentacao);
        }
       

    }
}
