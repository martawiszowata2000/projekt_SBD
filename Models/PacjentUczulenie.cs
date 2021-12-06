using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_SBD.Models
{
    public class PacjentUczulenie
    {
        public int UczulenieId { get; set; }
        public Uczulenie Uczulenie { get; set; }
        public int PacjentId { get; set; }
        public Pacjent Pacjent { get; set; }
    }
}
