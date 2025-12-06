using RunnerApi.Models;

namespace RunnerApi.Interfaces
{
    public interface IRunnerVentajaRepository
    {
        Task<IEnumerable<RunnerVentaja>> GetAllAsync();
        Task<RunnerVentaja> GetAsync(int runnerId, int ventajaId);
        Task<RunnerVentaja> CreateAsync(RunnerVentaja entity);
        Task<bool> DeleteAsync(int runnerId, int ventajaId);
    }
}
