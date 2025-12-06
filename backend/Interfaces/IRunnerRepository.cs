using RunnerApi.Models;

namespace RunnerApi.Interfaces
{
    public interface IRunnerRepository
    {
        Task<IEnumerable<Runner>> GetAllAsync();
        Task<Runner> GetByIdAsync(int id);
        Task<Runner> CreateAsync(Runner runner);
        Task<Runner> UpdateAsync(Runner runner);
        Task<bool> DeleteAsync(int id);
    }
}
