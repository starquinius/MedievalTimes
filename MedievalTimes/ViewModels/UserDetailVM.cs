using MedievalTimes.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalTimes.ViewModels
{
    public class UserDetailVM
    {
        public ApplicationUser Gebruikers { get; set; }
        public IdentityRole GebruikersIDRol { get; set; }
        public String GebruikersRol { get; set; }
        public bool CorrectRole { get; set; }
    }
}
