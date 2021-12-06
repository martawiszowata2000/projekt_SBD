using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_SBD.Models
{
    public class Usluga
    {
        public int UslugaId { get; set;}
        [Display(Name = "Nazwa usługi:")]
        public string UslugaNazwa { get; set;}
        [Display(Name = "Cena:")]
        public float Cena { get; set;}
        public ICollection<WizytaUsluga> WizytyUslugi { get; set; }
    }
}
