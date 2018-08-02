using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalTimes.Models
{
    public class AttrDexterity
    {
        [Key]
        public Guid Id { get; set; }
        public int Dex { get; set; }
        public int ReactionAdj { get; set; }
        public int MissileAttackAdj { get; set; }
        public int DefensiveAdj { get; set; }
    }
}
