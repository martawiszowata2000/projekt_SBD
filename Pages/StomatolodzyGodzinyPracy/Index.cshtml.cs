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
    public class IndexModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public IndexModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<StomatologGodzinyPracy> StomatologGodzinyPracy { get;set; }

        public async Task OnGetAsync()
        {
            StomatologGodzinyPracy = await _context.StomatolodzyGodzinyPracy.ToListAsync();
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
