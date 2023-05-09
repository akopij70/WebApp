using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApp.Data;
using WebApp.Models;

namespace WebApp
{
    public class BeerController : Controller
    {
        //private readonly WebAppContext _context;
        private readonly DbSet<Beer> _context;
        public BeerController(WebAppContext context)
        {
         _context = context.Set<Beer>();
    }

        public IActionResult Index()
        {
            var find = _context.FirstOrDefault(b => b.price.Equals(0));
            return View(find);
        }

        /* [HttpGet]
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
         }*/

    }
}
