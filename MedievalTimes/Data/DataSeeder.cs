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
            //Init
            List<Race> races;
            List<XpLeveling> xpLevels;

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
            if (_context.Races.Count() == 0)
            {
                Race[] race = new Race[]{
                    new Race{Name="Human",BaseAge=15, AgeModifier = new Dice(){ NrDice=1, DiceSide=4, Modifier=0}, BaseMaxAge=90, MaxAgeModifier = new Dice(){NrDice=2, DiceSide=20, Modifier=0}, BaseHeightF=59, BaseHeightM=60, HeightModifier = new Dice{NrDice=2, DiceSide=10, Modifier=0 }, BaseWeightF=100, BaseWeightM=140, WeightModifier=new Dice{ NrDice=6, DiceSide=10, Modifier=0}, RaceId = new Guid() },
                    new Race{Name="Elf",BaseAge=100, AgeModifier = new Dice(){ NrDice=5, DiceSide=6, Modifier=0}, BaseMaxAge=350, MaxAgeModifier = new Dice(){NrDice=4, DiceSide=100, Modifier=0}, BaseHeightF=50, BaseHeightM=55, HeightModifier = new Dice{NrDice=1, DiceSide=10, Modifier=0 }, BaseWeightF=70, BaseWeightM=90, WeightModifier=new Dice{ NrDice=3, DiceSide=10, Modifier=0}, RaceId = new Guid() },
                    new Race{Name="Dwarf",BaseAge=40, AgeModifier = new Dice(){ NrDice=5, DiceSide=6, Modifier=0}, BaseMaxAge=250, MaxAgeModifier = new Dice(){NrDice=2, DiceSide=100, Modifier=0}, BaseHeightF=41, BaseHeightM=43, HeightModifier = new Dice{NrDice=1, DiceSide=10, Modifier=0 }, BaseWeightF=105, BaseWeightM=130, WeightModifier=new Dice{ NrDice=4, DiceSide=10, Modifier=0}, RaceId = new Guid() },
                    new Race{Name="Gnome",BaseAge=60, AgeModifier = new Dice(){ NrDice=3, DiceSide=12, Modifier=0}, BaseMaxAge=200, MaxAgeModifier = new Dice(){NrDice=3, DiceSide=100, Modifier=0}, BaseHeightF=36, BaseHeightM=38, HeightModifier = new Dice{NrDice=1, DiceSide=6, Modifier=0 }, BaseWeightF=68, BaseWeightM=72, WeightModifier=new Dice{ NrDice=5, DiceSide=4, Modifier=0}, RaceId = new Guid() },
                    new Race{Name="Half-Elf",BaseAge=15, AgeModifier = new Dice(){ NrDice=1, DiceSide=6, Modifier=0}, BaseMaxAge=125, MaxAgeModifier = new Dice(){NrDice=3, DiceSide=20, Modifier=0}, BaseHeightF=58, BaseHeightM=60, HeightModifier = new Dice{NrDice=2, DiceSide=6, Modifier=0 }, BaseWeightF=85, BaseWeightM=110, WeightModifier=new Dice{ NrDice=3, DiceSide=12, Modifier=0}, RaceId = new Guid() },
                    new Race{Name="Halfling",BaseAge=20, AgeModifier = new Dice(){ NrDice=3, DiceSide=4, Modifier=0}, BaseMaxAge=100, MaxAgeModifier = new Dice(){NrDice=1, DiceSide=100, Modifier=0}, BaseHeightF=30, BaseHeightM=32, HeightModifier = new Dice{NrDice=2, DiceSide=8, Modifier=0 }, BaseWeightF=48, BaseWeightM=52, WeightModifier=new Dice{ NrDice=5, DiceSide=4, Modifier=0}, RaceId = new Guid() }
                };
                await _context.AddRangeAsync(race);
                races = race.ToList();

                //Seed Table (Race Attribute Requirement & Interval)
                if (_context.RacialAttrReq.Count() == 0)
                {
                    RacialAttributeAdjustment[] raceAttrAdj = new RacialAttributeAdjustment[] {
                        new RacialAttributeAdjustment{Race=races[0], MinStr=3, MaxStr=18, MinDex=3, MaxDex=18, MinCon=3, MaxCon=18, MinInt=3, MaxInt=18, MinWis=3, MaxWis=18, MinCha=3, MaxCha=18},
                        new RacialAttributeAdjustment{Race=races[1], MinStr=3, MaxStr=18, MinDex=6, MaxDex=18, MinCon=7, MaxCon=18, MinInt=8, MaxInt=18, MinWis=3, MaxWis=18, MinCha=8, MaxCha=18, DexModifier=1, ConModifier=-1 },
                        new RacialAttributeAdjustment{Race=races[2], MinStr=8, MaxStr=18, MinDex=3, MaxDex=17, MinCon=11, MaxCon=18, MinInt=3, MaxInt=18, MinWis=3, MaxWis=18, MinCha=3, MaxCha=17, ConModifier=1, ChaModifier=-1 },
                        new RacialAttributeAdjustment{Race=races[3], MinStr=6, MaxStr=18, MinDex=3, MaxDex=18, MinCon=8, MaxCon=18, MinInt=6, MaxInt=18, MinWis=3, MaxWis=18, MinCha=3, MaxCha=18, IntModifier=1, WisModifier=-1 },
                        new RacialAttributeAdjustment{Race=races[4], MinStr=3, MaxStr=18, MinDex=6, MaxDex=18, MinCon=6, MaxCon=18, MinInt=4, MaxInt=18, MinWis=3, MaxWis=18, MinCha=3, MaxCha=18 },
                        new RacialAttributeAdjustment{Race=races[5], MinStr=7, MaxStr=18, MinDex=7, MaxDex=18, MinCon=10, MaxCon=18, MinInt=6, MaxInt=18, MinWis=3, MaxWis=17, MinCha=3, MaxCha=18, DexModifier=1, StrModifier=-1 }
                    };

                    await _context.AddRangeAsync(raceAttrAdj);
                }
            }

            //Seed Table (Class Attribute Requirement & Prime Requisite & Allowed Races)
            if (_context.ClassAttrReq.Count() == 0)
            {
                ClassAbilityRequirements[] classAbilityRequirements = new ClassAbilityRequirements[]
                {
                        new ClassAbilityRequirements{ Id=new Guid(), Beroep = Beroep.fighter, MinStr=9, StrPrime=true, MinCon=0, ConPrime=false, MinDex=0, DexPrime=false, MinInt=0, IntPrime=false, MinWis=0, WisPrime=false, MinCha=0, ChaPrime=false,  RaceDwarf=true, RaceElf=true, RaceGnome=true, RaceHalfElf=true, RaceHalfling=true, RaceHuman=true},
                        new ClassAbilityRequirements{ Id=new Guid(), Beroep = Beroep.mage, MinStr=0, StrPrime=false, MinCon=0, ConPrime=false, MinDex=0, DexPrime=false, MinInt=9, IntPrime=true, MinWis=0, WisPrime=false, MinCha=0, ChaPrime=false, RaceDwarf=false, RaceElf=true, RaceGnome=false, RaceHalfElf=true, RaceHalfling=false, RaceHuman=true},
                        new ClassAbilityRequirements{ Id=new Guid(), Beroep = Beroep.cleric, MinStr=0, StrPrime=false, MinCon=0, ConPrime=false, MinDex=0, DexPrime=false, MinInt=0, IntPrime=false, MinWis=9, WisPrime=true, MinCha=0, ChaPrime=false, RaceDwarf=true, RaceElf=true, RaceGnome=true, RaceHalfElf=true, RaceHalfling=true, RaceHuman=true}

                };
                await _context.AddRangeAsync(classAbilityRequirements);
            }

            //Seed XP Leveling Table
            if (_context.XpLeveling.Count() == 0)
            {
                XpLeveling[] xpLeveling = new XpLeveling[]
                {
                    new XpLeveling{ Id=new Guid(), XpNeededLvl1=0, XpNeededLvl2=2000, XpNeededLvl3=4000, XpNeededLvl4=8000, XpNeededLvl5=16000, XpNeededLvl6=32000, XpNeededLvl7=64000, XpNeededLvl8=125000, XpNeededLvl9=250000, XpNeededLvl10=500000, XpNeededLvl11=750000, XpNeededLvl12=1000000, XpNeededLvl13=1250000, XpNeededLvl14=1500000, XpNeededLvl15=1750000, XpNeededLvl16=2000000, XpNeededLvl17=2250000, XpNeededLvl18=2500000, XpNeededLvl19=2750000, XpNeededLvl20=3000000, XpNeededMax=250000},
                    new XpLeveling{ Id=new Guid(), XpNeededLvl1=0, XpNeededLvl2=2500, XpNeededLvl3=5000, XpNeededLvl4=10000, XpNeededLvl5=20000, XpNeededLvl6=40000, XpNeededLvl7=60000, XpNeededLvl8=90000, XpNeededLvl9=135000, XpNeededLvl10=250000, XpNeededLvl11=375000, XpNeededLvl12=750000, XpNeededLvl13=1125000, XpNeededLvl14=1500000, XpNeededLvl15=1875000, XpNeededLvl16=2250000, XpNeededLvl17=2625000, XpNeededLvl18=3000000, XpNeededLvl19=3375000, XpNeededLvl20=3750000, XpNeededMax=375000},
                    new XpLeveling{ Id=new Guid(), XpNeededLvl1=0, XpNeededLvl2=1500, XpNeededLvl3=3000, XpNeededLvl4=6000, XpNeededLvl5=13000, XpNeededLvl6=27500, XpNeededLvl7=55000, XpNeededLvl8=110000, XpNeededLvl9=225000, XpNeededLvl10=450000, XpNeededLvl11=675000, XpNeededLvl12=900000, XpNeededLvl13=1125000, XpNeededLvl14=1350000, XpNeededLvl15=1575000, XpNeededLvl16=1800000, XpNeededLvl17=2025000, XpNeededLvl18=2250000, XpNeededLvl19=2475000, XpNeededLvl20=2700000, XpNeededMax=225000}
                };
                await _context.AddRangeAsync(xpLeveling);
                xpLevels = xpLeveling.ToList();

                //Seed Classes
                if (_context.Classes.Count() == 0)
                {
                    Class[] beroepenTable = new Class[]
                    {
                        new Class{ ClassId=new Guid(), Name = Beroep.fighter, HitDiceMaxLvl=9, HitDiceMaxLvlModifier=3, HitDiceNr=1, HitDiceSide=10, XpLeveling= xpLevels[0]},
                        new Class{ ClassId=new Guid(), Name = Beroep.mage, HitDiceMaxLvl=10, HitDiceMaxLvlModifier=1, HitDiceNr=1, HitDiceSide=4, XpLeveling= xpLevels[1]},
                        new Class{ ClassId=new Guid(), Name = Beroep.cleric, HitDiceMaxLvl=9, HitDiceMaxLvlModifier=2, HitDiceNr=1, HitDiceSide=8, XpLeveling= xpLevels[2]}

                    };
                    await _context.AddRangeAsync(beroepenTable);
                }
            }





            await _context.SaveChangesAsync();
        }
    }
}
