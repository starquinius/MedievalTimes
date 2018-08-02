using MedievalTimes.Areas.CharCreation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalTimes.Models
{
    public class Class
    {
        [Key]
        public Guid ClassId { get; set; }
        public Beroep Name { get; set; }
        public XpLeveling XpLeveling { get; set; }
        public int HitDiceNr { get; set; }
        public int HitDiceSide { get; set; }
        public int HitDiceMaxLvl { get; set; }
        public int HitDiceMaxLvlModifier { get; set; }



    }
}
