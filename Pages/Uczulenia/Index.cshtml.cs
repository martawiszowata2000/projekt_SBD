using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using projekt_SBD.Data;
using projekt_SBD.Models;

namespace projekt_SBD.Pages.Uczulenia
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

        public IList<Uczulenie> Uczulenie { get;set; }
        public string NazwaSort { get; set; }
        public async Task OnGetAsync(string sortOrder)
        {
            NazwaSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            Uczulenie = await _context.Uczulenia.ToListAsync();
            switch (sortOrder)
            {
                case "name_desc":
                    Uczulenie = Uczulenie.OrderByDescending(s => s.NazwaAlergenu).ToList();
                    break;
                default:
                    Uczulenie = Uczulenie.OrderBy(s => s.NazwaAlergenu).ToList();
                    break;
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (Wyszukiwanie != null)
                {
                    var uczulenia = from Uczulenie in _context.Uczulenia
                                    where (Uczulenie.NazwaAlergenu.ToLower().Contains(Wyszukiwanie.ToLower()))
                                    orderby Uczulenie.NazwaAlergenu
                                    select Uczulenie;
                    Uczulenie = uczulenia.ToList();
                }
                else
                {
                    Uczulenie = await _context.Uczulenia.ToListAsync();

                }
            }
            return Page();
        }
    }
}
