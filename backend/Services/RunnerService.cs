using RunnerApi.Interfaces;
using RunnerApi.Models;
using RunnerApi.DTOs;

namespace RunnerApi.Services
{
    public class RunnerService : IRunnerService
    {
        private readonly IRunnerRepository _repo;

        public RunnerService(IRunnerRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<RunnerDTO>> GetAllAsync()
            => (await _repo.GetAllAsync()).Select(ToDTO);

        public async Task<RunnerDTO> GetByIdAsync(int id)
        {
            var r = await _repo.GetByIdAsync(id);
            return r == null ? null : ToDTO(r);
        }

        public async Task<RunnerDTO> CreateAsync(RunnerDTO dto)
        {
            var entity = FromDTO(dto);
            var result = await _repo.CreateAsync(entity);
            return ToDTO(result);
        }

        public async Task<RunnerDTO> UpdateAsync(int id, RunnerDTO dto)
        {
            var entity = FromDTO(dto);
            entity.Id = id;
            var result = await _repo.UpdateAsync(entity);
            return ToDTO(result);
        }

        public async Task<bool> DeleteAsync(int id)
            => await _repo.DeleteAsync(id);

        private RunnerDTO ToDTO(Runner r) => new RunnerDTO
        {
            Id = r.Id,
            Nombre = r.Nombre,
            Apellido = r.Apellido,
            Dni = r.Dni,
            Correo = r.Correo,
            Contrasena = r.Contrasena,
            Valido = r.Valido,
            GrupoId = r.GrupoId
        };

        private Runner FromDTO(RunnerDTO dto) => new Runner
        {
            Nombre = dto.Nombre,
            Apellido = dto.Apellido,
            Dni = dto.Dni,
            Correo = dto.Correo,
            Contrasena = dto.Contrasena,
            Valido = dto.Valido,
            GrupoId = dto.GrupoId
        };
    }
}
