using RunnerApi.Interfaces;
using RunnerApi.Models;
using RunnerApi.Data;
using Microsoft.EntityFrameworkCore;

namespace RunnerApi.Repository
{
    public class RunnerRepository : IRunnerRepository
    {
        private readonly RunnersDbContext _context;

        public RunnerRepository(RunnersDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Runner>> GetAllAsync()
            => await _context.Runners.ToListAsync();

        public async Task<Runner> GetByIdAsync(int id)
            => await _context.Runners.FindAsync(id);

        public async Task<Runner> CreateAsync(Runner runner)
        {
            _context.Runners.Add(runner);
            await _context.SaveChangesAsync();
            return runner;
        }

        public async Task<Runner> UpdateAsync(Runner runner)
        {
            _context.Runners.Update(runner);
            await _context.SaveChangesAsync();
            return runner;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Runners.FindAsync(id);
            if (entity == null) return false;

            _context.Runners.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
