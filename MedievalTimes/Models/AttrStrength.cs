using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalTimes.Models
{
    public class AttrStrength
    {
        [Key]
        public Guid Id { get; set; }
        public int Str { get; set; }
        public int StrMinP { get; set; }
        public int StrMaxP { get; set; }
        public int HitProb { get; set; }
        public int DmgAdj { get; set; }
        public int WeightAllow { get; set; }
        public int MaxPress { get; set; }
        public int OpenDoors { get; set; }
        public int OpenClosedDoors { get; set; }
        public int BendBarsLiftGates { get; set; }
        public string Notes { get; set; }

    }
}
