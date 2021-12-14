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
    public class IndexModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public IndexModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<AsystentGodzinyPracy> AsystentGodzinyPracy { get;set; }

        public async Task OnGetAsync()
        {
            AsystentGodzinyPracy = await _context.AsystenciGodzinyPracy.ToListAsync();
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
