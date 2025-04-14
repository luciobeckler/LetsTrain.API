using System.Text.Json.Serialization;

namespace LetsTrain.API.Models
{
    public class Treino
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int DuracaoEmMinutos { get; set; }

        //Relacionamentos
        public int ProfessorId { get; set; }
        [JsonIgnore]
        public Professor Professor { get; set; }

        public List<Aula> Aulas { get; set; } = new List<Aula>();

        public List<Exercicio> Exercicios { get; set; } = new List<Exercicio>();

    }
}
