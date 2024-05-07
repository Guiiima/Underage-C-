using Microsoft.AspNetCore.Mvc;
using Underage.models;
using Underage.data;
using Microsoft.EntityFrameworkCore;

namespace Underage.Controllers;

[ApiController]
[Route("[controller]")]
public class UnderageController : ControllerBase
{
    private UnderageDbContext _context;

    public UnderageController(UnderageDbContext context) {
        _context = context;
    }

      [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<DadosPessoais>>> GetUnderage()
        {
            if (_context is null || _context.DadosPessoais is null)
                return NotFound();

            var underages = await _context.DadosPessoais.ToListAsync();
            return Ok(underages);
        }
        [HttpPost]
        [Route("new")]
        public async Task<ActionResult<DadosPessoais>> PostEvent([FromForm] DadosPessoais dados)
        {
            if (_context is null || _context.DadosPessoais is null)
                return NotFound();

            _context.DadosPessoais.Add(dados);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUnderage), new { id = dados.Id }, dados);
        }
}
