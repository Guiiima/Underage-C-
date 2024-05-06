using Microsoft.AspNetCore.Mvc;
using Underage.models;
namespace Underage.Controllers;

[ApiController]
[Route("[controller]")]
public class underageController : ControllerBase
{
      [HttpGet]
        [Route("all")]
        public async Task<ActionResult<IEnumerable<DadosPessoais>>> GetUnderage()
        {
            if (_context is null || _context.Event is null)
                return NotFound();

            return await _context.Event.ToListAsync();
        }
        [HttpPost]
        [Route("new")]
        public async Task<ActionResult<DadosPessoais>> PostEvent([FromForm]DadosPessoais evento)
        {
            if (_context is null || _context.Event is null)
                return NotFound();

            _context.Event.Add(evento);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUnderage), new { id = evento.Id }, evento);
        }
}
