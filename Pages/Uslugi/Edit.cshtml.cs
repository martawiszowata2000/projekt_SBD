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

namespace projekt_SBD.Pages.Uslugi
{
    public class EditModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public EditModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Usluga Usluga { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Usluga = await _context.Uslugi.FirstOrDefaultAsync(m => m.UslugaId == id);

            if (Usluga == null)
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

            _context.Attach(Usluga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UslugaExists(Usluga.UslugaId))
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

        private bool UslugaExists(int id)
        {
            return _context.Uslugi.Any(e => e.UslugaId == id);
        }
    }
}
