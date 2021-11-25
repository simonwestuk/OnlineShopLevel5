using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop2022.Data;
using OnlineShop2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop2022.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;

        public ProductController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _db.Products.ToListAsync();
            return View(products);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductModel product)
        {

            if (ModelState.IsValid)
            {
                await _db.Products.AddAsync(product);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, ProductModel product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Products.Update(product);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return NotFound();
                }
            }
            return View(product);
        }

        //GET
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductModel currentProduct = await _db.Products.FindAsync(id);

            if (currentProduct == null)
            {
                return NotFound();
            }

            return View(currentProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, ProductModel model)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductModel productToDelete = await _db.Products.FindAsync(id);

            if (productToDelete == null)
            {
                return NotFound();
            }

             _db.Products.Remove(productToDelete);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }



        //GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductModel currentProduct = await _db.Products.FindAsync(id);

            if (currentProduct == null)
            {
                return NotFound();
            }

            return View(currentProduct);
        }



    }
}
