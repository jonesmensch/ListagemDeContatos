using ListagemDeContatos.Models;

namespace ListagemDeContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        List<UsuarioModel> FindAll();
        UsuarioModel FindByLogin(string login);
        UsuarioModel FindById(int id);
        UsuarioModel Editar(UsuarioModel usuario);
        UsuarioModel Adicionar(UsuarioModel usuario);
        bool Excluir(int id);
    }
}
