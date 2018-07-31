using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalTimes.Areas.CharCreation.Models
{
    public class Dice
    {
        [Key]
        public Guid DiceId { get; set; }
        public int NrDice { get; set; }
        public int DiceSide { get; set; }
        public int Modifier { get; set; }
    }
}
