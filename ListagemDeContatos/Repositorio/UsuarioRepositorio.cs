using ListagemDeContatos.Data;
using ListagemDeContatos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListagemDeContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public List<UsuarioModel> FindAll()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel FindByLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login == login);
        }

        public UsuarioModel FindById(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCriacao = DateTime.Now;
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();

            return usuario;
        }

        public UsuarioModel Editar(UsuarioModel usuario)
        {
            var usuarioDB = FindById(usuario.Id);

            if (usuarioDB == null)
            {
                throw new System.Exception("Ocorreu um erro ao atualizar!");
            }

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAlteracao = DateTime.Now;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public bool Excluir(int id)
        {
            UsuarioModel usuarioDB = FindById(id);

            if (usuarioDB == null)
            {
                throw new System.Exception("Houve um erro ao deletar o usuário!");
            }

            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
