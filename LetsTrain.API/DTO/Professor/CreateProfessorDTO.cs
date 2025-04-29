namespace LetsTrain.API.DTO.Professor
{
    public class CreateProfessorDTO
    {
        public string Nome { get; set; } = null!;
        public string? Descricao { get; set; }
        public bool IsAtivo { get; set; }
    }
}
