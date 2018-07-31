using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalTimes.Areas.CharCreation.Models
{
    public class Race
    {
        [Key]
        public Guid RaceId { get; set; }
        public string Name { get; set; }

        //Table 10, page 33
        public int BaseHeightM { get; set; }
        public int BaseHeightF { get; set; }
        public Dice HeightModifier { get; set; }
        
        //Table 10, page 33
        public int BaseWeightM { get; set; }
        public int BaseWeightF { get; set; }
        public Dice WeightModifier { get; set; }

        //Table 11, page 33
        public int BaseAge { get; set; }
        public Dice AgeModifier { get; set; }
        public int BaseMaxAge { get; set; }
        public Dice MaxAgeModifier { get; set; }






    }
}
