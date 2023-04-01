using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPNetCoreApp.Models;
using Microsoft.AspNetCore.Cors;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class DogovorsController : ControllerBase
    {
        private readonly OperatorContext _context;

        public DogovorsController(OperatorContext context)
        {
            _context = context;
        }

        // GET: api/Dogovors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dogovor>>> GetDogovor()
        {
            return await _context.Dogovor.Include(p => p.Тариф).ToListAsync();
        }

        // GET: api/Dogovors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dogovor>> GetDogovor(int id)
        {
            var dogovor = await _context.Dogovor.FindAsync(id);

            if (dogovor == null)
            {
                return NotFound();
            }

            return dogovor;
        }

        // PUT: api/Dogovor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDogovor(int id, Dogovor dogovor)
        {
            if (id != dogovor.Номер_договора)
            {
                return BadRequest();
            }

            _context.Entry(dogovor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogovorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dogovors
        [HttpPost]
        public async Task<ActionResult<Dogovor>> PostDogovor(Dogovor dogovor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Dogovor.Add(dogovor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDogovor", new { id = dogovor.Номер_договора }, dogovor);
        }

        // DELETE: api/Dogovors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDogovor(int id)
        {
            var dogovor = await _context.Dogovor.FindAsync(id);
            if (dogovor == null)
            {
                return NotFound();
            }

            _context.Dogovor.Remove(dogovor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DogovorExists(int id)
        {
            return _context.Dogovor.Any(e => e.Номер_договора == id);
        }
    }
}