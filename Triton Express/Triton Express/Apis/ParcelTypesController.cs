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
    public class ParcelTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParcelTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ParcelTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParcelType>>> GetParcelTypes()
        {
            return await _context.ParcelTypes.ToListAsync();
        }

        // GET: api/ParcelTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParcelType>> GetParcelType(int id)
        {
            var parcelType = await _context.ParcelTypes.FindAsync(id);

            if (parcelType == null)
            {
                return NotFound();
            }

            return parcelType;
        }

        // PUT: api/ParcelTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParcelType(int id, ParcelType parcelType)
        {
            if (id != parcelType.Id)
            {
                return BadRequest();
            }

            _context.Entry(parcelType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParcelTypeExists(id))
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

        // POST: api/ParcelTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ParcelType>> PostParcelType(ParcelType parcelType)
        {
            _context.ParcelTypes.Add(parcelType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParcelType", new { id = parcelType.Id }, parcelType);
        }

        // DELETE: api/ParcelTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ParcelType>> DeleteParcelType(int id)
        {
            var parcelType = await _context.ParcelTypes.FindAsync(id);
            if (parcelType == null)
            {
                return NotFound();
            }

            _context.ParcelTypes.Remove(parcelType);
            await _context.SaveChangesAsync();

            return parcelType;
        }

        private bool ParcelTypeExists(int id)
        {
            return _context.ParcelTypes.Any(e => e.Id == id);
        }
    }
}
