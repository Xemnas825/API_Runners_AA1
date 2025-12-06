using RunnerApi.DTOs;

namespace RunnerApi.Interfaces
{
    public interface IGrupoSocialService
    {
        Task<IEnumerable<GrupoSocialDTO>> GetAllAsync();
        Task<GrupoSocialDTO> GetByIdAsync(int id);
        Task<GrupoSocialDTO> CreateAsync(GrupoSocialDTO dto);
        Task<GrupoSocialDTO> UpdateAsync(int id, GrupoSocialDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
