using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_SBD.Models
{
    public class Wizyta
    {
        public int WizytaId { get; set;}
        public int PacjentId { get; set;}
        public int StomatologId { get; set;}
        public int AsystentId { get; set;}
        public DateTime DataGodzina { get; set;}
        public ICollection<WizytaUsluga> WizytyUslugi { get; set; }
        //public string GetStomatolog(int id)
        //{
        //    Stomatolog s = new Stomatolog();
        //    using(var db = new Data.AppDbContext())
        //    {
        //        s = db.Stomatolodzy.Where(s => s.StomatologId == id).FirstOrDefault();
        //    }
        //    return $"{s.Imie} {s.DrugieImie} {s.Nazwisko}";
        //}
    }
}
