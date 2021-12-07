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
        private List<Pacjent> pacjenci = new List<Pacjent>();
        public List<SelectListItem> Pacjent_Options { get; set; }
        public List<SelectListItem> Stomatolog_Options { get; set; }
        public List<SelectListItem> Asystent_Options { get; set; }

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

            Pacjent_Options = await _context.Pacjenci.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.PacjentId.ToString(),
                                      Text = a.Imie + " " + a.Nazwisko
                                  }).ToListAsync();

            Stomatolog_Options = await _context.Stomatolodzy.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.StomatologId.ToString(),
                                      Text = a.Imie + " " + a.DrugieImie + " " + a.Nazwisko
                                  }).ToListAsync();

            Asystent_Options = await _context.Asystenci.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.AsystentId.ToString(),
                                      Text = a.Imie + " " + a.DrugieImie + " " + a.Nazwisko
                                  }).ToListAsync();

            if (Wizyta == null)
            {
                return NotFound();
            }
            return Page();
        }

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
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Attach(Wizyta).State = EntityState.Modified;


            try
            {
                Wizyta.PacjentId = Pacjent.PacjentId;
                Wizyta.AsystentId = Asystent.AsystentId;
                Wizyta.StomatologId = Stomatolog.StomatologId;

                _context.Attach(Wizyta).State = EntityState.Modified;
                //_context.Wizyty.Add(Wizyta);
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
