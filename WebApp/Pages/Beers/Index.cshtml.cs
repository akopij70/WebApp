using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
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

        public IList<Beer> Beer { get; set; } = default!;

        public async Task OnGetAsync(string searchText)
        {
            if (_context.Beer != null)
            {
                //Request.Query.TryGetValue("options", out StringValues selectedOption);
                //if (Request.Query.TryGetValue("options", out StringValues selectedOption) && !string.IsNullOrEmpty(selectedOption.FirstOrDefault()))
                if (Request.Query.TryGetValue("options", out StringValues selectedOption) && !string.IsNullOrEmpty(selectedOption.FirstOrDefault()))
                {
                    var selectedOptionValue = selectedOption.FirstOrDefault();
                    //if (string.CompareselectedOptionValue, "name") Beer = await _context.Beer.Where(b => b.name.Contains(searchText)).ToListAsync();

                    switch (selectedOptionValue)
                    {
                        case "name":
                            Beer = await _context.Beer.Where(b => b.name.Contains(searchText)).ToListAsync();
                            //Beer = await _context.Beer.ToListAsync();
                            break;
                        case "voltage":
                            Beer = await _context.Beer.Where(b => b.voltage.Equals(float.Parse(searchText))).ToListAsync();
                            break;
                        case "volume":
                            Beer = await _context.Beer.Where(b => b.volume.Equals(float.Parse(searchText))).ToListAsync();
                            break;
                        default:
                            Beer = await _context.Beer.ToListAsync();
                            //Beer = await _context.Beer.Where(b => b.name.Contains(searchText)).ToListAsync();
                            break;
                    }
                }
                else
                {
                    Beer = await _context.Beer.ToListAsync();

                    // Beer = await _context.Beer.Where(b => b.name.Contains(searchText)).ToListAsync();

                    // kod dla braku wyboru opcji
                }
            }
        }
    }
}
