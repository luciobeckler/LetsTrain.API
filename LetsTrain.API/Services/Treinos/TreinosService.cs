using AutoMapper;
using LetsTrain.API.Data;
using LetsTrain.API.DTO.Exercicio;
using LetsTrain.API.DTO.Professor;
using LetsTrain.API.DTO.Treino;
using LetsTrain.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LetsTrain.API.Services.Treinos
{
    public class TreinosService : ITreinosService
    {
        private readonly LetsTrainDb _db;
        private readonly IMapper _mapper;

        public TreinosService(LetsTrainDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<TreinoResponseDTO> CreateTreino(CreateTreinoDTO createTreino)
        {
            var professorExiste = await _db.Professores.AnyAsync(p => p.Id == createTreino.ProfessorId);
            if (!professorExiste)
            {
                throw new Exception($"Professor com ID {createTreino.ProfessorId} não foi encontrado.");
            }

            var exercicios = await _db.Exercicios
                .Where(e => createTreino.ExerciciosId.Contains(e.Id))
                .ToListAsync();

            var idsEncontrados = exercicios.Select(e => e.Id).ToList();
            var idsNaoEncontrados = createTreino.ExerciciosId.Except(idsEncontrados).ToList();

            if (idsNaoEncontrados.Any())
            {
                throw new Exception($"Os seguintes IDs de exercícios não foram encontrados: {string.Join(", ", idsNaoEncontrados)}");
            }

            var treino = new Treino
            {
                Nome = createTreino.Nome,
                DuracaoEmMinutos = createTreino.DuracaoEmMinutos,
                ProfessorId = createTreino.ProfessorId,
                Exercicios = exercicios
            };

            await _db.Treinos.AddAsync(treino);
            await _db.SaveChangesAsync();

            var treinoResponse = _mapper.Map<TreinoResponseDTO>(treino);
            return treinoResponse;
        }
    }
}
