namespace LetsTrain.API.DTO.Account
{
    public class RegisterAlunoDTO
    {
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public int DiaVencimento { get; set; }
        public string Senha { get; set; } = null!;
    }
}
