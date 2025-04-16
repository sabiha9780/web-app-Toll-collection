using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppTollCollection.Data;
using WebAppTollCollection.Models;

namespace WebAppTollCollection.Controllers
{
    [Authorize]
    public class TollPlazasController : Controller
    {
        private readonly Appdatabase _context;

        public TollPlazasController(Appdatabase context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _context.TollPlazas.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tollPlaza = await _context.TollPlazas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tollPlaza == null)
            {
                return NotFound();
            }

            return View(tollPlaza);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Location,Name")] TollPlaza tollPlaza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tollPlaza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tollPlaza);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tollPlaza = await _context.TollPlazas.FindAsync(id);
            if (tollPlaza == null)
            {
                return NotFound();
            }
            return View(tollPlaza);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Location,Name")] TollPlaza tollPlaza)
        {
            if (id != tollPlaza.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tollPlaza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TollPlazaExists(tollPlaza.Id))
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
            return View(tollPlaza);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tollPlaza = await _context.TollPlazas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tollPlaza == null)
            {
                return NotFound();
            }

            return View(tollPlaza);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tollPlaza = await _context.TollPlazas.FindAsync(id);
            if (tollPlaza != null)
            {
                _context.TollPlazas.Remove(tollPlaza);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TollPlazaExists(int id)
        {
            return _context.TollPlazas.Any(e => e.Id == id);
        }
    }
}
