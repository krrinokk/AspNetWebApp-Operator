using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using ASPNetCoreApp.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ASPNetCoreApp.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    public class КлиентsController : ControllerBase
    {
        private readonly OperatorContext _context;

        public КлиентsController(OperatorContext context)
        {
            _context = context;
            if (_context.Клиент.Count() == 0)
            {
                _context.Клиент.Add(new Клиент
                {
                     Баланс=1,
                    Номер_клиента = 1,
                     ФИО = "Иванов И.И."
                       
                   
                });
                _context.SaveChanges();

            }
        }

        [HttpGet]
        public IEnumerable<Клиент> GetAll()
        {
            return _context.Клиент;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetКлиент([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Клиент = await _context.Клиент.SingleOrDefaultAsync(m => m.Номер_клиента == id);

            if (Клиент == null)
            {
                return NotFound();
            }

            return Ok(Клиент);
        }

        [HttpPost]
      //  [Authorize(Roles = "user")]
        public async Task<IActionResult> Create([FromBody] Клиент Клиент)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Клиент.Add(Клиент);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetКлиент", new { Код_Клиента = Клиент.Номер_клиента }, Клиент);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Клиент Клиент)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Клиент.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            item.Номер_клиента = Клиент.Номер_клиента;
            _context.Клиент.Update(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
     //   [Authorize(Roles = "user")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Клиент.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Клиент.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}