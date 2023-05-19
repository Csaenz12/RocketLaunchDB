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
    public class LaunchSitesController : ControllerBase
    {
        private readonly RocketLaunchDbContext _context;

        public LaunchSitesController(RocketLaunchDbContext context)
        {
            _context = context;
        }

        // GET: api/LaunchSites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LaunchSite>>> GetLaunchSites()
        {
            return await _context.LaunchSites.ToListAsync();
        }

        // GET: api/LaunchSites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LaunchSite>> GetLaunchSite(int id)
        {
            var launchSite = await _context.LaunchSites.FindAsync(id);

            if (launchSite == null)
            {
                return NotFound();
            }

            return launchSite;
        }

        // PUT: api/LaunchSites/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLaunchSite(int id, LaunchSite launchSite)
        {
            if (id != launchSite.Id)
            {
                return BadRequest();
            }

            _context.Entry(launchSite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaunchSiteExists(id))
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

        // POST: api/LaunchSites
        [HttpPost]
        public async Task<ActionResult<LaunchSite>> CreateLaunchSite(LaunchSite launchSite)
        {
            _context.LaunchSites.Add(launchSite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLaunchSite", new { id = launchSite.Id }, launchSite);
        }

        // DELETE: api/LaunchSites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLaunchSite(int id)
        {
            var launchSite = await _context.LaunchSites.FindAsync(id);
            if (launchSite == null)
            {
                return NotFound();
            }

            _context.LaunchSites.Remove(launchSite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LaunchSiteExists(int id)
        {
            return _context.LaunchSites.Any(e => e.Id == id);
        }
    }
}