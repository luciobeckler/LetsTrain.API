using System.Text.Json.Serialization;

namespace LetsTrain.API.Models
{
    public class Aula
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public int QuantMaximaAlunos { get; set; }
        public string Local { get; set; } = null!;
        public int? RecorrenciaEmDias { get; set; }

        //Relacionamentos
        public int TreinoId { get; set; }
        [JsonIgnore]
        public Treino Treino { get; set; }

        public int ProfessorId { get; set; }
        [JsonIgnore]
        public Professor Professor { get; set; }


        public List<Aluno> Aluno { get; set; } = new List<Aluno>();
    }
}
