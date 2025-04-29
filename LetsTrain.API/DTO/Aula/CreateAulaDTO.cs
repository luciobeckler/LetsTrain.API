namespace LetsTrain.API.DTO.Aula
{
    public class CreateAulaDTO
    {
        public DateTime DataHora { get; set; }
        public int QuantMaximaAlunos { get; set; }
        public string Local { get; set; }
        public int? RecorrenciaEmDias { get; set; }
        public int TreinoId { get; set; }
        public int ProfessorId { get; set; }
        public int Vagas { get; set; }
    }
}
