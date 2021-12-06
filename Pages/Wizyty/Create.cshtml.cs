using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using projekt_SBD.Data;
using projekt_SBD.Models;

namespace projekt_SBD.Pages.Wizyty
{
    public class CreateModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;
        private List<Pacjent> pacjenci = new List<Pacjent>();
        public List<SelectListItem> Pacjent_Options { get; set; }
        public List<SelectListItem> Stomatolog_Options { get; set; }
        public List<SelectListItem> Asystent_Options { get; set; }


        public CreateModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Pacjent_Options = _context.Pacjenci.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.PacjentId.ToString(),
                                      Text = a.Imie + " " +  a.Nazwisko
                                  }).ToList();

            Stomatolog_Options = _context.Stomatolodzy.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.StomatologId.ToString(),
                                      Text = a.Imie + " " + a.DrugieImie + " " + a.Nazwisko
                                  }).ToList();

            Asystent_Options = _context.Asystenci.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.AsystentId.ToString(),
                                      Text = a.Imie + " " + a.DrugieImie +  " " + a.Nazwisko
                                  }).ToList();

            return Page();
        }

        [BindProperty]
        public Wizyta Wizyta { get; set; }

        [BindProperty]
        public Pacjent Pacjent { get; set; }
        [BindProperty]
        public Stomatolog Stomatolog { get; set; }
        [BindProperty]
        public Asystent Asystent { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Wizyta.PacjentId = Pacjent.PacjentId;
            Wizyta.AsystentId = Asystent.AsystentId;
            Wizyta.StomatologId = Stomatolog.StomatologId;

            _context.Wizyty.Add(Wizyta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
