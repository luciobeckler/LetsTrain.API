using System.Text.Json.Serialization;

namespace LetsTrain.API.DTO.Aula
{
    public class AulaResponseDTO
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public int QuantMaximaAlunos { get; set; }
        public string Local { get; set; } = null!;
        public int? RecorrenciaEmDias { get; set; }
        public int Vagas { get; set; }

        public int TreinoId { get; set; }
        public int ProfessorId { get; set; }
    }
}
