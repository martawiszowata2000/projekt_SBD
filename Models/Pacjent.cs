using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_SBD.Models
{
    public class Pacjent
    {
        public int PacjentId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int NumerTelefonu { get; set; }
        public int PESEL { get; set; }
        public ICollection<PacjentChoroba> PacjenciChoroby { get; set; }
        public ICollection<PacjentUczulenie> PacjenciUczulenia { get; set; }

        public List<Wizyta> Wizyty { get; set; }

    }
}
