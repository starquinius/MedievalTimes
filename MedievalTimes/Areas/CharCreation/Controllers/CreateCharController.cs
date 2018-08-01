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
            Character character;

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
                    //To recognize the build of correct character
                    character.BuildId = character.Id;
                    characterVM.BuildId = character.BuildId;
                    //Save temp character to Db
                    _context.Add(character);
                    _context.SaveChanges();
                    //Goto Attributes
                    return View("~/Areas/CharCreation/Views/CreateChar/CreateAttributes.cshtml", characterVM);
                case 2:
                    //Get correct build character
                    character = _context.Characters.Single(record => record.BuildId == characterVM.BuildId);
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
                    character = _context.Characters.Single(record => record.BuildId == characterVM.BuildId);

                    characterVM = GetClasses(characterVM);
                    characterVM.Races = characterVM.ChoosableRaces.Where(race => race.Chosen = true).FirstOrDefault().Race;
                    return View("~/Areas/CharCreation/Views/CreateChar/SelectClass.cshtml", characterVM);
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
                    Race = race,
                    Chosen = false                     
                };
                raceVMList.Add(raceVM);
            }

            characterVM.ChoosableRaces = raceVMList;

            return characterVM;
        }

        private CharacterVM GetClasses(CharacterVM characterVM)
        {
            return characterVM;
        }

    }
}