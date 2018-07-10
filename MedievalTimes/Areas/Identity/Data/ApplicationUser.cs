using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalTimes.Areas.Identity.Data
{
    public class ApplicationUser:IdentityUser
    {
        public enum GebruikersRol { Player, Creator, Admin, Leader}

        public string Name { get; set; }
        public GebruikersRol DesiredRol { get; set; }
    }
}
