using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using ASPNetCoreApp.Models;
namespace ASPNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ТарифsController : ControllerBase
    {
        private readonly OperatorContext _context;

        public ТарифsController(OperatorContext context)
        {
            _context = context;
            if (_context.Тариф.Count() == 0)
            {
                _context.Тариф.Add(new Тариф
                {
                   Год_начала=1,
                    Код_тарифа=1,
                     Минута_межгород_стоимость=1,
                      Минута_международная_стоимость=1,
                       Название_тарифа="1",
                        Стоимость_перехода=1
                });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Тариф> GetAll()
        {
            return _context.Тариф;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetТариф([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var тариф = await _context.Тариф.SingleOrDefaultAsync(m => m.Код_тарифа == id);

            if (тариф == null)
            {
                return NotFound();
            }

            return Ok(тариф);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Тариф тариф)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Тариф.Add(тариф);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetТариф", new { Код_тарифа = тариф.Код_тарифа }, тариф);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Тариф тариф)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Тариф.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.Код_тарифа = тариф.Код_тарифа;
            _context.Тариф.Update(item);
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
            var item = _context.Тариф.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Тариф.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}