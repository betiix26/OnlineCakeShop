using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineCakeShop.Models;

namespace OnlineCakeShop.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CakesController : Controller
    {
        private readonly CakeContext _context;

        public CakesController(CakeContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        // GET: Cakes
        public async Task<IActionResult> Index()
        {
            var cakeContext = _context.Cakes.Include(c => c.Category);
            return View(await cakeContext.ToListAsync());
        }

        // GET: Cakes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cakes == null)
            {
                return NotFound();
            }

            var cake = await _context.Cakes
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CakeId == id);
            if (cake == null)
            {
                return NotFound();
            }

            return View(cake);
        }

        // GET: Cakes/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: Cakes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CakeId,Name,Description,Price,Image,Date,CategoryId")] Cake cake)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cake);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", cake.CategoryId);
            return View(cake);
        }

        // GET: Cakes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cakes == null)
            {
                return NotFound();
            }

            var cake = await _context.Cakes.FindAsync(id);
            if (cake == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", cake.CategoryId);
            return View(cake);
        }

        // POST: Cakes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CakeId,Name,Description,Price,Image,Date,CategoryId")] Cake cake)
        {
            if (id != cake.CakeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cake);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CakeExists(cake.CakeId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", cake.CategoryId);
            return View(cake);
        }

        // GET: Cakes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cakes == null)
            {
                return NotFound();
            }

            var cake = await _context.Cakes
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CakeId == id);
            if (cake == null)
            {
                return NotFound();
            }

            return View(cake);
        }

        // POST: Cakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cakes == null)
            {
                return Problem("Entity set 'CakeContext.Cakes'  is null.");
            }
            var cake = await _context.Cakes.FindAsync(id);
            if (cake != null)
            {
                _context.Cakes.Remove(cake);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CakeExists(int id)
        {
          return _context.Cakes.Any(e => e.CakeId == id);
        }
    }
}
