using DotNetTask.Data;
using DotNetTask.Interfaces;
using DotNetTask.Models;

namespace DotNetTask.Repositories
{
    public class ProgramDataRepository : IProgramDataRepository
    {

        private readonly ApplicationDBContext _context;

        public ProgramDataRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        /* 
         * Create programData
         * @param program
         */
        public async Task<ProgramData> CreateProgramDataAsync(ProgramData program)
        {
            await _context.ProgramDatas.AddAsync(program);
            await _context.SaveChangesAsync();
            return program;
        }

    }
}
