using AutoMapper;
using LetsTrain.API.Data;
using LetsTrain.API.DTO.Aula;
using LetsTrain.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LetsTrain.API.Services.Aulas
{
    public class AulasService : IAulasService
    {
        private readonly LetsTrainDb _db;
        private readonly IMapper _mapper;

        public AulasService(LetsTrainDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<Aula>> ListAllAsync()
        {
            return await _db.Aulas
                .Include(a => a.Professor)
                .Include(a => a.Treino)
                .ToListAsync();
        }

        public async Task<bool> MatricularAlunoNaAulaAsync(int alunoId, int aulaId)
        {
            var aluno = await _db.Alunos.FindAsync(alunoId);
            var aula = await _db.Aulas
                .Include(a => a.Alunos)
                .FirstOrDefaultAsync(a => a.Id == aulaId);

            if (aluno == null)
            {
                throw new KeyNotFoundException("Aluno não encontrado");
            }

            if (aula == null)
            {
                throw new KeyNotFoundException("Aula não encontrada");
            }

            if (aula.Alunos.Any(a => a.Id == alunoId))
            {
                throw new InvalidOperationException("Aluno já matriculado nesta aula");
            }

            if (aula.Alunos.Count >= aula.QuantMaximaAlunos)
            {
                throw new InvalidOperationException("Não há vagas disponíveis para esta aula");
            }

            aula.Alunos.Add(aluno);

            _db.Aulas.Update(aula);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<Aula> CreateAula(CreateAulaDTO createAula)
        {
            var professorExiste = await _db.Professores.AnyAsync(p => p.Id == createAula.ProfessorId);
            if(!professorExiste)
                throw new KeyNotFoundException($"Professor com ID {createAula.ProfessorId} não encontrado.");

            var treinoExiste = await _db.Treinos.AnyAsync(t => t.Id == createAula.TreinoId);
            if(!treinoExiste)
                throw new KeyNotFoundException($"Treino com ID {createAula.TreinoId} não encontrado.");

            var aula = _mapper.Map<Aula>(createAula);
            _db.Aulas.Add(aula);
            await _db.SaveChangesAsync();

            return aula;
        }
    }
}
