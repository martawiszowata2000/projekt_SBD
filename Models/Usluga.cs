using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_SBD.Models
{
    public class Usluga
    {
        public int UslugaId { get; set;}
        public string UslugaNazwa { get; set;}
        public float Cena { get; set;}
        public ICollection<WizytaUsluga> WizytyUslugi { get; set; }
    }
}
