using RunnerApi.Interfaces;
using RunnerApi.Models;
using RunnerApi.DTOs;

namespace RunnerApi.Services
{
    public class ClasificacionService : IClasificacionService
    {
        private readonly IClasificacionRepository _repo;

        public ClasificacionService(IClasificacionRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ClasificacionDTO>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(ToDTO);
        }

        public async Task<ClasificacionDTO> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity == null ? null : ToDTO(entity);
        }

        public async Task<ClasificacionDTO> CreateAsync(ClasificacionDTO dto)
        {
            var entity = FromDTO(dto);
            var result = await _repo.CreateAsync(entity);
            return ToDTO(result);
        }

        public async Task<ClasificacionDTO> UpdateAsync(int id, ClasificacionDTO dto)
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

        private ClasificacionDTO ToDTO(Clasificacion c) => new ClasificacionDTO
        {
            Id = c.Id,
            Titulo = c.Titulo,
            Visible = c.Visible,
            FechaCreacion = c.FechaCreacion,
            RunnerId = c.RunnerId
        };

        private Clasificacion FromDTO(ClasificacionDTO dto) => new Clasificacion
        {
            Titulo = dto.Titulo,
            Visible = dto.Visible,
            FechaCreacion = dto.FechaCreacion,
            RunnerId = dto.RunnerId
        };
    }
}
