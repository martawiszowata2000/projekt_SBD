using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_SBD.Models
{
    public class Choroba
    {
        public int ChorobaId { get; set; }
        public string NazwaChoroby { get; set; }
        public ICollection<PacjentChoroba> PacjenciChoroby { get; set; }
    }
}
