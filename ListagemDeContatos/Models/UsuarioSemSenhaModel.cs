using ListagemDeContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace ListagemDeContatos.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite seu nome!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite seu login!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite seu Email!")]
        [EmailAddress(ErrorMessage = "O Email digitado é inválido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o perfil!")]
        public PerfilEnum? Perfil { get; set; }
    }
}
