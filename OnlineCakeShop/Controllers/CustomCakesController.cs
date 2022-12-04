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
    public class CustomCakesController : Controller
    {
        private readonly CakeContext _context;

        public CustomCakesController(CakeContext context)
        {
            _context = context;
        }

        // GET: CustomCakes
        public async Task<IActionResult> Index()
        {
              return View(await _context.CustomCakes.ToListAsync());
        }

        // GET: CustomCakes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CustomCakes == null)
            {
                return NotFound();
            }

            var customCake = await _context.CustomCakes
                .FirstOrDefaultAsync(m => m.CustomCakeId == id);
            if (customCake == null)
            {
                return NotFound();
            }

            return View(customCake);
        }

        // GET: CustomCakes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomCakes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomCakeId,Chocolate,Peanuts,Apples,Raspberries,WhippedCream,Snickers,Coconut,Cookies,Cherry,Strawberries,Vanilla,Price")] CustomCake customCake)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customCake);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customCake);
        }

        // GET: CustomCakes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CustomCakes == null)
            {
                return NotFound();
            }

            var customCake = await _context.CustomCakes.FindAsync(id);
            if (customCake == null)
            {
                return NotFound();
            }
            return View(customCake);
        }

        // POST: CustomCakes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomCakeId,Chocolate,Peanuts,Apples,Raspberries,WhippedCream,Snickers,Coconut,Cookies,Cherry,Strawberries,Vanilla,Price")] CustomCake customCake)
        {
            if (id != customCake.CustomCakeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customCake);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomCakeExists(customCake.CustomCakeId))
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
            return View(customCake);
        }

        // GET: CustomCakes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CustomCakes == null)
            {
                return NotFound();
            }

            var customCake = await _context.CustomCakes
                .FirstOrDefaultAsync(m => m.CustomCakeId == id);
            if (customCake == null)
            {
                return NotFound();
            }

            return View(customCake);
        }

        // POST: CustomCakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CustomCakes == null)
            {
                return Problem("Entity set 'CakeContext.CustomCakes'  is null.");
            }
            var customCake = await _context.CustomCakes.FindAsync(id);
            if (customCake != null)
            {
                _context.CustomCakes.Remove(customCake);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomCakeExists(int id)
        {
          return _context.CustomCakes.Any(e => e.CustomCakeId == id);
        }
    }
}
