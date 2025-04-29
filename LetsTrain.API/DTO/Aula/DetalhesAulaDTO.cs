using LetsTrain.API.DTO.Aluno;

namespace LetsTrain.API.DTO.Aula
{
    public class DetalhesAulaDTO
    {
        public string NomeProfessor { get; set; }
        public string? FotoProfessor { get; set; }
        public string TreinoNome { get; set; }
        public int DuracaoEmMinutos { get; set; }

        public List<InfoAlunoDTO> Alunos{ get; set; }
    }
}
