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
            IQueryable<Beer> beersQuery = _context.Beer;

            if (!string.IsNullOrEmpty(SelectedOption))
            {
                switch (SelectedOption)
                {
                    case "name":
                        beersQuery = beersQuery.Where(b => b.name.Contains(SearchText));
                        break;
                    case "voltage":
                        if (float.TryParse(SearchText, out float voltage))
                        {
                            beersQuery = beersQuery.Where(b => b.voltage == voltage);
                        }
                        break;
                    case "volume":
                        if (float.TryParse(SearchText, out float volume))
                        {
                            beersQuery = beersQuery.Where(b => b.volume == volume);
                        }
                        break;
                    default:
                        break;
                }
            }

            Beer = await beersQuery.ToListAsync();
        }
    }
}

    