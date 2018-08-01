﻿using System;
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
            switch (pageNr)
            {                
                case 1:
                    return View("~/Areas/CharCreation/Views/CreateChar/CreateAttributes.cshtml", characterVM);
                case 2:
                    characterVM = GetRaces(characterVM);
                    return View("~/Areas/CharCreation/Views/CreateChar/SelectRace.cshtml", characterVM);
                case 3:
                    break;
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

            foreach(var race in raceList)
            {
                raceVM = new RaceVM
                {
                    Race = race,
                    Chosen = false
                     
                };

                characterVM.ChoosableRaces.Add(raceVM);
            }


            return characterVM;
        }


    }
}