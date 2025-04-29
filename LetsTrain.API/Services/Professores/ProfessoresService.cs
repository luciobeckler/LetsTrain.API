using AutoMapper;
using LetsTrain.API.Data;
using LetsTrain.API.DTO.Professor;
using LetsTrain.API.Models;


namespace LetsTrain.API.Services.Professores
{
    public class ProfessoresService : IProfessoresService
    {
        private readonly LetsTrainDb _db;
        private readonly IMapper _mapper;

        public ProfessoresService(LetsTrainDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Professor> CreateProfessor(CreateProfessorDTO createProfessor)
        {
            var professor = _mapper.Map<Professor>(createProfessor);

            await _db.Professores.AddAsync(professor);
            await _db.SaveChangesAsync();
            return professor;
        }
    }
}
