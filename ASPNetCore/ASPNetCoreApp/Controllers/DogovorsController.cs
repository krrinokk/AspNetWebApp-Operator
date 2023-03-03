using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using ASPNetCoreApp.Models;
namespace ASPNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogovorsController : ControllerBase
    {
        private readonly OperatorContext _context;

        public DogovorsController(OperatorContext context)
        {
            _context = context;
            if (_context.Dogovor.Count() == 0)
            {
                _context.Dogovor.Add(new Dogovor {
                    Номер_договора = 1,
                    Дата_заключения = DateTime.Today,
                    Дата_расторжения = DateTime.Today,
                    Код_тарифа_FK = 1,
                    Номер_телефона = "1",
                    Номер_клиента_FK = 1,
                    Серийный_номер_сим_карты ="1"
                });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Dogovor> GetAll()
        {
            return _context.Dogovor;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDogovor([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dogovor= await _context.Dogovor.SingleOrDefaultAsync(m => m.Номер_договора == id);

            if (dogovor == null)
            {
                return NotFound();
            }

            return Ok(dogovor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Dogovor dogovor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Dogovor.Add(dogovor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDogovor", new { Номер_договора = dogovor.Номер_договора}, dogovor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Dogovor dogovor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Dogovor.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.Номер_договора = dogovor.Номер_договора;
            _context.Dogovor.Update(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Dogovor.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Dogovor.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}