using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Triton_Express.Data;
using Triton_Express.Models;
using Triton_Express.Keys;
namespace Triton_Express.Controllers
{
    public class ParcelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParcelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Parcels1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Parcels.Include(p => p.Branch).Include(p => p.Customer).Include(p => p.ParcelType).Include(p => p.Waybill);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Parcels1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcel = await _context.Parcels
                .Include(p => p.Branch)
                .Include(p => p.Customer)
                .Include(p => p.ParcelType)
                .Include(p => p.Waybill)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parcel == null)
            {
                return NotFound();
            }

            return View(parcel);
        }

        // GET: Parcels1/Create
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "BranchCity");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "IdentificationNumber");
            ViewData["ParcelTypeId"] = new SelectList(_context.ParcelTypes, "Id", "Name");
            ViewData["WaybillId"] = new SelectList(_context.Waybills, "Id", "Id");
            return View();
        }

        // POST: Parcels1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParcelTypeId,ParcelWeight,Quantity,DimensionsInCm,WaybillNumber,WaybillId,CustomerId,BranchId,Id,IsActive,IsDeleted,IsLocked,CreatedBySystemUserId,CreatedDateTime,ModifiedBySystemUserId,ModifiedDateTime")] Parcel parcel)
        {
            if (ModelState.IsValid)
            {
 
                _context.Add(parcel);
                await _context.SaveChangesAsync();

                var branch = _context.Branches.Where(x => x.Id == parcel.BranchId).FirstOrDefault();
                var Parcel = _context.ParcelTypes.Where(x => x.Id == parcel.ParcelTypeId).FirstOrDefault();


                if (parcel.BranchId == branch.Id)
                {
                    if (Parcel.Key == TritonKeys.SmallParcel)
                    {
                        Branch b = new Branch();
                        b = branch;
                        branch.SmallWaybillCount += 1;
                        await _context.SaveChangesAsync();
                    }
                    else if (Parcel.Key == TritonKeys.MediumParcel)
                    {
                        Branch b = new Branch();
                        b = branch;
                        branch.MediumWaybillCount += 1;
                        await _context.SaveChangesAsync();
                    }
                    else if (Parcel.Key == TritonKeys.LargeParcel)
                    {
                        Branch b = new Branch();
                        b = branch;
                        branch.LargeWaybillCount += 1;
                        await _context.SaveChangesAsync();
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "BranchCity", parcel.BranchId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", parcel.CustomerId);
            ViewData["ParcelTypeId"] = new SelectList(_context.ParcelTypes, "Id", "Name", parcel.ParcelTypeId);
            ViewData["WaybillId"] = new SelectList(_context.Waybills, "Id", "Id", parcel.WaybillId);
            return View(parcel);
        }

        // GET: Parcels1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcel = await _context.Parcels.FindAsync(id);
            if (parcel == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "BranchCity", parcel.BranchId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "IdentificationNumber", parcel.CustomerId);
            ViewData["ParcelTypeId"] = new SelectList(_context.ParcelTypes, "Id", "Name", parcel.ParcelTypeId);
            ViewData["WaybillId"] = new SelectList(_context.Waybills, "Id", "Id", parcel.WaybillId);
            return View(parcel);
        }

        // POST: Parcels1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParcelTypeId,ParcelWeight,Quantity,DimensionsInCm,WaybillNumber,WaybillId,CustomerId,BranchId,Id,IsActive,IsDeleted,IsLocked,CreatedBySystemUserId,CreatedDateTime,ModifiedBySystemUserId,ModifiedDateTime")] Parcel parcel)
        {
            if (id != parcel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parcel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParcelExists(parcel.Id))
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
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "Id", parcel.BranchId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", parcel.CustomerId);
            ViewData["ParcelTypeId"] = new SelectList(_context.ParcelTypes, "Id", "Name", parcel.ParcelTypeId);
            ViewData["WaybillId"] = new SelectList(_context.Waybills, "Id", "Id", parcel.WaybillId);
            return View(parcel);
        }

        // GET: Parcels1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcel = await _context.Parcels
                .Include(p => p.Branch)
                .Include(p => p.Customer)
                .Include(p => p.ParcelType)
                .Include(p => p.Waybill)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parcel == null)
            {
                return NotFound();
            }

            return View(parcel);
        }

        // POST: Parcels1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parcel = await _context.Parcels.FindAsync(id);
            _context.Parcels.Remove(parcel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParcelExists(int id)
        {
            return _context.Parcels.Any(e => e.Id == id);
        }
    }
}
