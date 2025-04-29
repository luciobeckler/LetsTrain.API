using LetsTrain.API.DTO.Professor;
using LetsTrain.API.DTO.Treino;
using LetsTrain.API.Models;

namespace LetsTrain.API.Services.Treinos
{
    public interface ITreinosService
    {
        Task<TreinoResponseDTO> CreateTreino(CreateTreinoDTO createTreino);
    }
}
