using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zadanie1_Kozera.Data;
using Zadanie1_Kozera.Models;
using Zadanie1_Kozera.Models.SchoolViewModels;

namespace Zadanie1_Kozera.Controllers
{
    public class JobHierarchiesController : Controller
    {
        private readonly Zadanie1_KozeraContext _context;

        public JobHierarchiesController(Zadanie1_KozeraContext context)
        {
            _context = context;
        }

        // GET: JobHierarchies
        public async Task<IActionResult> Index()
        {
            List<JobHierarchyViewModel> jobHierarchyViewModels = new List<JobHierarchyViewModel>();
            List<JobHierarchy> jobHierarchies = await _context.jobHierarchies.ToListAsync();

            foreach(var jobHierarchy in jobHierarchies)
            {
                var boss = _context.Jobs.FirstOrDefault(x => x.Id == jobHierarchy.BossId);
                var subordinate = _context.Jobs.FirstOrDefault(x => x.Id == jobHierarchy.SubordinateId);
                if(boss != null && subordinate != null)
                {
                    var jobHierarchyViewModel = new JobHierarchyViewModel
                    {
                        BossName = boss.Name,
                        Subordinate = subordinate.Name,
                        JobHierarchy = jobHierarchy
                    };
                    jobHierarchyViewModels.Add(jobHierarchyViewModel);
                }
                else
                {
                    _context.jobHierarchies.Remove(jobHierarchy);
                    _context.SaveChanges();
                }
            }


            return View(jobHierarchyViewModels);
        }

        // GET: JobHierarchies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobHierarchy = await _context.jobHierarchies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobHierarchy == null)
            {
                return NotFound();
            }

            return View(jobHierarchy);
        }

        // GET: JobHierarchies/Create
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        // POST: JobHierarchies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BossId,SubordinateId")] JobHierarchy jobHierarchy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobHierarchy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            SetViewData(jobHierarchy);
            return View(jobHierarchy);
        }

        private void SetViewData(JobHierarchy jobHierarchy = null)
        {
            if (jobHierarchy == null)
            {
                ViewData["BossId"] = new SelectList(_context.Jobs, "Id", "Name");
                ViewData["SubordinateId"] = new SelectList(_context.Teams, "Id", "Name");
            }
            else
            {
                ViewData["BossId"] = new SelectList(_context.Jobs, "Id", "Name", jobHierarchy.BossId);
                ViewData["SubordinateId"] = new SelectList(_context.Teams, "Id", "Name", jobHierarchy.SubordinateId);
            }
        }

        // GET: JobHierarchies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobHierarchy = await _context.jobHierarchies.FindAsync(id);
            if (jobHierarchy == null)
            {
                return NotFound();
            }
            SetViewData(jobHierarchy);
            return View(jobHierarchy);
        }

        // POST: JobHierarchies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BossId,SubordinateId")] JobHierarchy jobHierarchy)
        {
            if (id != jobHierarchy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobHierarchy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobHierarchyExists(jobHierarchy.Id))
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
            return View(jobHierarchy);
        }

        // GET: JobHierarchies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobHierarchy = await _context.jobHierarchies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobHierarchy == null)
            {
                return NotFound();
            }
            return View(jobHierarchy);
        }

        // POST: JobHierarchies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobHierarchy = await _context.jobHierarchies.FindAsync(id);
            _context.jobHierarchies.Remove(jobHierarchy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobHierarchyExists(int id)
        {
            return _context.jobHierarchies.Any(e => e.Id == id);
        }
    }
}
