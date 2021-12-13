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

namespace projekt_SBD.Pages.StomatolodzyGodzinyPracy
{
    public class EditModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public EditModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StomatologGodzinyPracy StomatologGodzinyPracy { get; set; }

        public string stomatologSurnameName { get; set; }
        public Stomatolog stomatolog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StomatologGodzinyPracy = await _context.StomatolodzyGodzinyPracy.FirstOrDefaultAsync(m => m.ZmianaId == id);

            stomatolog = _context.Stomatolodzy.Where(s => s.StomatologId == StomatologGodzinyPracy.StomatologId).FirstOrDefault();
            stomatologSurnameName = stomatolog.Nazwisko.ToString() + " " + stomatolog.Imie.ToString();

            if (StomatologGodzinyPracy == null)
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

            _context.Attach(StomatologGodzinyPracy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StomatologGodzinyPracyExists(StomatologGodzinyPracy.ZmianaId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Stomatolodzy/Index");
        }

        private bool StomatologGodzinyPracyExists(int id)
        {
            return _context.StomatolodzyGodzinyPracy.Any(e => e.ZmianaId == id);
        }
    }
}
