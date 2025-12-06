using Microsoft.EntityFrameworkCore;
using RunnerApi.Data;
using RunnerApi.Interfaces;
using RunnerApi.Models;

namespace RunnerApi.Repository
{
    public class ClasificacionRepository : IClasificacionRepository
    {
        private readonly RunnersDbContext _context;

        public ClasificacionRepository(RunnersDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Clasificacion>> GetAllAsync()
        {
            return await _context.Clasificaciones.ToListAsync();
        }

        public async Task<Clasificacion> GetByIdAsync(int id)
        {
            return await _context.Clasificaciones.FindAsync(id);
        }

        public async Task<Clasificacion> CreateAsync(Clasificacion clasificacion)
        {
            _context.Clasificaciones.Add(clasificacion);
            await _context.SaveChangesAsync();
            return clasificacion;
        }

        public async Task<Clasificacion> UpdateAsync(Clasificacion clasificacion)
        {
            _context.Clasificaciones.Update(clasificacion);
            await _context.SaveChangesAsync();
            return clasificacion;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Clasificaciones.FindAsync(id);
            if (entity == null) return false;

            _context.Clasificaciones.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
