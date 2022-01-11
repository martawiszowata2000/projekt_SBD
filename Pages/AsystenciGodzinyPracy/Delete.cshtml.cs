using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using projekt_SBD.Data;
using projekt_SBD.Models;

namespace projekt_SBD.Pages.AsystenciGodzinyPracy
{
    public class DeleteModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public DeleteModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AsystentGodzinyPracy AsystentGodzinyPracy { get; set; }

        public Asystent asystent { get; set; }
        public string asystentSurnameName { get; set; }

        public string poczatekDzienPracy { get; set; }
        public string poczatekGodzina { get; set; }
        public string koniecGodzina { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AsystentGodzinyPracy = await _context.AsystenciGodzinyPracy.FirstOrDefaultAsync(m => m.ZmianaId == id);

            asystent = _context.Asystenci.Where(s => s.AsystentId == AsystentGodzinyPracy.AsystentId).FirstOrDefault();
            asystentSurnameName = asystent.Nazwisko.ToString() + " " + asystent.Imie.ToString();

            poczatekDzienPracy = AsystentGodzinyPracy.Poczatek.ToString("D");
            poczatekGodzina = AsystentGodzinyPracy.Poczatek.ToString("t");
            koniecGodzina = AsystentGodzinyPracy.Koniec.ToString("t");

            if (AsystentGodzinyPracy == null)
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

            AsystentGodzinyPracy = await _context.AsystenciGodzinyPracy.FindAsync(id);

            if (AsystentGodzinyPracy != null)
            {
                _context.AsystenciGodzinyPracy.Remove(AsystentGodzinyPracy);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Asystenci/Index");
        }
    }
}
