using RunnerApi.Interfaces;
using RunnerApi.Models;
using RunnerApi.DTOs;

namespace RunnerApi.Services
{
    public class VentajaService : IVentajaService
    {
        private readonly IVentajaRepository _repo;

        public VentajaService(IVentajaRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<VentajaDTO>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(ToDTO);
        }

        public async Task<VentajaDTO> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return entity == null ? null : ToDTO(entity);
        }

        public async Task<VentajaDTO> CreateAsync(VentajaDTO dto)
        {
            var entity = FromDTO(dto);
            var created = await _repo.CreateAsync(entity);
            return ToDTO(created);
        }

        public async Task<VentajaDTO> UpdateAsync(int id, VentajaDTO dto)
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

        private VentajaDTO ToDTO(Ventaja v) => new VentajaDTO
        {
            Id = v.Id,
            Nombre = v.Nombre,
            Descripcion = v.Descripcion
        };

        private Ventaja FromDTO(VentajaDTO dto) => new Ventaja
        {
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion
        };
    }
}
