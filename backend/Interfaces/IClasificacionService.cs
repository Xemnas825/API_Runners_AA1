using RunnerApi.DTOs;

namespace RunnerApi.Interfaces
{
    public interface IClasificacionService
    {
        Task<IEnumerable<ClasificacionDTO>> GetAllAsync();
        Task<ClasificacionDTO> GetByIdAsync(int id);
        Task<ClasificacionDTO> CreateAsync(ClasificacionDTO dto);
        Task<ClasificacionDTO> UpdateAsync(int id, ClasificacionDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
