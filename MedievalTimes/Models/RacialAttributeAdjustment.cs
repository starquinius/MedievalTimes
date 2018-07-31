using MedievalTimes.Areas.CharCreation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalTimes.Models
{
    public class RacialAttributeAdjustment
    {
        [Key]
        public Guid Id { get; set; }

        public Race Race { get; set; }

        public int MinStr { get; set; }
        public int MaxStr { get; set; }
        public int StrModifier { get; set; }

        public int MinDex { get; set; }
        public int MaxDex { get; set; }
        public int DexModifier { get; set; }

        public int MinCon { get; set; }
        public int MaxCon { get; set; }
        public int ConModifier { get; set; }

        public int MinInt { get; set; }
        public int MaxInt { get; set; }
        public int IntModifier { get; set; }

        public int MinWis { get; set; }
        public int MaxWis { get; set; }
        public int WisModifier { get; set; }

        public int MinCha { get; set; }
        public int MaxCha { get; set; }
        public int ChaModifier { get; set; }
    }
}
