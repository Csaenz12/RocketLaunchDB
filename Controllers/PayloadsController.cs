using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Launch_Database__2_.Data;
using Rocket_Launch_Database__2_.Models;

namespace Rocket_Launch_Database__2_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayloadsController : ControllerBase
    {
        private readonly RocketLaunchDbContext _context;

        public PayloadsController(RocketLaunchDbContext context)
        {
            _context = context;
        }

        // GET: api/Payloads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payload>>> GetPayloads()
        {
            return await _context.Payloads.ToListAsync();
        }

        // GET: api/Payloads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payload>> GetPayload(int id)
        {
            var payload = await _context.Payloads.FindAsync(id);

            if (payload == null)
            {
                return NotFound();
            }

            return payload;
        }

        // PUT: api/Payloads/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayload(int id, Payload payload)
        {
            if (id != payload.Id)
            {
                return BadRequest();
            }

            _context.Entry(payload).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayloadExists(id))
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

        // POST: api/Payloads
        [HttpPost]
        public async Task<ActionResult<Payload>> CreatePayload(Payload payload)
        {
            _context.Payloads.Add(payload);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayload", new { id = payload.Id }, payload);
        }

        // DELETE: api/Payloads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayload(int id)
        {
            var payload = await _context.Payloads.FindAsync(id);
            if (payload == null)
            {
                return NotFound();
            }

            _context.Payloads.Remove(payload);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PayloadExists(int id)
        {
            return _context.Payloads.Any(e => e.Id == id);
        }
    }
}