using RunnerApi.Interfaces;
using RunnerApi.Models;
using RunnerApi.DTOs;

namespace RunnerApi.Services
{
    public class RecorridoService : IRecorridoService
    {
        private readonly IRecorridoRepository _repo;

        public RecorridoService(IRecorridoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<RecorridoDTO>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(ToDTO);
        }

        public async Task<RecorridoDTO> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity == null ? null : ToDTO(entity);
        }

        public async Task<RecorridoDTO> CreateAsync(RecorridoDTO dto)
        {
            var entity = FromDTO(dto);
            var result = await _repo.CreateAsync(entity);
            return ToDTO(result);
        }

        public async Task<RecorridoDTO> UpdateAsync(int id, RecorridoDTO dto)
        {
            var entity = FromDTO(dto);
            entity.Id = id;

            var updated = await _repo.UpdateAsync(entity);
            return ToDTO(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        private RecorridoDTO ToDTO(Recorrido r) => new RecorridoDTO
        {
            Id = r.Id,
            Kilometros = r.Kilometros,
            CaloriasQuemadas = r.CaloriasQuemadas,
            Nombre = r.Nombre,
            Fecha = r.Fecha,
            Comentario = r.Comentario,
            RunnerId = r.RunnerId
        };

        private Recorrido FromDTO(RecorridoDTO dto) => new Recorrido
        {
            Kilometros = dto.Kilometros,
            CaloriasQuemadas = dto.CaloriasQuemadas,
            Nombre = dto.Nombre,
            Fecha = dto.Fecha,
            Comentario = dto.Comentario,
            RunnerId = dto.RunnerId
        };
    }
}
