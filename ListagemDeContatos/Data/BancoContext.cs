using System;
using System.Collections.Generic;
using ListagemDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ListagemDeContatos.Data
{
    public partial class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<ContatoModel> Contato { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
