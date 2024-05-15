using DotNetTask.Data;
using DotNetTask.DTOs.Request;
using DotNetTask.Interfaces;
using DotNetTask.Mappers;
using DotNetTask.Models;

namespace DotNetTask.Repositories
{
    public class CandidateRepository: ICandidaterepository
    {
        private readonly ApplicationDBContext _context;

        public CandidateRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        /* 
         * Create new candidate
         * @param candidate
         */
        public async Task<Candidate> CreateCandidateAsync(CandidateDTO candidate)
        {
            
            Candidate mapCandidate = CandidateMapper.MapCandidateRequest(candidate);
            await _context.Candidates.AddAsync(mapCandidate);
            await _context.SaveChangesAsync();
            return mapCandidate;
        }

    }
}
