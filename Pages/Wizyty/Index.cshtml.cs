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
    public class IndexModel : PageModel
    {
        private readonly projekt_SBD.Data.AppDbContext _context;
        public List<SelectListItem> Pacjent_Options { get; set; }
        public List<SelectListItem> Stomatolog_Options { get; set; }
        public List<SelectListItem> Asystent_Options { get; set; }


        public IndexModel(projekt_SBD.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Wizyta> Wizyty { get;set; }
        [BindProperty]
        public Wizyta Wizyta { get; set; }
        public string NazwaSort { get; set; }

        [BindProperty]
        public Pacjent Pacjent { get; set; }
        [BindProperty]
        public Stomatolog Stomatolog { get; set; }
        [BindProperty]
        public Asystent Asystent { get; set; }
        public void PrepareOptions()
        {
            Pacjent_Options = _context.Pacjenci.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.PacjentId.ToString(),
                                      Text = a.Imie + " " + a.Nazwisko
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
                                      Text = a.Imie + " " + a.DrugieImie + " " + a.Nazwisko
                                  }).ToList();
            Pacjent_Options.Insert(0, new SelectListItem
            {
                Value = null,
                Text = "--------------"
            });
            Stomatolog_Options.Insert(0, new SelectListItem
            {
                Value = null,
                Text = "--------------"
            });
            Asystent_Options.Insert(0, new SelectListItem
            {
                Value = null,
                Text = "--------------"
            });
        }
        public async Task OnGetAsync()
        {
            Wizyty = await _context.Wizyty.ToListAsync();
            PrepareOptions();
        }
        public async Task<IActionResult> OnPostAsync(string sortOrder)
        {
            Wizyty = await _context.Wizyty.ToListAsync();

            if (Pacjent.PacjentId != 0)
            {
                Wizyty = Wizyty.Where(w => w.PacjentId == Pacjent.PacjentId).ToList();
            }
            if (Asystent.AsystentId != 0)
            {
                Wizyty = Wizyty.Where(w => w.AsystentId == Asystent.AsystentId).ToList();
            }
            if (Stomatolog.StomatologId != 0)
            {
                Wizyty = Wizyty.Where(w => w.StomatologId == Stomatolog.StomatologId).ToList();
            }

            PrepareOptions();

            

            NazwaSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            switch (sortOrder)
            {
                case "name_desc":
                    Wizyty = Wizyty.OrderByDescending(d => d.DataGodzina).ToList();
                    break;
                default:
                    Wizyty = Wizyty.OrderBy(d => d.DataGodzina).ToList();
                    break;
            }

            return Page();


        }

        public Pacjent GetPacjent()
        {
            Pacjent p = new Pacjent();

            return p;
        }

    }
}
