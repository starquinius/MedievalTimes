using MedievalTimes.Areas.CharCreation.Models;
using MedievalTimes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalTimes.Areas.CharCreation.ViewModels
{
    public enum Sexe { male, female}
    public enum Alignment { good, neutral, evil}
    public enum Attitude {lawful, chaotic, neutral }    

    public class CharacterVM
    {
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
        public List<RaceVM> ChoosableRaces { get; set; }


    }
}
