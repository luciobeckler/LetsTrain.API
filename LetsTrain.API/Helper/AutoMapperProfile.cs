using AutoMapper;
using LetsTrain.API.DTO.Aula;
using LetsTrain.API.DTO.Exercicio;
using LetsTrain.API.DTO.Professor;
using LetsTrain.API.DTO.Treino;
using LetsTrain.API.Models;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Treino, TreinoResponseDTO>().ReverseMap();
        CreateMap<Exercicio, ExercicioResponseDTO>().ReverseMap();
        CreateMap<Aula, CreateAulaDTO>().ReverseMap();
        CreateMap<Professor, CreateProfessorDTO>().ReverseMap();
        CreateMap<Exercicio, CreateExercicioDTO>().ReverseMap();
        CreateMap<Aula, AulaResponseDTO>().ReverseMap();
    }
}
