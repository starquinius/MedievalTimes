using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalTimes.Areas.CharCreation.Models
{
    public class Attributes
    {
        [Display(Name = "Strength")]
        public int Strength { get; set; }

        [Display(Name = "Dexterity")]
        public int Dexterity { get; set; }

        [Display(Name = "Constitution")]
        public int Constitution { get; set; }

        [Display(Name = "Intelligence")]
        public int Intelligence { get; set; }

        [Display(Name = "Wisdom")]
        public int Wisdom { get; set; }

        [Display(Name = "Charisma")]
        public int Charisma { get; set; }
    }
}
