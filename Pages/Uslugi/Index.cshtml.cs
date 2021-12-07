using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using projekt_SBD.Data;
using projekt_SBD.Models;

namespace projekt_SBD.Pages.Uslugi
{
    public class IndexModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public IndexModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string Wyszukiwanie { get; set; }

        public IList<Usluga> Usluga { get;set; }

        public string NazwaSort { get; set; }
        public string CenaSort { get; set; }


        public async Task OnGetAsync(string sortOrder)
        {
            NazwaSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (String.IsNullOrEmpty(sortOrder)) CenaSort = "cena_desc";
            else if (sortOrder == "cena_desc") CenaSort = "cena_asc";
            else CenaSort = "";
            Usluga = await _context.Uslugi.ToListAsync();

            switch (sortOrder)
            {
                case "name_desc":
                    Usluga = Usluga.OrderByDescending(s => s.UslugaNazwa).ToList();
                    break;
                case "cena_desc":
                    Usluga = Usluga.OrderByDescending(s => s.Cena).ToList();
                    break;
                case "cena_asc":
                    Usluga = Usluga.OrderBy(s => s.Cena).ToList();
                    break;
                default:
                    Usluga = Usluga.OrderBy(s => s.UslugaNazwa).ToList();
                    break;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (Wyszukiwanie != null)
                {
                    var uslugi = from Usluga in _context.Uslugi
                                  where (Usluga.UslugaNazwa.ToLower().Contains(Wyszukiwanie.ToLower()))
                                  orderby Usluga.UslugaNazwa
                                  select Usluga;
                    Usluga = uslugi.ToList();
                }
                else
                {
                    Usluga = await _context.Uslugi.ToListAsync();

                }
            }
            return Page();
        }
        
    }
}
