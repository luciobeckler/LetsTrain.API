namespace LetsTrain.API.Models
{
    public class Exercicio
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int Repeticoes { get; set; }

        //Relacionamentos
        public List<Treino> Treino { get; set; } = new List<Treino>();
    }
}
