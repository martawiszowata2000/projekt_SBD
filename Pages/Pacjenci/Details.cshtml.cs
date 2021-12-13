using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using projekt_SBD.Data;
using projekt_SBD.Models;

namespace projekt_SBD.Pages.Pacjenci
{
    public class DetailsModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public DetailsModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        public Pacjent Pacjent { get; set; }
        public List<Uczulenie> uczulenia = new List<Uczulenie>();
        public List<Choroba> choroby = new List<Choroba>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pacjent = await _context.Pacjenci.FirstOrDefaultAsync(m => m.PacjentId == id);
            
            if (Pacjent == null)
            {
                return NotFound();
            }
            uczulenia = (from u in _context.Uczulenia
                         from pu in _context.PacjenciUczulenia
                         where u.UczulenieId == pu.UczulenieId && pu.PacjentId == id
                         select u).ToList();
            choroby = (from c in _context.Choroby
                         from pc in _context.PacjenciChoroby
                         where c.ChorobaId == pc.ChorobaId && pc.PacjentId == id
                         select c).ToList();
            return Page();
        }
    }
}
