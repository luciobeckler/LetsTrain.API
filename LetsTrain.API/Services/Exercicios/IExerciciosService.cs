using LetsTrain.API.DTO.Exercicio;
using LetsTrain.API.DTO.Professor;
using LetsTrain.API.Models;

namespace LetsTrain.API.Services.Exercicios
{
    public interface IExerciciosService
    {
        Task<Exercicio> CreateExercicio(CreateExercicioDTO createExercicio);
    }
}
