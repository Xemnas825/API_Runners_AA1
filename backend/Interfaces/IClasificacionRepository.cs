using RunnerApi.Models;

namespace RunnerApi.Interfaces
{
    public interface IClasificacionRepository
    {
        Task<IEnumerable<Clasificacion>> GetAllAsync();
        Task<Clasificacion> GetByIdAsync(int id);
        Task<Clasificacion> CreateAsync(Clasificacion clasificacion);
        Task<Clasificacion> UpdateAsync(Clasificacion clasificacion);
        Task<bool> DeleteAsync(int id);
    }
}
