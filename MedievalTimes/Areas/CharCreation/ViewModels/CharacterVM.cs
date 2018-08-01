using MedievalTimes.Areas.CharCreation.Models;
using MedievalTimes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static MedievalTimes.Areas.CharCreation.Models.Enums;

namespace MedievalTimes.Areas.CharCreation.ViewModels
{
    public class CharacterVM
    {
        [Key]
        public Guid BuildId { get; set; }

        [Display(Name = "Character's Name")]
        public string Name { get; set; }

        [Display(Name = "Character's Sexe")]
        public Sexe Sexe { get; set; }

        [Display(Name = "Character's Alignment")]
        public Alignment Alignment { get; set; }

        [Display(Name = "Character's Attitude")]
        public Attitude Attitude { get; set; }

        [Display(Name = "Character's Attributes")]
        public Attributes Attributes { get; set; }

        [Display(Name = "Character's Race")]
        public Race Races { get; set; }

        [Display(Name = "Character's Allowed Races")]
        public IEnumerable<RaceVM> ChoosableRaces { get; set; }

        [Display(Name = "Character's Class")]
        public Beroep Beroepen { get; set; }

        [Display(Name = "Character's Allowed Classes")]
        public IEnumerable<ClassVM> ChoosableClasses { get; set; }
    }
}
