using ListagemDeContatos.Models;
using ListagemDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ListagemDeContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            var usuario = _usuarioRepositorio.FindAll();
            return View(usuario);
        }
        public IActionResult Editar(int id)
        {
            var usuario = _usuarioRepositorio.FindById(id);
            return View(usuario);
        }
        public IActionResult DeletarConfirmacao(int id)
        {
            var usuario = _usuarioRepositorio.FindById(id);
            return View(usuario);
        }
        public IActionResult NovoUsuario()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NovoUsuario(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos cadastrar seu usuário, tente novamente! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = (Enums.PerfilEnum)usuarioSemSenhaModel.Perfil
                    };

                    _usuarioRepositorio.Editar(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }

                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos editar seu usuário, tente novamente! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Excluir(UsuarioModel usuario)
        {
            try
            {
                _usuarioRepositorio.Excluir(usuario);
                TempData["MensagemSucesso"] = "Usuário excluido com sucesso!";
                return RedirectToAction(nameof(Index));
            }

            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos excluir seu usuário, tente novamente! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
