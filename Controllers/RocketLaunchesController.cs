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
    public class RocketLaunchesController : ControllerBase
    {
        private readonly RocketLaunchDbContext _context;

        public RocketLaunchesController(RocketLaunchDbContext context)
        {
            _context = context;
        }

        // GET: api/RocketLaunches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RocketLaunch>>> GetRocketLaunches()
        {
            return await _context.RocketLaunches.ToListAsync();
        }

        // GET: api/RocketLaunches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RocketLaunch>> GetRocketLaunch(int id)
        {
            var rocketLaunch = await _context.RocketLaunches.FindAsync(id);

            if (rocketLaunch == null)
            {
                return NotFound();
            }

            return rocketLaunch;
        }

        // PUT: api/RocketLaunches/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRocketLaunch(int id, RocketLaunch rocketLaunch)
        {
            if (id != rocketLaunch.Id)
            {
                return BadRequest();
            }

            _context.Entry(rocketLaunch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RocketLaunchExists(id))
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

        // POST: api/RocketLaunches
        [HttpPost]
        public async Task<ActionResult<RocketLaunch>> CreateRocketLaunch(RocketLaunch rocketLaunch)
        {
            _context.RocketLaunches.Add(rocketLaunch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRocketLaunch", new { id = rocketLaunch.Id }, rocketLaunch);
        }

        // DELETE: api/RocketLaunches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRocketLaunch(int id)
        {
            var rocketLaunch = await _context.RocketLaunches.FindAsync(id);
            if (rocketLaunch == null)
            {
                return NotFound();
            }

            _context.RocketLaunches.Remove(rocketLaunch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RocketLaunchExists(int id)
        {
            return _context.RocketLaunches.Any(e => e.Id == id);
        }
    }
}