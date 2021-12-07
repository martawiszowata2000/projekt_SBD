using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using projekt_SBD.Data;
using projekt_SBD.Models;

namespace projekt_SBD.Pages.Stomatolodzy
{
    public class IndexModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public IndexModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Stomatolog> Stomatolog { get;set; }

        public string NazwaSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NazwaSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            Stomatolog = await _context.Stomatolodzy.ToListAsync();

            switch (sortOrder)
            {
                case "name_desc":
                    Stomatolog = Stomatolog.OrderByDescending(s => s.Nazwisko).ThenBy(s => s.Imie).ToList();
                    break;
                default:
                    Stomatolog = Stomatolog.OrderBy(p => p.Nazwisko).ThenBy(s => s.Imie).ToList();
                    break;
            }

        }

        [BindProperty(SupportsGet = true)]
        public string Wyszukiwanie { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (Wyszukiwanie != null)
                {
                    var stomatolodzy = from Stomatolog in _context.Stomatolodzy
                                       where (Stomatolog.Imie.ToLower().Contains(Wyszukiwanie.ToLower())) || (Stomatolog.DrugieImie.ToLower().Contains(Wyszukiwanie.ToLower()))
                                   || (Stomatolog.Nazwisko.ToLower().Contains(Wyszukiwanie.ToLower()))
                                   orderby Stomatolog.Nazwisko
                                   select Stomatolog;
                    Stomatolog = stomatolodzy.ToList();
                }
                else
                {
                    Stomatolog = await _context.Stomatolodzy.ToListAsync();

                }
            }
            return Page();
        }
    }
}
