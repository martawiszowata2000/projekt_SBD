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
    public class DeleteModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public DeleteModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Wizyta Wizyta { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Wizyta = await _context.Wizyty.FirstOrDefaultAsync(m => m.WizytaId == id);

            if (Wizyta == null)
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

            Wizyta = await _context.Wizyty.FindAsync(id);

            if (Wizyta != null)
            {
                _context.Wizyty.Remove(Wizyta);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }

        public string GetStomatolog(int id)
        {
            Stomatolog s = new Stomatolog();
            s = _context.Stomatolodzy.Where(s => s.StomatologId == id).FirstOrDefault();
            return $"{s.Imie} {s.Nazwisko}";
        }
        public string GetAsystent(int id)
        {
            Asystent s = new Asystent();
            s = _context.Asystenci.Where(s => s.AsystentId == id).FirstOrDefault();
            return $"{s.Imie} {s.Nazwisko}";
        }
        public string GetPacjent(int id)
        {
            Pacjent s = new Pacjent();
            s = _context.Pacjenci.Where(s => s.PacjentId == id).FirstOrDefault();
            return $"{s.Imie} {s.Nazwisko}";
        }
    }
}
