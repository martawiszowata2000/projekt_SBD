using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_SBD.Models
{
    public class WizytaUsluga
    {
        public int WizytaId { get; set; }
        public Wizyta Wizyta { get; set; }
        public int UslugaId { get; set; }
        public Usluga Usluga { get; set; }

    }
}
