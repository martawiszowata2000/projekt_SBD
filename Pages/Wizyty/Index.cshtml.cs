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
        public  Pacjent Pacjent { get; set; }
        private static int pid = 0;
        private static int sid = 0;
        private static int aid = 0;

        [BindProperty]
        public  Stomatolog Stomatolog { get; set; }
        [BindProperty]
        public  Asystent Asystent { get; set; }
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
        public async Task OnGetAsync(string sortOrder)
        {
            Wizyty = await _context.Wizyty.ToListAsync();
            Wizyty = Filter();

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
            PrepareOptions();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Wizyty = await _context.Wizyty.ToListAsync();
            Wizyty = Filter();

            PrepareOptions();
            return Page();

        }
        public IList<Wizyta> Filter()
        {

            if (Pacjent != null)
            {
                pid = Pacjent.PacjentId;
            }
            if (Stomatolog != null)
            {
                sid = Stomatolog.StomatologId;
            }
            if (Asystent != null)
            {
                aid = Asystent.AsystentId;
            }
            if (pid != 0)
                {
                    Wizyty = Wizyty.Where(w => w.PacjentId == pid).ToList();
                }
                if (aid != 0)
                {
                    Wizyty = Wizyty.Where(w => w.AsystentId == aid).ToList();
                }
                if (sid != 0)
                {
                    Wizyty = Wizyty.Where(w => w.StomatologId == sid).ToList();
                }
            return Wizyty;
        }
        public string GetStomatolog(int id)
        {
            Stomatolog s = new Stomatolog();
            s = _context.Stomatolodzy.Where(s => s.StomatologId == id).FirstOrDefault();
            return $"{s.Imie} {s.Nazwisko}";
        }
        public string GetAsystent(int id)
        {
            Asystent s = new Asystent();
            s = _context.Asystenci.Where(s => s.AsystentId == id).FirstOrDefault();
            return $"{s.Imie} {s.Nazwisko}";
        }
        public string GetPacjent(int id)
        {
            Pacjent s = new Pacjent();
            s = _context.Pacjenci.Where(s => s.PacjentId == id).FirstOrDefault();
            return $"{s.Imie} {s.Nazwisko}";
        }
    }
}
