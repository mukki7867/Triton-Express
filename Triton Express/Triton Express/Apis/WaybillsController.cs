using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Triton_Express.Data;
using Triton_Express.Models;

namespace Triton_Express.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaybillsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WaybillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Waybills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Waybill>>> GetWaybills()
        {
            return await _context.Waybills.ToListAsync();
        }

        // GET: api/Waybills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Waybill>> GetWaybill(int id)
        {
            var waybill = await _context.Waybills.FindAsync(id);

            if (waybill == null)
            {
                return NotFound();
            }

            return waybill;
        }

        // PUT: api/Waybills/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWaybill(int id, Waybill waybill)
        {
            if (id != waybill.Id)
            {
                return BadRequest();
            }

            _context.Entry(waybill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WaybillExists(id))
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

        // POST: api/Waybills
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Waybill>> PostWaybill(Waybill waybill)
        {
            _context.Waybills.Add(waybill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWaybill", new { id = waybill.Id }, waybill);
        }

        // DELETE: api/Waybills/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Waybill>> DeleteWaybill(int id)
        {
            var waybill = await _context.Waybills.FindAsync(id);
            if (waybill == null)
            {
                return NotFound();
            }

            _context.Waybills.Remove(waybill);
            await _context.SaveChangesAsync();

            return waybill;
        }

        private bool WaybillExists(int id)
        {
            return _context.Waybills.Any(e => e.Id == id);
        }
    }
}
