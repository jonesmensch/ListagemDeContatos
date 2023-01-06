using ListagemDeContatos.Helper;
using ListagemDeContatos.Models;
using ListagemDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ListagemDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            if (_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index","Login");
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
                            _sessao.CriarSessaoUsuario(usuario);
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
