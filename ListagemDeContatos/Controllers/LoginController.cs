using ListagemDeContatos.Models;
using ListagemDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ListagemDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.FindByLogin(loginModel.Login);

                    if(usuario != null)
                    {
                        if (usuario.Senha == loginModel.Senha)
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Senha incorreta, tente novamente!";
                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha incorreta, tente novamente!";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não conseguimos realizar seu login, tente novamente! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
