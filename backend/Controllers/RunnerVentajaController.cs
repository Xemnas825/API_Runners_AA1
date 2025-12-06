using Microsoft.AspNetCore.Mvc;
using RunnerApi.Interfaces;
using RunnerApi.DTOs;

namespace RunnerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RunnerVentajaController : ControllerBase
    {
        private readonly IRunnerVentajaService _service;

        public RunnerVentajaController(IRunnerVentajaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{runnerId}/{ventajaId}")]
        public async Task<IActionResult> Get(int runnerId, int ventajaId)
        {
            var result = await _service.GetAsync(runnerId, ventajaId);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RunnerVentajaDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { runnerId = created.RunnerId, ventajaId = created.VentajaId }, created);
        }

        [HttpDelete("{runnerId}/{ventajaId}")]
        public async Task<IActionResult> Delete(int runnerId, int ventajaId)
        {
            var deleted = await _service.DeleteAsync(runnerId, ventajaId);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
