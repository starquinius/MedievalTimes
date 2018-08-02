using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalTimes.Models
{
    public enum WSize { Large, Medium, Small}
    public enum WType { Piercing, Bludgeoning, Slashing, Missile}

    public class Weapon
    {
        public Guid Id { get; set; }

        [Display(Name = "Weapon's Name")]
        public string Name { get; set; }

        public int Cost { get; set; }
        public int Weight { get; set; }
        public WSize Size { get; set; }
        public WType Type { get; set; }
        public int SpeedFactor { get; set; }
        public int DamageSMnrDice { get; set; }
        public int DamageSMDiceSide { get; set; }
        public int DamageSAdj { get; set; }
        public int DamageLnrDice { get; set; }
        public int DamageLDiceSide { get; set; }
        public int DamageLAdj { get; set; }

        //For Missile Weapons Only
        public int ROFnr { get; set; }
        public int ROFrnd { get; set; }
        public int RangeS { get; set; }
        public int RangeM { get; set; }
        public int RangeL { get; set; }
    }
}
