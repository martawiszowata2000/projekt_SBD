using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using projekt_SBD.Data;
using projekt_SBD.Models;

namespace projekt_SBD.Pages.StomatolodzyGodzinyPracy
{
    public class CreateModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public CreateModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            stomatolog = _context.Stomatolodzy.Where(s => s.StomatologId == id).FirstOrDefault();
            stomatologSurnameName = stomatolog.Nazwisko.ToString() + " " + stomatolog.Imie.ToString();

            return Page();
        }

        [BindProperty]
        public StomatologGodzinyPracy StomatologGodzinyPracy { get; set; }

        public Stomatolog stomatolog { get; set; }
        public string stomatologSurnameName { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            stomatolog = _context.Stomatolodzy.Where(s => s.StomatologId == id).FirstOrDefault();
            StomatologGodzinyPracy.StomatologId = stomatolog.StomatologId;
            _context.StomatolodzyGodzinyPracy.Add(StomatologGodzinyPracy);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Stomatolodzy/Index");
        }
    }
}
