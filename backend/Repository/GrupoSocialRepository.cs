using Microsoft.EntityFrameworkCore;
using RunnerApi.Data;
using RunnerApi.Interfaces;
using RunnerApi.Models;

namespace RunnerApi.Repository
{
    public class GrupoSocialRepository : IGrupoSocialRepository
    {
        private readonly RunnersDbContext _context;

        public GrupoSocialRepository(RunnersDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GrupoSocial>> GetAllAsync()
        {
            return await _context.GruposSociales.ToListAsync();
        }

        public async Task<GrupoSocial> GetByIdAsync(int id)
        {
            return await _context.GruposSociales.FindAsync(id);
        }

        public async Task<GrupoSocial> CreateAsync(GrupoSocial grupo)
        {
            _context.GruposSociales.Add(grupo);
            await _context.SaveChangesAsync();
            return grupo;
        }

        public async Task<GrupoSocial> UpdateAsync(GrupoSocial grupo)
        {
            _context.GruposSociales.Update(grupo);
            await _context.SaveChangesAsync();
            return grupo;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.GruposSociales.FindAsync(id);
            if (entity == null) return false;

            _context.GruposSociales.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
