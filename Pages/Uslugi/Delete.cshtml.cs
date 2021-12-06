using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using projekt_SBD.Data;
using projekt_SBD.Models;

namespace projekt_SBD.Pages.Uslugi
{
    public class DeleteModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public DeleteModel(projekt_SBD.Data.AppDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Usluga = await _context.Uslugi.FindAsync(id);

            if (Usluga != null)
            {
                _context.Uslugi.Remove(Usluga);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
