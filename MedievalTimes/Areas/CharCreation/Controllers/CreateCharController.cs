using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedievalTimes.Areas.CharCreation.Models;
using MedievalTimes.Areas.CharCreation.ViewModels;
using MedievalTimes.Areas.Identity.Data;
using MedievalTimes.Models;
using MedievalTimes.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MedievalTimes.Areas.CharCreation.Controllers
{
    public class CreateCharController : Controller
    {
        //****************************************************************** Injections
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public CreateCharController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //****************************************************************** Action Methods
        public IActionResult StartCreation()
        {
            CharacterVM characterVM = new CharacterVM();

            return View("~/Areas/CharCreation/Views/CreateChar/StartCreation.cshtml", characterVM);
        }

        public IActionResult SubmitChar(CharacterVM characterVM, int pageNr)
        {
            Character character = new Character();

            switch (pageNr)
            {                
                case 1:
                    //Place Generic Info in temp character
                    character = new Character()
                    {
                        Id = new Guid(),
                        Name = characterVM.Name,
                        Alignment = characterVM.Alignment,
                        Attitude = characterVM.Attitude,
                        IsFinished = false
                    };
                    //Save temp character to Db
                    _context.Add(character);
                    _context.SaveChanges();
                    //To recognize the build of correct character
                    characterVM.BuildId = character.Id;
                    //Goto Attributes
                    return View("~/Areas/CharCreation/Views/CreateChar/CreateAttributes.cshtml", characterVM);

                case 2:
                    //Get correct build character
                    character = _context.Characters.Single(record => record.Id == characterVM.BuildId);
                    //Place Attribute Info
                    character.Attributes = characterVM.Attributes;
                    //Save temp character to Db
                    _context.Update(character);
                    _context.SaveChanges();
                    //Filter choosable classes
                    characterVM = GetRaces(characterVM);
                    return View("~/Areas/CharCreation/Views/CreateChar/SelectRace.cshtml", characterVM);

                case 3:
                    //Get correct build character
                    character = _context.Characters.Include(rec => rec.Attributes).Single(record => record.Id == characterVM.BuildId);
                    //Place chosen race                    
                    character.Races = _context.Races.Single(record => record.Name == characterVM.Races.Name);
                    //Update attributes according to race
                    character = UpdateAttributes(character);
                    //Save temp character to Db
                    _context.Update(character);
                    _context.SaveChanges();
                    //Filter choosable classes
                    characterVM = GetClasses(characterVM);
                    return View("~/Areas/CharCreation/Views/CreateChar/SelectClass.cshtml", characterVM);
                //****************************************************************************************************************************** WIP WIP WIP WIP !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                case 4:
                    
                    return View("~/Areas/CharCreation/Views/CreateChar/SelectWeaponSkills.cshtml", characterVM);
                case 5:
                    return View("~/Areas/CharCreation/Views/CreateChar/SelectNonWeaponSkills.cshtml", characterVM);
            }

            //Or when first page
            return View("~/Areas/CharCreation/Views/CreateChar/StartCreation.cshtml", characterVM);
        }
        
        //****************************************************************** Generic Methods
        /// <summary>
        /// Filter the races with the attributes requirements
        /// </summary>
        /// <param name="characterVM"></param>
        /// <returns></returns>
        private CharacterVM GetRaces(CharacterVM characterVM)
        {

            var raceList = _context.RacialAttrReq.Where(req => (req.MinStr <= characterVM.Attributes.Strength) && (req.MaxStr >= characterVM.Attributes.Strength)
                                                           && (req.MinDex <= characterVM.Attributes.Dexterity) && (req.MaxDex >= characterVM.Attributes.Dexterity)
                                                           && (req.MinCon <= characterVM.Attributes.Constitution) && (req.MaxCon >= characterVM.Attributes.Constitution)
                                                           && (req.MinInt <= characterVM.Attributes.Intelligence) && (req.MaxInt >= characterVM.Attributes.Intelligence)
                                                           && (req.MinWis <= characterVM.Attributes.Wisdom) && (req.MaxWis >= characterVM.Attributes.Wisdom)
                                                           && (req.MinCha <= characterVM.Attributes.Charisma) && (req.MaxCha >= characterVM.Attributes.Charisma))
                                                        .Select(records => records.Race)
                                                        .ToList();

            RaceVM raceVM = new RaceVM();
            List<RaceVM> raceVMList = new List<RaceVM>();

            foreach(var race in raceList)
            {
                raceVM = new RaceVM
                {
                    Race = race                 
                };
                raceVMList.Add(raceVM);
            }

            characterVM.ChoosableRaces = raceVMList;

            return characterVM;
        }

        /// <summary>
        /// Update the attributes according to the chosen race
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        private Character UpdateAttributes (Character character)
        {
            //Get correct record (race line) from adjustment table
            RacialAttributeAdjustment attrAdj = new RacialAttributeAdjustment();
            attrAdj = _context.RacialAttrReq.Where(record => record.Race.RaceId == character.Races.RaceId).SingleOrDefault();
            //Change the correct attributes accordingly
            character.Attributes.Strength += attrAdj.StrModifier;
            character.Attributes.Dexterity += attrAdj.DexModifier;
            character.Attributes.Constitution += attrAdj.ConModifier;
            character.Attributes.Intelligence += attrAdj.IntModifier;
            character.Attributes.Wisdom += attrAdj.WisModifier;
            character.Attributes.Charisma += attrAdj.ChaModifier;

            return character;
        }

        /// <summary>
        /// Filter the classes according to race, alignment and attributes
        /// </summary>
        /// <param name="characterVM"></param>
        /// <returns></returns>
        private CharacterVM GetClasses(CharacterVM characterVM)
        {
            List<ClassAbilityRequirements> choosableClasses;

            switch (characterVM.Races.Name)
            {
                case "Human":
                    choosableClasses = _context.ClassAttrReq.Where(record => record.RaceHuman == true).ToList();
                    break;
                case "Elf":
                    choosableClasses = _context.ClassAttrReq.Where(record => record.RaceElf == true).ToList();
                    break;
                case "Dwarf":
                    choosableClasses = _context.ClassAttrReq.Where(record => record.RaceDwarf == true).ToList();
                    break;
                case "Halfling":
                    choosableClasses = _context.ClassAttrReq.Where(record => record.RaceHalfling == true).ToList();
                    break;
                case "Half-Elf":
                    choosableClasses = _context.ClassAttrReq.Where(record => record.RaceHalfElf == true).ToList();
                    break;
                case "Gnome":
                    choosableClasses = _context.ClassAttrReq.Where(record => record.RaceGnome == true).ToList();
                    break;
            }

            ClassVM classVM = new ClassVM();
            List<ClassVM> classVMList = new List<ClassVM>();

            foreach (var race in classVMList)
            {
                classVM = new ClassVM
                {
                     Beroepen = race.Beroepen
                };
                classVMList.Add(classVM);
            }

            characterVM.ChoosableClasses = classVMList;


            return characterVM;
        }

    }
}