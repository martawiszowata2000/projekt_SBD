using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using projekt_SBD.Data;
using projekt_SBD.Models;

namespace projekt_SBD.Pages.AsystenciGodzinyPracy
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
            asystent = _context.Asystenci.Where(s => s.AsystentId == id).FirstOrDefault();
            asystentSurnameName = asystent.Nazwisko.ToString() + " " + asystent.Imie.ToString();

            return Page();
        }

        [BindProperty]
        public AsystentGodzinyPracy AsystentGodzinyPracy { get; set; }

        public Asystent asystent { get; set; }
        public string asystentSurnameName { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            asystent = _context.Asystenci.Where(s => s.AsystentId == id).FirstOrDefault();
            AsystentGodzinyPracy.AsystentId = asystent.AsystentId;

            _context.AsystenciGodzinyPracy.Add(AsystentGodzinyPracy);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Asystenci/Index");
        }
    }
}
