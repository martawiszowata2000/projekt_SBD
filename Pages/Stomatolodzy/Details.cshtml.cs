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
    public class DetailsModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public DetailsModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        public Stomatolog Stomatolog { get; set; }
        public IList<StomatologGodzinyPracy> godzinyPracyStomalolodzy { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stomatolog = await _context.Stomatolodzy.FirstOrDefaultAsync(m => m.StomatologId == id);
            godzinyPracyStomalolodzy = await _context.StomatolodzyGodzinyPracy.Where(s => s.StomatologId == id).ToListAsync();

            if (Stomatolog == null)
            {
                return NotFound();
            }
            return Page();
        }
        public string GetPoczatekDzien(int id)
        {
            StomatologGodzinyPracy godzinyPracy = new StomatologGodzinyPracy();
            godzinyPracy = _context.StomatolodzyGodzinyPracy.Where(godzinyPracy => godzinyPracy.ZmianaId == id).FirstOrDefault();
            return $"{godzinyPracy.Poczatek.ToString("D")}";
        }
        public string GetPoczatekGodzina(int id)
        {
            StomatologGodzinyPracy godzinyPracy = new StomatologGodzinyPracy();
            godzinyPracy = _context.StomatolodzyGodzinyPracy.Where(godzinyPracy => godzinyPracy.ZmianaId == id).FirstOrDefault();
            return $"{godzinyPracy.Poczatek.ToString("t")}";
        }
        public string GetKoniecGodzina(int id)
        {
            StomatologGodzinyPracy godzinyPracy = new StomatologGodzinyPracy();
            godzinyPracy = _context.StomatolodzyGodzinyPracy.Where(godzinyPracy => godzinyPracy.ZmianaId == id).FirstOrDefault();
            return $"{godzinyPracy.Koniec.ToString("t")}";
        }
    }
}
