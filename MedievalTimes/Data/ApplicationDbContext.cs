using System;
using System.Collections.Generic;
using System.Text;
using MedievalTimes.Areas.CharCreation.Models;
using MedievalTimes.Areas.Identity.Data;
using MedievalTimes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedievalTimes.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RacialAttributeAdjustment> RacialAttrReq { get; set; }
        public DbSet<ClassAbilityRequirements> ClassAttrReq { get; set; }
        public DbSet<XpLeveling> XpLeveling { get; set; }

        public DbSet<Race> Races { get; set; }
        public DbSet<Class> Classes { get; set; }


        public DbSet<Character> Characters { get; set; }

    }
}
