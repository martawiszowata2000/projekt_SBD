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
    public class DetailsModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public DetailsModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        public Asystent Asystent { get; set; }
        public IList<AsystentGodzinyPracy> godzinyPracyAsystenci { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Asystent = await _context.Asystenci.FirstOrDefaultAsync(m => m.AsystentId == id);
            godzinyPracyAsystenci = await _context.AsystenciGodzinyPracy.Where(s => s.AsystentId == id).ToListAsync();

            if (Asystent == null)
            {
                return NotFound();
            }
            return Page();
        }
        public string GetPoczatekDzien(int id)
        {
            AsystentGodzinyPracy godzinyPracy = new AsystentGodzinyPracy();
            godzinyPracy = _context.AsystenciGodzinyPracy.Where(godzinyPracy => godzinyPracy.ZmianaId == id).FirstOrDefault();
            return $"{godzinyPracy.Poczatek.ToString("D")}";
        }
        public string GetPoczatekGodzina(int id)
        {
            AsystentGodzinyPracy godzinyPracy = new AsystentGodzinyPracy();
            godzinyPracy = _context.AsystenciGodzinyPracy.Where(godzinyPracy => godzinyPracy.ZmianaId == id).FirstOrDefault();
            return $"{godzinyPracy.Poczatek.ToString("t")}";
        }
        public string GetKoniecGodzina(int id)
        {
            AsystentGodzinyPracy godzinyPracy = new AsystentGodzinyPracy();
            godzinyPracy = _context.AsystenciGodzinyPracy.Where(godzinyPracy => godzinyPracy.ZmianaId == id).FirstOrDefault();
            return $"{godzinyPracy.Koniec.ToString("t")}";
        }
    }
}
