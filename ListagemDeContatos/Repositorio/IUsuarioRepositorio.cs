using ListagemDeContatos.Models;

namespace ListagemDeContatos.Repositorio
{
    public interface IUsuarioRepositorio
    {
        List<UsuarioModel> FindAll();
        UsuarioModel FindById(int id);
        UsuarioModel Editar(UsuarioModel usuario);
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Excluir(UsuarioModel usuario);
    }
}
