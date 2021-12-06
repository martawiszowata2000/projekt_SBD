using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_SBD.Models
{
    public class Uczulenie
    {
        public int UczulenieId { get; set; }
        public string NazwaAlergenu { get; set; }
        public ICollection<PacjentUczulenie> PacjenciUczulenia { get; set; }
    }
}
