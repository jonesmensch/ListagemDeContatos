using System.ComponentModel.DataAnnotations;

namespace ListagemDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="O nome digitado é inválido!")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Digite o Email!")]
        [EmailAddress(ErrorMessage ="O Email digitado é inválido!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Digite um número para contato!")]
        [Phone(ErrorMessage = "O número digitado é inválido!")]
        public string? Telefone { get; set; }
    }
}
