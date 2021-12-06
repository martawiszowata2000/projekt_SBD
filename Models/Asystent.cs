using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_SBD.Models
{
    public class Asystent
    {
        public int AsystentId { get; set; }
        public string Imie { get; set; }
        public string DrugieImie { get; set; }
        public string Nazwisko { get; set; }
        public List<AsystentGodzinyPracy> GodzinyPracy { get; set; }
        public List<Wizyta> Wizyty { get; set; }

    }
}
