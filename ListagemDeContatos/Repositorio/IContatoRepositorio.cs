using ListagemDeContatos.Data;
using ListagemDeContatos.Models;

namespace ListagemDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> FindAll();
        ContatoModel FindById(int id);
        ContatoModel Editar(ContatoModel contato);
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Excluir(ContatoModel contato);
    }
}
