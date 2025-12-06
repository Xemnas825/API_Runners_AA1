using Microsoft.EntityFrameworkCore;
using RunnerApi.Data;
using RunnerApi.Interfaces;
using RunnerApi.Models;

namespace RunnerApi.Repository
{
    public class VentajaRepository : IVentajaRepository
    {
        private readonly RunnersDbContext _context;

        public VentajaRepository(RunnersDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ventaja>> GetAllAsync()
        {
            return await _context.Ventajas.ToListAsync();
        }

        public async Task<Ventaja> GetByIdAsync(int id)
        {
            return await _context.Ventajas.FindAsync(id);
        }

        public async Task<Ventaja> CreateAsync(Ventaja ventaja)
        {
            _context.Ventajas.Add(ventaja);
            await _context.SaveChangesAsync();
            return ventaja;
        }

        public async Task<Ventaja> UpdateAsync(Ventaja ventaja)
        {
            _context.Ventajas.Update(ventaja);
            await _context.SaveChangesAsync();
            return ventaja;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Ventajas.FindAsync(id);
            if (entity == null) return false;

            _context.Ventajas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
