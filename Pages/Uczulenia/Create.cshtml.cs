using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using projekt_SBD.Data;
using projekt_SBD.Models;

namespace projekt_SBD.Pages.Uczulenia
{
    public class CreateModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;

        public CreateModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Uczulenie Uczulenie { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Uczulenia.Add(Uczulenie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
