using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_SBD.Models
{
    public class AsystentGodzinyPracy
    {
        public int ZmianaId { get; set; }
        public int AsystentId { get; set; }
        public DateTime Poczatek { get; set; }
        public DateTime Koniec { get; set; }
    }
}
