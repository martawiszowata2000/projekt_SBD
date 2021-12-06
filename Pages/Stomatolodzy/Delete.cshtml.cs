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
    public class DeleteModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public DeleteModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Stomatolog Stomatolog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Stomatolog = await _context.Stomatolodzy.FirstOrDefaultAsync(m => m.StomatologId == id);

            if (Stomatolog == null)
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

            Stomatolog = await _context.Stomatolodzy.FindAsync(id);

            if (Stomatolog != null)
            {
                _context.Stomatolodzy.Remove(Stomatolog);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
