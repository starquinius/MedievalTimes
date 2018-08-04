using MedievalTimes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalTimes.Areas.CharCreation.ViewModels
{
    public class WeaponProfVM
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Character's Weapon Proficiencies")]
        public List<WeaponProficiency> WeaponProfs { get; set; }

        public int TotalWPs { get; set; }
        public int FreeWPs { get; set; }


    }
}
