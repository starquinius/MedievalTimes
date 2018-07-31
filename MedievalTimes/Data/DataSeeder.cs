using MedievalTimes.Areas.CharCreation.Models;
using MedievalTimes.Areas.Identity.Data;
using MedievalTimes.Models;
using MedievalTimes.Repo;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalTimes.Data
{
    public class DataSeeder
    {
        //****************************************************************** Injections
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public DataSeeder(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //****************************************************************** Methods
        public async Task Seed()
        {
            //Seed Roles
            if (_context.Users.Count() != 0)
            {
                RoleRepo RRepo = new RoleRepo(_userManager, _roleManager, _context);
                await RRepo.AddRole("Player");
                await RRepo.AddRole("Creator");
                await RRepo.AddRole("Admin");
                await RRepo.AddRole("Leader");

                if (_context.Users.Where(user => user.UserName == "fantasy@zeelandnet.nl").Count() != 0)
                    await RRepo.DistributeRole(
                       _context.Users.Where(user => user.UserName == "fantasy@zeelandnet.nl")
                       .FirstOrDefault(), "Leader");
            }

            //Seed Races
            if (_context.Races.Count() != 0)
            {
                Race[] race = new Race[]{
                    new Race{Name="Human"},
                    new Race{Name="Elf"},
                    new Race{Name="Dwarf"},
                    new Race{Name="Gnome"},
                    new Race{Name="Half-Elf"},
                    new Race{Name="Halfling"}
                };
                await _context.AddRangeAsync(race);
                var races = race.ToList();

                //Seed Table (Race Attribute Requirement & Interval)
                if (_context.RacialAttrReq.Count() != 0)
                {
                    RacialAttributeAdjustment[] raceAttrAdj = new RacialAttributeAdjustment[] {
                        new RacialAttributeAdjustment{Race=races[0]},
                        new RacialAttributeAdjustment{Race=races[1], MinStr=3, MaxStr=18, MinDex=6, MaxDex=18, MinCon=7, MaxCon=18, MinInt=8, MaxInt=18, MinWis=3, MaxWis=18, MinCha=8, MaxCha=18, DexModifier=1, ConModifier=-1 },
                        new RacialAttributeAdjustment{Race=races[2], MinStr=8, MaxStr=18, MinDex=3, MaxDex=17, MinCon=11, MaxCon=18, MinInt=3, MaxInt=18, MinWis=3, MaxWis=18, MinCha=3, MaxCha=17, ConModifier=1, ChaModifier=-1 },
                        new RacialAttributeAdjustment{Race=races[3], MinStr=6, MaxStr=18, MinDex=3, MaxDex=18, MinCon=8, MaxCon=18, MinInt=6, MaxInt=18, MinWis=3, MaxWis=18, MinCha=3, MaxCha=18, IntModifier=1, WisModifier=-1 },
                        new RacialAttributeAdjustment{Race=races[4], MinStr=3, MaxStr=18, MinDex=6, MaxDex=18, MinCon=6, MaxCon=18, MinInt=4, MaxInt=18, MinWis=3, MaxWis=18, MinCha=3, MaxCha=18 },
                        new RacialAttributeAdjustment{Race=races[5], MinStr=7, MaxStr=18, MinDex=7, MaxDex=18, MinCon=10, MaxCon=18, MinInt=6, MaxInt=18, MinWis=3, MaxWis=17, MinCha=3, MaxCha=18, DexModifier=1, StrModifier=-1 }
                    };
                }
            }
        }
    }
}
