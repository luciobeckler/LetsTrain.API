using LetsTrain.API.DTO.Exercicio;

namespace LetsTrain.API.DTO.Treino
{
    public class TreinoResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int DuracaoEmMinutos { get; set; }
        public int ProfessorId { get; set; }
        public List<ExercicioResponseDTO> Exercicios { get; set; }
    }
}
