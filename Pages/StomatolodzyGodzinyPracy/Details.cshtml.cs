using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using projekt_SBD.Data;
using projekt_SBD.Models;

namespace projekt_SBD.Pages.StomatolodzyGodzinyPracy
{
    public class DetailsModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public DetailsModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        public StomatologGodzinyPracy StomatologGodzinyPracy { get; set; }
        public string poczatekDzienPracy { get; set; }
        public string poczatekGodzina { get; set; }
        public string koniecGodzina { get; set; }
        public string stomatologSurnameName { get; set; }
        public Stomatolog stomatolog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StomatologGodzinyPracy = await _context.StomatolodzyGodzinyPracy.FirstOrDefaultAsync(m => m.ZmianaId == id);
            poczatekDzienPracy = StomatologGodzinyPracy.Poczatek.ToString("D");
            poczatekGodzina = StomatologGodzinyPracy.Poczatek.ToString("t");
            koniecGodzina = StomatologGodzinyPracy.Koniec.ToString("t");

            stomatolog = _context.Stomatolodzy.Where(s => s.StomatologId == StomatologGodzinyPracy.StomatologId).FirstOrDefault();
            stomatologSurnameName = stomatolog.Nazwisko.ToString() + " " + stomatolog.Imie.ToString();

            if (StomatologGodzinyPracy == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
