using ListagemDeContatos.Data;
using ListagemDeContatos.Models;
using System.Linq;

namespace ListagemDeContatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<ContatoModel> FindAll()
        {
            return _bancoContext.Contato.ToList();
        }
        public ContatoModel FindById(int id)
        {
            return _bancoContext.Contato.FirstOrDefault(x => x.Id == id);
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contato.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

        public ContatoModel Alterar(ContatoModel contato)
        {
            var contatoDB = FindById(contato.Id);

            if (contatoDB == null)
            {
                throw new System.Exception("Ocorreu um erro ao atualizar!");
            }
            else
            {
                contatoDB.Nome= contato.Nome;
                contatoDB.Email= contato.Email;
                contatoDB.Telefone= contato.Telefone;
            }

            _bancoContext.Contato.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }

        public ContatoModel Excluir(ContatoModel contato)
        {
            var contatoDB = FindById(contato.Id);

            if (contatoDB == null)
            {
                throw new System.Exception("Contato não encontrado!");
            }
            else
            {
                _bancoContext.Contato.Remove(contatoDB); 
                _bancoContext.SaveChanges();

                return contatoDB;
            }
        }
    }
}
