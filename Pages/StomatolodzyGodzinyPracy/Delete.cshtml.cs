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
    public class DeleteModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public DeleteModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StomatologGodzinyPracy StomatologGodzinyPracy { get; set; }

        public Stomatolog stomatolog { get; set; }

        public string poczatekDzienPracy { get; set; }
        public string poczatekGodzina { get; set; }
        public string koniecGodzina { get; set; }
        public string stomatologSurnameName { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StomatologGodzinyPracy = await _context.StomatolodzyGodzinyPracy.FirstOrDefaultAsync(m => m.ZmianaId == id);

            stomatolog = _context.Stomatolodzy.Where(s => s.StomatologId == StomatologGodzinyPracy.StomatologId).FirstOrDefault();
            stomatologSurnameName = stomatolog.Nazwisko.ToString() + " " + stomatolog.Imie.ToString();
            poczatekDzienPracy = StomatologGodzinyPracy.Poczatek.ToString("D");
            poczatekGodzina = StomatologGodzinyPracy.Poczatek.ToString("t");
            koniecGodzina = StomatologGodzinyPracy.Koniec.ToString("t");

            if (StomatologGodzinyPracy == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StomatologGodzinyPracy = await _context.StomatolodzyGodzinyPracy.FindAsync(id);

            if (StomatologGodzinyPracy != null)
            {
                _context.StomatolodzyGodzinyPracy.Remove(StomatologGodzinyPracy);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Stomatolodzy/Index");
        }
    }
}
