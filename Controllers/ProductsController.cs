using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fashioninventorysystem.Models;

namespace Fashioninventorysystem.Controllers
{
    public class ProductsController : Controller
    {
        private readonly FashionContext _context;

        public ProductsController(FashionContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var product = await _context.Product.FirstOrDefaultAsync(m => m.Product_id == id);
            if (product == null) return NotFound();

            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Product_id,Product_name,Product_description,Product_category,Product_quantity,Size,Price,Brand,Color")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.DateAdded = DateTime.Now;
                product.LastUpdated = DateTime.Now;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var product = await _context.Product.FindAsync(id);
            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Product_id,Product_name,Product_description,Product_category,Product_quantity,Size,Price,Brand,Color")] Product product)
        {
            if (id != product.Product_id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    product.LastUpdated = DateTime.Now;
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Product_id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var product = await _context.Product.FirstOrDefaultAsync(m => m.Product_id == id);
            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null) _context.Product.Remove(product);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Product_id == id);
        }
    }
}
