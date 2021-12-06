using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_SBD.Models
{
    public class PacjentChoroba
    {
        public int PacjentId { get; set; }
        public Pacjent Pacjent { get; set; }
        public int ChorobaId { get; set; }
        public Choroba Choroba { get; set; }
    }
}
