using Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ApiPiaget.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _service;
        public AlunoController(IAlunoService service) => _service = service;

        [HttpGet] public async Task<ActionResult<PagedResult<AlunoDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string search = "") => Ok(await _service.GetPagedAsync(page, size, search));
        [HttpGet("{id}")] public async Task<ActionResult<AlunoDto>> GetById(Guid id) => await _service.GetByIdAsync(id) is var a ? Ok(a) : NotFound();
        [HttpPost] public async Task<ActionResult<AlunoDto>> Create([FromBody] AlunoInputDto dto) => !ModelState.IsValid ? BadRequest(ModelState) : CreatedAtAction(nameof(GetById), new { id = (await _service.CreateAsync(dto)).Id }, await _service.CreateAsync(dto));
        [HttpPut("{id}")] public async Task<ActionResult<AlunoDto>> Update(Guid id, [FromBody] AlunoInputDto dto) => !ModelState.IsValid ? BadRequest(ModelState) : await _service.UpdateAsync(id, dto) is var u ? Ok(u) : NotFound();
        [HttpDelete("{id}")] public async Task<IActionResult> Delete(Guid id) => await _service.DeleteAsync(id) ? NoContent() : NotFound();
    }
}
