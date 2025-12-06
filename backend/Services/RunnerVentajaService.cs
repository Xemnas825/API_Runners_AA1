using RunnerApi.Interfaces;
using RunnerApi.Models;
using RunnerApi.DTOs;

namespace RunnerApi.Services
{
    public class RunnerVentajaService : IRunnerVentajaService
    {
        private readonly IRunnerVentajaRepository _repo;

        public RunnerVentajaService(IRunnerVentajaRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<RunnerVentajaDTO>> GetAllAsync()
        {
            var list = await _repo.GetAllAsync();
            return list.Select(ToDTO);
        }

        public async Task<RunnerVentajaDTO> GetAsync(int runnerId, int ventajaId)
        {
            var entity = await _repo.GetAsync(runnerId, ventajaId);
            return entity == null ? null : ToDTO(entity);
        }

        public async Task<RunnerVentajaDTO> CreateAsync(RunnerVentajaDTO dto)
        {
            var entity = FromDTO(dto);
            var created = await _repo.CreateAsync(entity);
            return ToDTO(created);
        }

        public async Task<bool> DeleteAsync(int runnerId, int ventajaId)
        {
            return await _repo.DeleteAsync(runnerId, ventajaId);
        }

        private RunnerVentajaDTO ToDTO(RunnerVentaja rv) => new RunnerVentajaDTO
        {
            RunnerId = rv.RunnerId,
            VentajaId = rv.VentajaId,
            FechaObtencion = rv.FechaObtencion
        };

        private RunnerVentaja FromDTO(RunnerVentajaDTO dto) => new RunnerVentaja
        {
            RunnerId = dto.runnerId,
            VentajaId = dto.ventajaId,
            FechaObtencion = dto.FechaObtencion
        };
    }
}
