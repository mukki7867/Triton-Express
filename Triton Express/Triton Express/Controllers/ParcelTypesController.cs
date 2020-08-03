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
    public class ParcelTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParcelTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ParcelTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParcelTypes.ToListAsync());
        }

        // GET: ParcelTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcelType = await _context.ParcelTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parcelType == null)
            {
                return NotFound();
            }

            return View(parcelType);
        }

        // GET: ParcelTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParcelTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Key,Id,IsActive,IsDeleted,IsLocked,CreatedBySystemUserId,CreatedDateTime,ModifiedBySystemUserId,ModifiedDateTime")] ParcelType parcelType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parcelType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parcelType);
        }

        // GET: ParcelTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcelType = await _context.ParcelTypes.FindAsync(id);
            if (parcelType == null)
            {
                return NotFound();
            }
            return View(parcelType);
        }

        // POST: ParcelTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,Key,Id,IsActive,IsDeleted,IsLocked,CreatedBySystemUserId,CreatedDateTime,ModifiedBySystemUserId,ModifiedDateTime")] ParcelType parcelType)
        {
            if (id != parcelType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parcelType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParcelTypeExists(parcelType.Id))
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
            return View(parcelType);
        }

        // GET: ParcelTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcelType = await _context.ParcelTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parcelType == null)
            {
                return NotFound();
            }

            return View(parcelType);
        }

        // POST: ParcelTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parcelType = await _context.ParcelTypes.FindAsync(id);
            _context.ParcelTypes.Remove(parcelType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParcelTypeExists(int id)
        {
            return _context.ParcelTypes.Any(e => e.Id == id);
        }
    }
}
