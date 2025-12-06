using RunnerApi.Interfaces;
using RunnerApi.Models;
using RunnerApi.DTOs;

namespace RunnerApi.Services
{
    public class GrupoSocialService : IGrupoSocialService
    {
        private readonly IGrupoSocialRepository _repo;

        public GrupoSocialService(IGrupoSocialRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<GrupoSocialDTO>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(ToDTO);
        }

        public async Task<GrupoSocialDTO> GetByIdAsync(int id)
        {
            var g = await _repo.GetByIdAsync(id);
            return g == null ? null : ToDTO(g);
        }

        public async Task<GrupoSocialDTO> CreateAsync(GrupoSocialDTO dto)
        {
            var entity = FromDTO(dto);
            var result = await _repo.CreateAsync(entity);
            return ToDTO(result);
        }

        public async Task<GrupoSocialDTO> UpdateAsync(int id, GrupoSocialDTO dto)
        {
            var entity = FromDTO(dto);
            entity.Id = id;

            var result = await _repo.UpdateAsync(entity);
            return ToDTO(result);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        private GrupoSocialDTO ToDTO(GrupoSocial g) => new GrupoSocialDTO
        {
            Id = g.Id,
            Nombre = g.Nombre,
            Region = g.Region,
            Puntos = g.Puntos,
            Nivel = g.Nivel,
            FechaCreacion = g.FechaCreacion
        };

        private GrupoSocial FromDTO(GrupoSocialDTO dto) => new GrupoSocial
        {
            Nombre = dto.Nombre,
            Region = dto.Region,
            Puntos = dto.Puntos,
            Nivel = dto.Nivel,
            FechaCreacion = dto.FechaCreacion
        };
    }
}
