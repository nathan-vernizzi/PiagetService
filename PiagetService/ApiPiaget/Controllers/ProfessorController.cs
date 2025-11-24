using Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ApiPiaget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _service;
        public ProfessorController(IProfessorService service) => _service = service;

        [HttpGet] public async Task<ActionResult<IEnumerable<ProfessorDto>>> GetAll() => Ok(await _service.GetAllAsync());
        [HttpGet("{id}")] public async Task<ActionResult<ProfessorDto>> GetById(Guid id) => await _service.GetByIdAsync(id) is var p ? Ok(p) : NotFound();
        [HttpPost] public async Task<ActionResult<ProfessorDto>> Create([FromBody] ProfessorInputDto dto) => !ModelState.IsValid ? BadRequest(ModelState) : CreatedAtAction(nameof(GetById), new { id = (await _service.CreateAsync(dto)).Id }, await _service.CreateAsync(dto));
        [HttpPut("{id}")] public async Task<ActionResult<ProfessorDto>> Update(Guid id, [FromBody] ProfessorInputDto dto) => !ModelState.IsValid ? BadRequest(ModelState) : await _service.UpdateAsync(id, dto) is var u ? Ok(u) : NotFound();
        [HttpDelete("{id}")] public async Task<IActionResult> Delete(Guid id) => await _service.DeleteAsync(id) ? NoContent() : NotFound();
    }
}
