using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_SBD.Models
{
    public class Pacjent
    {
        public int PacjentId { get; set; }

        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string Imie { get; set; }

        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string Nazwisko { get; set; }

        [Required]
        public string NumerTelefonu { get; set; }

        [Required]
        public string PESEL { get; set; }
        public ICollection<PacjentChoroba> PacjenciChoroby { get; set; }
        public ICollection<PacjentUczulenie> PacjenciUczulenia { get; set; }

        public List<Wizyta> Wizyty { get; set; }

    }
}
