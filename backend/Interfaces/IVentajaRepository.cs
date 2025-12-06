using RunnerApi.Models;

namespace RunnerApi.Interfaces
{
    public interface IVentajaRepository
    {
        Task<IEnumerable<Ventaja>> GetAllAsync();
        Task<Ventaja> GetByIdAsync(int id);
        Task<Ventaja> CreateAsync(Ventaja ventaja);
        Task<Ventaja> UpdateAsync(Ventaja ventaja);
        Task<bool> DeleteAsync(int id);
    }
}
