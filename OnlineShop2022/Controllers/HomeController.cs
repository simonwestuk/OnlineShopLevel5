﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineShop2022.Data;
using OnlineShop2022.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop2022.Controllers
{
    [Authorize(Roles = "Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;

        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<IActionResult> Index(string q, string sortBy)
        {
            List<ProductModel> products;
            ViewData["q"] = q;

            if (q != null)
            {
                products = await _db.Products.Where(p => p.Description.ToLower().Contains(q.ToLower())).ToListAsync();            
            }
            else
            {
                products = await _db.Products.ToListAsync();
               
            }
            switch(sortBy)
            {
                case "price":
                    return View(products.OrderBy(o => o.Price));

                case "priceDesc":
                    return View(products.OrderByDescending(o => o.Price));

                case "AZ":
                    return View(products.OrderBy(o => o.Description));

                case "ZA":
                    return View(products.OrderByDescending(o => o.Description));
            }

                    
            return View(products);
        }

        public async Task<IActionResult> Products(string id)
        {
            var products = await _db.Products.ToListAsync();
            return View(products);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
