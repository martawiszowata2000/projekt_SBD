using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using projekt_SBD.Data;
using projekt_SBD.Models;

namespace projekt_SBD.Pages.Asystenci
{
    public class IndexModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public IndexModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Asystent> Asystent { get;set; }
        public string NazwaSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            NazwaSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            Asystent = await _context.Asystenci.ToListAsync();

            switch (sortOrder)
            {
                case "name_desc":
                    Asystent = Asystent.OrderByDescending(s => s.Nazwisko).ThenBy(s => s.Imie).ToList();
                    break;
                default:
                    Asystent = Asystent.OrderBy(s => s.Nazwisko).ThenBy(s => s.Imie).ToList();
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
                    var asystenci = from Asystent in _context.Asystenci
                                   where (Asystent.Imie.ToLower().Contains(Wyszukiwanie.ToLower())) || (Asystent.DrugieImie.ToLower().Contains(Wyszukiwanie.ToLower()))
                                   || (Asystent.Nazwisko.ToLower().Contains(Wyszukiwanie.ToLower()))
                                   orderby Asystent.Nazwisko
                                   select Asystent;
                    Asystent = asystenci.ToList();
                }
                else
                {
                    Asystent = await _context.Asystenci.ToListAsync();

                }
            }
            return Page();
        }
    }
}
