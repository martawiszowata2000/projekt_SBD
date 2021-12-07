using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using projekt_SBD.Data;
using projekt_SBD.Models;

namespace projekt_SBD.Pages.Pacjenci
{
    public class IndexModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public IndexModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Pacjent> Pacjent { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {
            Pacjent = await _context.Pacjenci.ToListAsync();

            NazwaSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            switch (sortOrder)
            {
                case "name_desc":
                    Pacjent = Pacjent.OrderByDescending(s => s.Nazwisko).ThenBy(s => s.Imie).ToList();
                    break;
                default:
                    Pacjent = Pacjent.OrderBy(p => p.Nazwisko).ThenBy(p => p.Imie).ToList();
                    break;
            }
        }

        [BindProperty(SupportsGet = true)]
        public string Wyszukiwanie { get; set; }
        public string NazwaSort { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (Wyszukiwanie != null)
                {
                    var pacjenci = from Pacjent in _context.Pacjenci
                                  where (Pacjent.Imie.ToLower().Contains(Wyszukiwanie.ToLower())) || (Pacjent.Nazwisko.ToLower().Contains(Wyszukiwanie.ToLower()))
                                  || (Pacjent.NumerTelefonu.ToString().Contains(Wyszukiwanie.ToLower())) || (Pacjent.PESEL.ToString().Contains(Wyszukiwanie.ToLower()))
                                   orderby Pacjent.Nazwisko
                                  select Pacjent;
                    Pacjent = pacjenci.ToList();
                }
                else
                {
                    Pacjent = await _context.Pacjenci.ToListAsync();

                }
            }
            return Page();
        }
        
    }
}
