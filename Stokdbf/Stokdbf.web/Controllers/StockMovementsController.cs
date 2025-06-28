using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stokdbf.data.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stokdbf.web.Controllers
{
    public class StockMovementsController : Controller
    {
        private readonly StokTakipDbContext _context;

        public StockMovementsController(StokTakipDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var movements = await _context.StockMovements
                .Include(m => m.Product)
                .OrderByDescending(m => m.MovementDate)
                .ToListAsync();
            return View(movements);
        }

        public IActionResult Create()
        {
            ViewBag.Products = _context.Products.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StockMovement movement)
        {
            if (ModelState.IsValid)
            {
                var product = await _context.Products.FindAsync(movement.ProductId);
                if (product == null) return NotFound();

                if (movement.MovementType == "In")
                    product.Quantity += movement.Quantity;
                else if (movement.MovementType == "Out")
                    product.Quantity -= movement.Quantity;

                movement.MovementDate = DateTime.Now;

                _context.StockMovements.Add(movement);
                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Products = _context.Products.ToList();
            return View(movement);
        }
    }
}

