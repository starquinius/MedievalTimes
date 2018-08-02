using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalTimes.Models
{
    public class WeaponProficiency
    {
        public Guid Id { get; set; }
        public Weapon Weapon { get; set; }
        public int ProficiencySlots { get; set; }

    }
}
