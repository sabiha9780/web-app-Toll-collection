using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppTollCollection.Data;
using WebAppTollCollection.Models;

namespace WebAppTollCollection.Controllers
{
    public class TollRecordsController : Controller
    {
        private readonly Appdatabase _context;

        public TollRecordsController(Appdatabase context)
        {
            _context = context;
        }

     
        public async Task<IActionResult> Index()
        {
            var appdatabase = _context.TollRecords.Include(t => t.TollPlaza).Include(t => t.Vehicle);
            return View(await appdatabase.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tollRecord = await _context.TollRecords
                .Include(t => t.TollPlaza)
                .Include(t => t.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tollRecord == null)
            {
                return NotFound();
            }

            return View(tollRecord);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["TollPlazaId"] = new SelectList(_context.TollPlazas, "Id", "Location");
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "LicensePlate");
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VehicleId,TollPlazaId,Timestamp,Amount")] TollRecord tollRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tollRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TollPlazaId"] = new SelectList(_context.TollPlazas, "Id", "Location", tollRecord.TollPlazaId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "LicensePlate", tollRecord.VehicleId);
            return View(tollRecord);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tollRecord = await _context.TollRecords.FindAsync(id);
            if (tollRecord == null)
            {
                return NotFound();
            }
            ViewData["TollPlazaId"] = new SelectList(_context.TollPlazas, "Id", "Location", tollRecord.TollPlazaId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "LicensePlate", tollRecord.VehicleId);
            return View(tollRecord);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VehicleId,TollPlazaId,Timestamp,Amount")] TollRecord tollRecord)
        {
            if (id != tollRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tollRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TollRecordExists(tollRecord.Id))
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
            ViewData["TollPlazaId"] = new SelectList(_context.TollPlazas, "Id", "Location", tollRecord.TollPlazaId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "Id", "LicensePlate", tollRecord.VehicleId);
            return View(tollRecord);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tollRecord = await _context.TollRecords
                .Include(t => t.TollPlaza)
                .Include(t => t.Vehicle)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tollRecord == null)
            {
                return NotFound();
            }

            return View(tollRecord);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tollRecord = await _context.TollRecords.FindAsync(id);
            if (tollRecord != null)
            {
                _context.TollRecords.Remove(tollRecord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TollRecordExists(int id)
        {
            return _context.TollRecords.Any(e => e.Id == id);
        }
    }
}
