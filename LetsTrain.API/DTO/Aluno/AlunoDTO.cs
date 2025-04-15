using LetsTrain.API.Models;

namespace LetsTrain.API.DTO
{
    public class AlunoDTO
    {
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefone { get; set; }
        public float? PesoEmKg { get; set; }
        public float? AlturaEmM { get; set; }
        public string? Graduacao { get; set; }
        public bool IsAtivo { get; set; }
        public int DiaVencimentoMatricula { get; set; }
    }
}
