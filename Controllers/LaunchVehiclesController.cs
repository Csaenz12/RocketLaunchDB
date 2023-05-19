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
    public class LaunchVehiclesController : ControllerBase
    {
        private readonly RocketLaunchDbContext _context;

        public LaunchVehiclesController(RocketLaunchDbContext context)
        {
            _context = context;
        }

        // GET: api/LaunchVehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LaunchVehicle>>> GetLaunchVehicles()
        {
            return await _context.LaunchVehicles.ToListAsync();
        }

        // GET: api/LaunchVehicles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LaunchVehicle>> GetLaunchVehicle(int id)
        {
            var launchVehicle = await _context.LaunchVehicles.FindAsync(id);

            if (launchVehicle == null)
            {
                return NotFound();
            }

            return launchVehicle;
        }

        // PUT: api/LaunchVehicles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLaunchVehicle(int id, LaunchVehicle launchVehicle)
        {
            if (id != launchVehicle.Id)
            {
                return BadRequest();
            }

            _context.Entry(launchVehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaunchVehicleExists(id))
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

        // POST: api/LaunchVehicles
        [HttpPost]
        public async Task<ActionResult<LaunchVehicle>> CreateLaunchVehicle(LaunchVehicle launchVehicle)
        {
            _context.LaunchVehicles.Add(launchVehicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLaunchVehicle", new { id = launchVehicle.Id }, launchVehicle);
        }

        // DELETE: api/LaunchVehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLaunchVehicle(int id)
        {
            var launchVehicle = await _context.LaunchVehicles.FindAsync(id);
            if (launchVehicle == null)
            {
                return NotFound();
            }

            _context.LaunchVehicles.Remove(launchVehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LaunchVehicleExists(int id)
        {
            return _context.LaunchVehicles.Any(e => e.Id == id);
        }
    }
}