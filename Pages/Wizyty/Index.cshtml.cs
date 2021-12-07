using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using projekt_SBD.Data;
using projekt_SBD.Models;

namespace projekt_SBD.Pages.Wizyty
{
    public class IndexModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public Pacjent Pacjent { get; set; }
        public Stomatolog Stomatolog { get; set; }
        public Asystent Asystent { get; set; }

        public IndexModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Wizyta> Wizyta { get;set; }
        public string NazwaSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            Wizyta = await _context.Wizyty.ToListAsync();
            NazwaSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            switch (sortOrder)
            {
                case "name_desc":
                    Wizyta = Wizyta.OrderByDescending(d => d.DataGodzina).ToList();
                    break;
                default:
                    Wizyta = Wizyta.OrderBy(d => d.DataGodzina).ToList();
                    break;
            }

            

        }

        public Pacjent GetPacjent()
        {
            Pacjent = 

            return 
        }

    }
}
