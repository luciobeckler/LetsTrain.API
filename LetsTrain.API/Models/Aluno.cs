using LetsTrain.API.Models.Identity;

namespace LetsTrain.API.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Telefone { get; set; }
        public float? PesoEmKg { get; set; }
        public float? AlturaEmM { get; set; }
        public string? Graduacao { get; set; }
        public bool IsAtivo { get; set; }
        public int? DiaVencimentoMatricula { get; set; }

        public List<Aula> Aulas { get; set; } = new List<Aula>();

        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
