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
                        new Class{ ClassId=new Guid(), Name = Beroep.fighter, HitDiceMaxLvl=9, HitDiceMaxLvlModifier=3, HitDiceNr=1, HitDiceSide=10, XpLeveling= xpLevels[0], WPinit=4, WPperLvl=3, NotProficientPenalty=-2, NWPinit=3, NWPperLvl=3 },
                        new Class{ ClassId=new Guid(), Name = Beroep.mage, HitDiceMaxLvl=10, HitDiceMaxLvlModifier=1, HitDiceNr=1, HitDiceSide=4, XpLeveling= xpLevels[1], WPinit=1, WPperLvl=6, NotProficientPenalty=-5, NWPinit=4, NWPperLvl=3 },
                        new Class{ ClassId=new Guid(), Name = Beroep.cleric, HitDiceMaxLvl=9, HitDiceMaxLvlModifier=2, HitDiceNr=1, HitDiceSide=8, XpLeveling= xpLevels[2], WPinit=2, WPperLvl=4, NotProficientPenalty=-3, NWPinit=4, NWPperLvl=3 }

                    };
                    await _context.AddRangeAsync(beroepenTable);
                }
            }

            //Seed Attribute - Strength
            if (_context.Strength.Count() == 0)
            {
                AttrStrength[] strengthTable = new AttrStrength[]
                {
                    new AttrStrength{ Id=new Guid(), Str=1, HitProb=-5, DmgAdj=-4, WeightAllow=1, MaxPress=3, OpenDoors=1, OpenClosedDoors=0, BendBarsLiftGates=0, Notes=""},
                    new AttrStrength{ Id=new Guid(), Str=2, HitProb=-3, DmgAdj=-2, WeightAllow=1, MaxPress=5, OpenDoors=1, OpenClosedDoors=0, BendBarsLiftGates=0, Notes=""},
                    new AttrStrength{ Id=new Guid(), Str=3, HitProb=-3, DmgAdj=-1, WeightAllow=5, MaxPress=10, OpenDoors=2, OpenClosedDoors=0, BendBarsLiftGates=0, Notes=""},
                    new AttrStrength{ Id=new Guid(), Str=4, HitProb=-2, DmgAdj=-1, WeightAllow=10, MaxPress=25, OpenDoors=3, OpenClosedDoors=0, BendBarsLiftGates=0, Notes=""},
                    new AttrStrength{ Id=new Guid(), Str=5, HitProb=-2, DmgAdj=-1, WeightAllow=10, MaxPress=25, OpenDoors=3, OpenClosedDoors=0, BendBarsLiftGates=0, Notes=""},
                    new AttrStrength{ Id=new Guid(), Str=6, HitProb=-1, DmgAdj=0, WeightAllow=20, MaxPress=55, OpenDoors=4, OpenClosedDoors=0, BendBarsLiftGates=0, Notes=""},
                    new AttrStrength{ Id=new Guid(), Str=7, HitProb=-1, DmgAdj=0, WeightAllow=20, MaxPress=55, OpenDoors=4, OpenClosedDoors=0, BendBarsLiftGates=0, Notes=""},
                    new AttrStrength{ Id=new Guid(), Str=8, HitProb=0, DmgAdj=0, WeightAllow=35, MaxPress=90, OpenDoors=5, OpenClosedDoors=0, BendBarsLiftGates=0, Notes=""},
                    new AttrStrength{ Id=new Guid(), Str=9, HitProb=0, DmgAdj=0, WeightAllow=35, MaxPress=90, OpenDoors=5, OpenClosedDoors=0, BendBarsLiftGates=0, Notes=""},
                    new AttrStrength{ Id=new Guid(), Str=10, HitProb=0, DmgAdj=0, WeightAllow=40, MaxPress=115, OpenDoors=6, OpenClosedDoors=0, BendBarsLiftGates=0, Notes=""},
                    new AttrStrength{ Id=new Guid(), Str=11, HitProb=0, DmgAdj=0, WeightAllow=40, MaxPress=115, OpenDoors=6, OpenClosedDoors=0, BendBarsLiftGates=0, Notes=""},
                    new AttrStrength{ Id=new Guid(), Str=12, HitProb=0, DmgAdj=0, WeightAllow=45, MaxPress=140, OpenDoors=7, OpenClosedDoors=0, BendBarsLiftGates=0, Notes=""},
                    new AttrStrength{ Id=new Guid(), Str=13, HitProb=0, DmgAdj=0, WeightAllow=45, MaxPress=140, OpenDoors=7, OpenClosedDoors=0, BendBarsLiftGates=0, Notes=""},
                    new AttrStrength{ Id=new Guid(), Str=14, HitProb=0, DmgAdj=0, WeightAllow=55, MaxPress=170, OpenDoors=8, OpenClosedDoors=0, BendBarsLiftGates=0, Notes=""},
                    new AttrStrength{ Id=new Guid(), Str=15, HitProb=0, DmgAdj=0, WeightAllow=55, MaxPress=170, OpenDoors=8, OpenClosedDoors=0, BendBarsLiftGates=0, Notes=""},
                    new AttrStrength{ Id=new Guid(), Str=16, HitProb=0, DmgAdj=1, WeightAllow=70, MaxPress=195, OpenDoors=9, OpenClosedDoors=0, BendBarsLiftGates=0, Notes=""},
                    new AttrStrength{ Id=new Guid(), Str=17, HitProb=1, DmgAdj=1, WeightAllow=85, MaxPress=220, OpenDoors=10, OpenClosedDoors=0, BendBarsLiftGates=0, Notes=""},
                    new AttrStrength{ Id=new Guid(), Str=18, HitProb=1, DmgAdj=2, WeightAllow=110, MaxPress=255, OpenDoors=11, OpenClosedDoors=0, BendBarsLiftGates=0, Notes=""},
                    new AttrStrength{ Id=new Guid(), Str=18, HitProb=1, DmgAdj=3, WeightAllow=135, MaxPress=280, OpenDoors=12, OpenClosedDoors=0, BendBarsLiftGates=0, Notes="", StrMinP=1, StrMaxP=50},
                    new AttrStrength{ Id=new Guid(), Str=18, HitProb=2, DmgAdj=3, WeightAllow=160, MaxPress=305, OpenDoors=13, OpenClosedDoors=0, BendBarsLiftGates=0, Notes="", StrMinP=51, StrMaxP=75},
                    new AttrStrength{ Id=new Guid(), Str=18, HitProb=2, DmgAdj=4, WeightAllow=185, MaxPress=330, OpenDoors=14, OpenClosedDoors=0, BendBarsLiftGates=0, Notes="", StrMinP=76, StrMaxP=90},
                    new AttrStrength{ Id=new Guid(), Str=18, HitProb=2, DmgAdj=5, WeightAllow=235, MaxPress=380, OpenDoors=15, OpenClosedDoors=3, BendBarsLiftGates=0, Notes="", StrMinP=91, StrMaxP=99},
                    new AttrStrength{ Id=new Guid(), Str=18, HitProb=3, DmgAdj=6, WeightAllow=335, MaxPress=480, OpenDoors=16, OpenClosedDoors=6, BendBarsLiftGates=0, Notes="", StrMinP=100, StrMaxP=100},
                    new AttrStrength{ Id=new Guid(), Str=19, HitProb=3, DmgAdj=7, WeightAllow=485, MaxPress=640, OpenDoors=16, OpenClosedDoors=8, BendBarsLiftGates=0, Notes="Strong as a hill giant."},
                    new AttrStrength{ Id=new Guid(), Str=20, HitProb=3, DmgAdj=8, WeightAllow=535, MaxPress=700, OpenDoors=17, OpenClosedDoors=10, BendBarsLiftGates=0, Notes="Strong as a stone giant."},
                    new AttrStrength{ Id=new Guid(), Str=21, HitProb=4, DmgAdj=9, WeightAllow=635, MaxPress=810, OpenDoors=17, OpenClosedDoors=12, BendBarsLiftGates=0, Notes="Strong as a frost giant."},
                    new AttrStrength{ Id=new Guid(), Str=22, HitProb=4, DmgAdj=10, WeightAllow=785, MaxPress=970, OpenDoors=18, OpenClosedDoors=14, BendBarsLiftGates=0, Notes="Strong as a fire giant."},
                    new AttrStrength{ Id=new Guid(), Str=23, HitProb=5, DmgAdj=11, WeightAllow=935, MaxPress=1130, OpenDoors=18, OpenClosedDoors=16, BendBarsLiftGates=0, Notes="Strong as a cloud giant."},
                    new AttrStrength{ Id=new Guid(), Str=24, HitProb=6, DmgAdj=12, WeightAllow=1235, MaxPress=1440, OpenDoors=19, OpenClosedDoors=17, BendBarsLiftGates=0, Notes="Strong as a storm giant."},
                    new AttrStrength{ Id=new Guid(), Str=25, HitProb=7, DmgAdj=14, WeightAllow=1535, MaxPress=1750, OpenDoors=19, OpenClosedDoors=18, BendBarsLiftGates=0, Notes="Strong as a titan."}
                };
                await _context.AddRangeAsync(strengthTable);
            }

            //Seed Attribute - Dexterity
            if (_context.Dexterity.Count() == 0)
            {
                AttrDexterity[] dexterityTable = new AttrDexterity[]
                {
                    new AttrDexterity{Id=new Guid(), Dex=1, ReactionAdj=-6, MissileAttackAdj=-6, DefensiveAdj=5},
                    new AttrDexterity{Id=new Guid(), Dex=2, ReactionAdj=-4, MissileAttackAdj=-4, DefensiveAdj=5},
                    new AttrDexterity{Id=new Guid(), Dex=3, ReactionAdj=-3, MissileAttackAdj=-3, DefensiveAdj=4},
                    new AttrDexterity{Id=new Guid(), Dex=4, ReactionAdj=-2, MissileAttackAdj=-2, DefensiveAdj=3},
                    new AttrDexterity{Id=new Guid(), Dex=5, ReactionAdj=-1, MissileAttackAdj=-1, DefensiveAdj=2},
                    new AttrDexterity{Id=new Guid(), Dex=6, ReactionAdj=0, MissileAttackAdj=0, DefensiveAdj=1},
                    new AttrDexterity{Id=new Guid(), Dex=7, ReactionAdj=0, MissileAttackAdj=0, DefensiveAdj=0},
                    new AttrDexterity{Id=new Guid(), Dex=8, ReactionAdj=0, MissileAttackAdj=0, DefensiveAdj=0},
                    new AttrDexterity{Id=new Guid(), Dex=9, ReactionAdj=0, MissileAttackAdj=0, DefensiveAdj=0},
                    new AttrDexterity{Id=new Guid(), Dex=10, ReactionAdj=0, MissileAttackAdj=0, DefensiveAdj=0},
                    new AttrDexterity{Id=new Guid(), Dex=11, ReactionAdj=0, MissileAttackAdj=0, DefensiveAdj=0},
                    new AttrDexterity{Id=new Guid(), Dex=12, ReactionAdj=0, MissileAttackAdj=0, DefensiveAdj=0},
                    new AttrDexterity{Id=new Guid(), Dex=13, ReactionAdj=0, MissileAttackAdj=0, DefensiveAdj=0},
                    new AttrDexterity{Id=new Guid(), Dex=14, ReactionAdj=0, MissileAttackAdj=0, DefensiveAdj=0},
                    new AttrDexterity{Id=new Guid(), Dex=15, ReactionAdj=0, MissileAttackAdj=0, DefensiveAdj=-1},
                    new AttrDexterity{Id=new Guid(), Dex=16, ReactionAdj=1, MissileAttackAdj=1, DefensiveAdj=-2},
                    new AttrDexterity{Id=new Guid(), Dex=17, ReactionAdj=2, MissileAttackAdj=2, DefensiveAdj=-3},
                    new AttrDexterity{Id=new Guid(), Dex=18, ReactionAdj=2, MissileAttackAdj=2, DefensiveAdj=-4},
                    new AttrDexterity{Id=new Guid(), Dex=19, ReactionAdj=3, MissileAttackAdj=3, DefensiveAdj=-4},
                    new AttrDexterity{Id=new Guid(), Dex=20, ReactionAdj=3, MissileAttackAdj=3, DefensiveAdj=-4},
                    new AttrDexterity{Id=new Guid(), Dex=21, ReactionAdj=4, MissileAttackAdj=4, DefensiveAdj=-5},
                    new AttrDexterity{Id=new Guid(), Dex=22, ReactionAdj=4, MissileAttackAdj=4, DefensiveAdj=-5},
                    new AttrDexterity{Id=new Guid(), Dex=23, ReactionAdj=4, MissileAttackAdj=4, DefensiveAdj=-5},
                    new AttrDexterity{Id=new Guid(), Dex=24, ReactionAdj=5, MissileAttackAdj=5, DefensiveAdj=-6},
                    new AttrDexterity{Id=new Guid(), Dex=25, ReactionAdj=5, MissileAttackAdj=5, DefensiveAdj=-6 }
                };
                await _context.AddRangeAsync(dexterityTable);
            }

            if (_context.Weapons.Count() == 0)
            {
                Weapon[] wapensLijst = new Weapon[]
                {
                    //new Weapon{ Id=new Guid(), Name="", Cost=, Weight=, Size=WSize, Type=WType, SpeedFactor=, DamageSMnrDice=, DamageSMDiceSide=, DamageSAdj=, DamageLnrDice=, DamageLDiceSide=, DamageLAdj=, ROFnr=, ROFrnd=, RangeS=, RangeM=, RangeL=},
                    new Weapon{ Id=new Guid(), Name="Arquebus", Cost=500, Weight=10, Size=WSize.Medium, Type=WType.Piercing, SpeedFactor=15, DamageSMnrDice=1, DamageSMDiceSide=10, DamageSAdj=0, DamageLnrDice=1, DamageLDiceSide=10, DamageLAdj=0, ROFnr=1, ROFrnd=3, RangeS=50, RangeM=150, RangeL=210},
                    new Weapon{ Id=new Guid(), Name="Battle Axe", Cost=5, Weight=7, Size=WSize.Medium, Type=WType.Slashing, SpeedFactor=7, DamageSMnrDice=1, DamageSMDiceSide=8, DamageSAdj=0, DamageLnrDice=1, DamageLDiceSide=8, DamageLAdj=0, ROFnr=0, ROFrnd=0, RangeS=0, RangeM=0, RangeL=0},
                    new Weapon{ Id=new Guid(), Name="Bow, Short", Cost=30, Weight=2, Size=WSize.Medium, Type=WType.Piercing, SpeedFactor=7, DamageSMnrDice=1, DamageSMDiceSide=6, DamageSAdj=0, DamageLnrDice=1, DamageLDiceSide=6, DamageLAdj=0, ROFnr=2, ROFrnd=1, RangeS=50, RangeM=100, RangeL=150}
                };
                await _context.AddRangeAsync(wapensLijst);
            }

            await _context.SaveChangesAsync();
        }
    }
}
