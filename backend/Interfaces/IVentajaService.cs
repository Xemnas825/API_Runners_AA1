using RunnerApi.DTOs;

namespace RunnerApi.Interfaces
{
    public interface IVentajaService
    {
        Task<IEnumerable<VentajaDTO>> GetAllAsync();
        Task<VentajaDTO> GetByIdAsync(int id);
        Task<VentajaDTO> CreateAsync(VentajaDTO dto);
        Task<VentajaDTO> UpdateAsync(int id, VentajaDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
