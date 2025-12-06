using RunnerApi.DTOs;

namespace RunnerApi.Interfaces
{
    public interface IRecorridoService
    {
        Task<IEnumerable<RecorridoDTO>> GetAllAsync();
        Task<RecorridoDTO> GetByIdAsync(int id);
        Task<RecorridoDTO> CreateAsync(RecorridoDTO dto);
        Task<RecorridoDTO> UpdateAsync(int id, RecorridoDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
