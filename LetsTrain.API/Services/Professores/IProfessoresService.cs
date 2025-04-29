using LetsTrain.API.DTO.Professor;
using LetsTrain.API.Models;

namespace LetsTrain.API.Services.Professores
{
    public interface IProfessoresService
    {
        Task<Professor> CreateProfessor(CreateProfessorDTO createProfessor);

    }
}
