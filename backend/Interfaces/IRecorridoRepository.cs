using RunnerApi.Models;

namespace RunnerApi.Interfaces
{
    public interface IRecorridoRepository
    {
        Task<IEnumerable<Recorrido>> GetAllAsync();
        Task<Recorrido> GetByIdAsync(int id);
        Task<Recorrido> CreateAsync(Recorrido recorrido);
        Task<Recorrido> UpdateAsync(Recorrido recorrido);
        Task<bool> DeleteAsync(int id);
    }
}
