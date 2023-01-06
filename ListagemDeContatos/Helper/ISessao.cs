using ListagemDeContatos.Models;

namespace ListagemDeContatos.Helper
{
    public interface ISessao
    {
        void CriarSessaoUsuario(UsuarioModel usuarioModel);
        void RemoverSessaoUsuario();
        UsuarioModel BuscarSessaoUsuario();
    }
}
