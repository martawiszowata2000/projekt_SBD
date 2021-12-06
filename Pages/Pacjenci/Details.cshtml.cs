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
            return Page();
        }
    }
}
