using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApp.Data;
using WebApp.Models;

namespace WebApp
{
    public class BeerController : Controller
    {
        private readonly WebAppContext _context;

        public BeerController(WebAppContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchById()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchById(int id)
        {
            Beer? beer = _context.Beer.Find(id);

            if (beer == null)
            {
                ViewBag.Message = "Nie znaleziono piwa o podanym Id.";
                return View();
            }

            return View("BeerDetails", beer);
        }

    }
}
