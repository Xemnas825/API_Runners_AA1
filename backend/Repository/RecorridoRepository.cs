using Microsoft.EntityFrameworkCore;
using RunnerApi.Data;
using RunnerApi.Interfaces;
using RunnerApi.Models;

namespace RunnerApi.Repository
{
    public class RecorridoRepository : IRecorridoRepository
    {
        private readonly RunnersDbContext _context;

        public RecorridoRepository(RunnersDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recorrido>> GetAllAsync()
        {
            return await _context.Recorridos.ToListAsync();
        }

        public async Task<Recorrido> GetByIdAsync(int id)
        {
            return await _context.Recorridos.FindAsync(id);
        }

        public async Task<Recorrido> CreateAsync(Recorrido recorrido)
        {
            _context.Recorridos.Add(recorrido);
            await _context.SaveChangesAsync();
            return recorrido;
        }

        public async Task<Recorrido> UpdateAsync(Recorrido recorrido)
        {
            _context.Recorridos.Update(recorrido);
            await _context.SaveChangesAsync();
            return recorrido;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Recorridos.FindAsync(id);
            if (entity == null) return false;

            _context.Recorridos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
