using MedievalTimes.Areas.CharCreation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedievalTimes.Models
{
    public class ClassAbilityRequirements
    {
        [Key]
        public Guid Id { get; set; }

        public Beroep Beroep { get; set; }

        public bool RaceHuman { get; set; }
        public bool RaceElf { get; set; }
        public bool RaceDwarf{ get; set; }
        public bool RaceHalfElf{ get; set; }
        public bool RaceHalfling{ get; set; }
        public bool RaceGnome{ get; set; }

        public int MinStr { get; set; }
        public bool StrPrime { get; set; }

        public int MinDex { get; set; }
        public bool DexPrime { get; set; }

        public int MinCon { get; set; }
        public bool ConPrime { get; set; }

        public int MinInt { get; set; }
        public bool IntPrime { get; set; }

        public int MinWis { get; set; }
        public bool WisPrime { get; set; }

        public int MinCha { get; set; }
        public bool ChaPrime { get; set; }

    }
}
