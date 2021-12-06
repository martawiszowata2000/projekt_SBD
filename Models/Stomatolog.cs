using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_SBD.Models
{
    public class Stomatolog
    {
        public int StomatologId { get; set; }
        
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string Imie { get; set; }

        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string DrugieImie { get; set; }

        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string Nazwisko { get; set; }

        public List<StomatologGodzinyPracy> GodzinyPracy { get; set; }
        public List<Wizyta> Wizyty { get; set; }

    }
}
