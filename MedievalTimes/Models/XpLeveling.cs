using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalTimes.Models
{
    public class XpLeveling
    {
        [Key]
        public Guid Id { get; set; }

        public int XpNeededLvl1 { get; set; }
        public int XpNeededLvl2 { get; set; }
        public int XpNeededLvl3 { get; set; }
        public int XpNeededLvl4 { get; set; }
        public int XpNeededLvl5 { get; set; }
        public int XpNeededLvl6 { get; set; }
        public int XpNeededLvl7 { get; set; }
        public int XpNeededLvl8 { get; set; }
        public int XpNeededLvl9 { get; set; }
        public int XpNeededLvl10 { get; set; }
        public int XpNeededLvl11 { get; set; }
        public int XpNeededLvl12 { get; set; }
        public int XpNeededLvl13 { get; set; }
        public int XpNeededLvl14 { get; set; }
        public int XpNeededLvl15 { get; set; }
        public int XpNeededLvl16 { get; set; }
        public int XpNeededLvl17 { get; set; }
        public int XpNeededLvl18 { get; set; }
        public int XpNeededLvl19 { get; set; }
        public int XpNeededLvl20 { get; set; }
        public int XpNeededMax { get; set; }
    }
}
