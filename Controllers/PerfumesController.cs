using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PerfumePro.Data;
using PerfumePro.Models;

namespace PerfumePro.Controllers
{
    public class PerfumesController : Controller
    {
        private readonly PerfumeProContext _context;

        public PerfumesController(PerfumeProContext context)
        {
            _context = context;
        }

        // GET: Perfumes
        public async Task<IActionResult> Index(string perfumeBrand, string searchString)
        {
            // Use LINQ to get list of brands.
            IQueryable<string> brandQuery = from p in _context.Perfume
                                            orderby p.Brand
                                            select p.Brand;

            var perfumes = from p in _context.Perfume
                           select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                perfumes = perfumes.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(perfumeBrand))
            {
                perfumes = perfumes.Where(x => x.Brand == perfumeBrand);
            }

            var perfumeBrandVM = new PerfumeBrandViewModel
            {
                Brands = new SelectList(await brandQuery.Distinct().ToListAsync()),
                Perfumes = await perfumes.ToListAsync()
            };

            return View(perfumeBrandVM);
        }        // GET: Perfumes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfume = await _context.Perfume
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfume == null)
            {
                return NotFound();
            }

            return View(perfume);
        }

        // GET: Perfumes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Perfumes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Brand,Fragrance,Gender,Country,Price")] Perfume perfume)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perfume);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(perfume);
        }

        // GET: Perfumes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfume = await _context.Perfume.FindAsync(id);
            if (perfume == null)
            {
                return NotFound();
            }
            return View(perfume);
        }

        // POST: Perfumes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Brand,Fragrance,Gender,Country,Rating")] Perfume perfume)
        {
            if (id != perfume.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perfume);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerfumeExists(perfume.Id))
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
            return View(perfume);
        }

        // GET: Perfumes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfume = await _context.Perfume
                .FirstOrDefaultAsync(m => m.Id == id);
            if (perfume == null)
            {
                return NotFound();
            }

            return View(perfume);
        }

        // POST: Perfumes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perfume = await _context.Perfume.FindAsync(id);
            _context.Perfume.Remove(perfume);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerfumeExists(int id)
        {
            return _context.Perfume.Any(e => e.Id == id);
        }
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
    }
}
