using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineCakeShop.Models;

namespace OnlineCakeShop.Controllers
{
    public class QuantitiesController : Controller
    {
        private readonly CakeContext _context;

        public QuantitiesController(CakeContext context)
        {
            _context = context;
        }

        // GET: Quantities
        public async Task<IActionResult> Index()
        {
            var cakeContext = _context.Quantities.Include(q => q.Cake).Include(q => q.CustomCake);
            return View(await cakeContext.ToListAsync());
        }

        // GET: Quantities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Quantities == null)
            {
                return NotFound();
            }

            var quantity = await _context.Quantities
                .Include(q => q.Cake)
                .Include(q => q.CustomCake)
                .FirstOrDefaultAsync(m => m.QuantityId == id);
            if (quantity == null)
            {
                return NotFound();
            }

            return View(quantity);
        }

        // GET: Quantities/Create
        public IActionResult Create()
        {
            ViewData["CakeId"] = new SelectList(_context.Cakes, "CakeId", "Description");
            ViewData["CustomCakeId"] = new SelectList(_context.CustomCakes, "CustomCakeId", "CustomCakeId");
            return View();
        }

        // POST: Quantities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuantityId,TotalAmount,CakeId,CustomCakeId")] Quantity quantity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quantity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CakeId"] = new SelectList(_context.Cakes, "CakeId", "Description", quantity.CakeId);
            ViewData["CustomCakeId"] = new SelectList(_context.CustomCakes, "CustomCakeId", "CustomCakeId", quantity.CustomCakeId);
            return View(quantity);
        }

        // GET: Quantities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Quantities == null)
            {
                return NotFound();
            }

            var quantity = await _context.Quantities.FindAsync(id);
            if (quantity == null)
            {
                return NotFound();
            }
            ViewData["CakeId"] = new SelectList(_context.Cakes, "CakeId", "Description", quantity.CakeId);
            ViewData["CustomCakeId"] = new SelectList(_context.CustomCakes, "CustomCakeId", "CustomCakeId", quantity.CustomCakeId);
            return View(quantity);
        }

        // POST: Quantities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuantityId,TotalAmount,CakeId,CustomCakeId")] Quantity quantity)
        {
            if (id != quantity.QuantityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quantity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuantityExists(quantity.QuantityId))
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
            ViewData["CakeId"] = new SelectList(_context.Cakes, "CakeId", "Description", quantity.CakeId);
            ViewData["CustomCakeId"] = new SelectList(_context.CustomCakes, "CustomCakeId", "CustomCakeId", quantity.CustomCakeId);
            return View(quantity);
        }

        // GET: Quantities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Quantities == null)
            {
                return NotFound();
            }

            var quantity = await _context.Quantities
                .Include(q => q.Cake)
                .Include(q => q.CustomCake)
                .FirstOrDefaultAsync(m => m.QuantityId == id);
            if (quantity == null)
            {
                return NotFound();
            }

            return View(quantity);
        }

        // POST: Quantities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Quantities == null)
            {
                return Problem("Entity set 'CakeContext.Quantities'  is null.");
            }
            var quantity = await _context.Quantities.FindAsync(id);
            if (quantity != null)
            {
                _context.Quantities.Remove(quantity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuantityExists(int id)
        {
          return _context.Quantities.Any(e => e.QuantityId == id);
        }
    }
}
