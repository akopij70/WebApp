using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Pages.Beers
{
    public class IndexModel : PageModel
    {
        private readonly WebAppContext _context;

        public IndexModel(WebAppContext context)
        {
            _context = context;
        }

        public IList<Beer> Beer { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedOption { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchText { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<Beer> beer = _context.Beer;
            
            if (!string.IsNullOrEmpty(SelectedOption))
            {
                switch (SelectedOption)
                {
                    case "name":
                        beer = beer.Where(b => b.name.Contains(SearchText));
                        break;
                    case "voltage":
                        if (float.TryParse(SearchText, out float voltage))
                        {
                            beer = beer.Where(b => b.voltage == voltage);
                        }
                        break;
                    case "volume":
                        if (float.TryParse(SearchText, out float volume))
                        {
                            beer = beer.Where(b => b.volume == volume);
                        }
                        break;
                    case "price":
                        if (float.TryParse(SearchText, out float price))
                        {
                            beer = beer.Where(b => b.price == price);
                        }
                        break;
                    default:
                         Beer = await beer.ToListAsync();
                        break;
                }
            }
            Beer = await beer.ToListAsync();
        }
    }
}

    