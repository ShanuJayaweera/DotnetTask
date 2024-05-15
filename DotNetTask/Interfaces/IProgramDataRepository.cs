using DotNetTask.Models;

namespace DotNetTask.Interfaces
{
    public interface IProgramDataRepository
    {
        Task<ProgramData> CreateProgramDataAsync(ProgramData program);
    }
}
