using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using projekt_SBD.Data;
using projekt_SBD.Models;

namespace projekt_SBD.Pages.Choroby
{
    public class IndexModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;
        [BindProperty(SupportsGet = true)]
        public string Wyszukiwanie { get; set; }

        public IndexModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Choroba> Choroba { get;set; }
        public string NazwaSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NazwaSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            Choroba = await _context.Choroby.ToListAsync();
            switch (sortOrder)
            {
                case "name_desc":
                    Choroba = Choroba.OrderByDescending(s => s.NazwaChoroby).ToList();
                    break;
                default:
                    Choroba = Choroba.OrderBy(s => s.NazwaChoroby).ToList();
                    break;
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (Wyszukiwanie != null)
                {
                    var choroby = from Choroba in _context.Choroby
                                where (Choroba.NazwaChoroby.ToLower().Contains(Wyszukiwanie.ToLower()))
                                orderby Choroba.NazwaChoroby
                                select Choroba;
                    Choroba = choroby.ToList();
                }
                else
                {
                    Choroba = await _context.Choroby.ToListAsync();

                }
            }
            return Page();
        }
    }
}
