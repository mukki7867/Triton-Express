using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Triton_Express.Data;
using Triton_Express.Models;

namespace Triton_Express.Controllers
{
    public class WaybillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WaybillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Waybills
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Waybills.Include(w => w.Branch).Include(w => w.Vehicle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Waybills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waybill = await _context.Waybills
                .Include(w => w.Branch)
                .Include(w => w.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waybill == null)
            {
                return NotFound();
            }

            return View(waybill);
        }

        // GET: Waybills/Create
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "BranchCity");
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "RegistrationNo");
            return View();
        }

        // POST: Waybills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TotalWeight,TotalNumberofParcels,VehicleId,BranchId,Id,IsActive,IsDeleted,IsLocked,CreatedBySystemUserId,CreatedDateTime,ModifiedBySystemUserId,ModifiedDateTime")] Waybill waybill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(waybill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Id", waybill.BranchId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", waybill.VehicleId);
            return View(waybill);
        }

        // GET: Waybills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waybill = await _context.Waybills.FindAsync(id);
            if (waybill == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "BranchCity", waybill.BranchId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "RegistrationNo", waybill.VehicleId);
            return View(waybill);
        }

        // POST: Waybills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TotalWeight,TotalNumberofParcels,VehicleId,BranchId,Id,IsActive,IsDeleted,IsLocked,CreatedBySystemUserId,CreatedDateTime,ModifiedBySystemUserId,ModifiedDateTime")] Waybill waybill)
        {
            if (id != waybill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(waybill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaybillExists(waybill.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Id", waybill.BranchId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "Id", waybill.VehicleId);
            return View(waybill);
        }

        // GET: Waybills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waybill = await _context.Waybills
                .Include(w => w.Branch)
                .Include(w => w.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waybill == null)
            {
                return NotFound();
            }

            return View(waybill);
        }

        // POST: Waybills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var waybill = await _context.Waybills.FindAsync(id);
            _context.Waybills.Remove(waybill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WaybillExists(int id)
        {
            return _context.Waybills.Any(e => e.Id == id);
        }
    }
}
