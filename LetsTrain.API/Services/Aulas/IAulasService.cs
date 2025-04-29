using LetsTrain.API.DTO;
using LetsTrain.API.DTO.Aula;
using LetsTrain.API.Models;

namespace LetsTrain.API.Services.Aulas
{
    public interface IAulasService
    {
        Task<List<Aula>> ListAllAsync();
        Task<bool> MatricularAlunoNaAulaAsync(int alunoId, int aulaId);
        Task<Aula> CreateAula(CreateAulaDTO createAula);
    }
}
