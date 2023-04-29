﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Beers
{
    public class IndexModel : PageModel
    {

        private readonly WebApp.Data.WebAppContext _context;

        public IndexModel(WebApp.Data.WebAppContext context)
        {
            _context = context;
        }

        public IList<Beer> Beer { get;set; } = default!;
       

        public async Task OnGetAsync(string searchText)
        {
            if (_context.Beer != null)
            {
                Beer = await _context.Beer.Where(b => b.name.Contains(searchText)).ToListAsync();
                //Beer = await _context.Beer.Where(b => b.name.Contains("tyskie")).ToListAsync();
                //Beer = await _context.Beer.ToListAsync();
            }
        }
    }
}
