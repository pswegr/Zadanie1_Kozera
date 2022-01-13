using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zadanie1_Kozera.Data;
using Zadanie1_Kozera.Models;

namespace Zadanie1_Kozera.Controllers
{
    public class TabelkasController : Controller
    {
        private readonly Zadanie1_KozeraContext _context;

        public TabelkasController(Zadanie1_KozeraContext context)
        {
            _context = context;
        }

        // GET: Tabelkas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tabelka.ToListAsync());
        }

        // GET: Tabelkas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelka = await _context.Tabelka
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabelka == null)
            {
                return NotFound();
            }

            return View(tabelka);
        }

        // GET: Tabelkas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tabelkas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dane")] Tabelka tabelka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabelka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tabelka);
        }

        // GET: Tabelkas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelka = await _context.Tabelka.FindAsync(id);
            if (tabelka == null)
            {
                return NotFound();
            }
            return View(tabelka);
        }

        // POST: Tabelkas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dane")] Tabelka tabelka)
        {
            if (id != tabelka.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabelka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabelkaExists(tabelka.Id))
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
            return View(tabelka);
        }

        // GET: Tabelkas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabelka = await _context.Tabelka
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabelka == null)
            {
                return NotFound();
            }

            return View(tabelka);
        }

        // POST: Tabelkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tabelka = await _context.Tabelka.FindAsync(id);
            _context.Tabelka.Remove(tabelka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TabelkaExists(int id)
        {
            return _context.Tabelka.Any(e => e.Id == id);
        }
    }
}
