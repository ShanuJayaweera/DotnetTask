using DotNetTask.DTOs.Request;
using DotNetTask.Models;

namespace DotNetTask.Interfaces
{
    public interface ICandidaterepository
    {
        Task<Candidate> CreateCandidateAsync(CandidateDTO candidate);
    }
}
