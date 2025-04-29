using AutoMapper;
using LetsTrain.API.Data;
using LetsTrain.API.DTO.Aula;
using LetsTrain.API.DTO.Exercicio;
using LetsTrain.API.DTO.Professor;
using LetsTrain.API.Models;

namespace LetsTrain.API.Services.Exercicios
{
    public class ExerciciosService : IExerciciosService
    {

        private readonly LetsTrainDb _db;
        private readonly IMapper _mapper;

        public ExerciciosService(LetsTrainDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Exercicio> CreateExercicio(CreateExercicioDTO createExercicio)
        {
            var exercicio = _mapper.Map<Exercicio>(createExercicio);

            _db.Exercicios.Add(exercicio);
            await _db.SaveChangesAsync();
            return exercicio;
        }
    }
}
