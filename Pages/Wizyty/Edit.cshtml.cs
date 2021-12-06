using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projekt_SBD.Data;
using projekt_SBD.Models;

namespace projekt_SBD.Pages.Wizyty
{
    public class EditModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public EditModel(projekt_SBD.Data.AppDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Wizyta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WizytaExists(Wizyta.WizytaId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WizytaExists(int id)
        {
            return _context.Wizyty.Any(e => e.WizytaId == id);
        }
    }
}
