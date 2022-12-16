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
        public IActionResult NovoContato(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos cadastrar seu contato, tente novamente! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Editar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }

                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos editar seu contato, tente novamente! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Excluir(ContatoModel contato)
        {
            try
            {
                _contatoRepositorio.Excluir(contato);
                TempData["MensagemSucesso"] = "Contato excluido com sucesso!";
                return RedirectToAction(nameof(Index));
            }

            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos excluir seu contato, tente novamente! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
