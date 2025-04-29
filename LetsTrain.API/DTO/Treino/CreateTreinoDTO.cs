using LetsTrain.API.Models;
using System.Text.Json.Serialization;

namespace LetsTrain.API.DTO.Treino
{
    public class CreateTreinoDTO
    {
        public string Nome { get; set; } = null!;
        public int DuracaoEmMinutos { get; set; }
        public int ProfessorId { get; set; }
        public List<int> ExerciciosId { get; set; } = new List<int>();
    }
}
