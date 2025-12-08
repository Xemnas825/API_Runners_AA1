using Microsoft.AspNetCore.Mvc;
using RunnerApi.Interfaces;
using RunnerApi.DTOs;

namespace RunnerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RunnerController : ControllerBase
    {
        private readonly IRunnerService _service;

        public RunnerController(IRunnerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RunnerDTO dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RunnerDTO dto) // Agregado [FromBody] por buenas prácticas
        {
            // Validar que el ID de la URL coincida con el del DTO si viene incluido (opcional pero recomendado)
            if(dto.Id != 0 && dto.Id != id) 
                return BadRequest("El ID de la URL no coincide con el del cuerpo");

            var updated = await _service.UpdateAsync(id, dto);

            // Si el servicio devuelve null, es que el ID no existía
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
