using RunnerApi.DTOs;

namespace RunnerApi.Interfaces
{
    public interface IRunnerVentajaService
    {
        Task<IEnumerable<RunnerVentajaDTO>> GetAllAsync();
        Task<RunnerVentajaDTO> GetAsync(int runnerId, int ventajaId);
        Task<RunnerVentajaDTO> CreateAsync(RunnerVentajaDTO dto);
        Task<bool> DeleteAsync(int runnerId, int ventajaId);
    }
}
