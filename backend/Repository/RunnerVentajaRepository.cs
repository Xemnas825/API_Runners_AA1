using Microsoft.EntityFrameworkCore;
using RunnerApi.Data;
using RunnerApi.Interfaces;
using RunnerApi.Models;

namespace RunnerApi.Repository
{
    public class RunnerVentajaRepository : IRunnerVentajaRepository
    {
        private readonly RunnersDbContext _context;

        public RunnerVentajaRepository(RunnersDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RunnerVentaja>> GetAllAsync()
        {
            return await _context.RunnerVentajas.ToListAsync();
        }

        public async Task<RunnerVentaja> GetAsync(int runnerId, int ventajaId)
        {
            return await _context.RunnerVentajas
                .FirstOrDefaultAsync(rv => rv.RunnerId == runnerId && rv.VentajaId == ventajaId);
        }

        public async Task<RunnerVentaja> CreateAsync(RunnerVentaja entity)
        {
            _context.RunnerVentajas.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int runnerId, int ventajaId)
        {
            var entity = await GetAsync(runnerId, ventajaId);

            if (entity == null)
                return false;

            _context.RunnerVentajas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
