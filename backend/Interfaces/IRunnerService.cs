using RunnerApi.DTOs;
namespace RunnerApi.Interfaces
{
    public interface IRunnerService
    {
        Task<IEnumerable<RunnerDTO>> GetAllAsync();
        Task<RunnerDTO?> GetByIdAsync(int id);
        Task<RunnerDTO> CreateAsync(RunnerDTO dto);
        Task<RunnerDTO?> UpdateAsync(int id, RunnerDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}

