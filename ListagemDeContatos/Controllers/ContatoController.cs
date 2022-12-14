using ListagemDeContatos.Models;
using ListagemDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ListagemDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            var contato = _contatoRepositorio.FindAll();
            return View(contato);
        }
        public IActionResult Editar(int id)
        {
            var contato = _contatoRepositorio.FindById(id);
            return View(contato);
        }
        public IActionResult DeletarConfirmacao(int id)
        {
            var contato = _contatoRepositorio.FindById(id);
            return View(contato);
        }
        public IActionResult NovoContato()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(ContatoModel contato)
        {
            _contatoRepositorio.Adicionar(contato);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            _contatoRepositorio.Alterar(contato);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Excluir(ContatoModel contato)
        {
            _contatoRepositorio.Excluir(contato);
            return RedirectToAction(nameof(Index));
        }
    }
}
