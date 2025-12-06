using RunnerApi.Models;

namespace RunnerApi.Interfaces
{
    public interface IGrupoSocialRepository
    {
        Task<IEnumerable<GrupoSocial>> GetAllAsync();
        Task<GrupoSocial> GetByIdAsync(int id);
        Task<GrupoSocial> CreateAsync(GrupoSocial grupo);
        Task<GrupoSocial> UpdateAsync(GrupoSocial grupo);
        Task<bool> DeleteAsync(int id);
    }
}
