using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MedievalTimes.Areas.CharCreation.Models;
using MedievalTimes.Areas.Identity.Data;
using MedievalTimes.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MedievalTimes.Areas.CharCreation.Controllers
{
    public class ShowCharController : Controller
    {
        //****************************************************************************************************************************************
        //* Injections *
        //**************

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public ShowCharController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //****************************************************************************************************************************************
        //* Methods *
        //***********
        public IActionResult Index()
        {
            //init
            List<Character> characterListing = null;

            //var userRole = ((ClaimsIdentity)User.Identity).Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            var user = User.Identity;
            if (user.Name != null)
            {
                var userId = _context.Users.Single(record => record.UserName == user.Name).Id;
                var userRoleId = _context.UserRoles.Single(record => record.UserId == userId).RoleId;
                var userRole = _context.Roles.Single(record => record.Id == userRoleId);

                //If user is in a Leader role, all created characters in Db are shown
                if (userRole.ToString() == "Leader")
                {
                    characterListing = _context.Characters.ToList();
                }
                //if not in Leader role, only own created characters are shown
                else
                {
                    characterListing = _context.Characters.Where(record => record.CharOwner == user.Name).ToList();
                }

                return View("~/Areas/CharCreation/Views/ShowChar/Index.cshtml", characterListing);
            }
            else
                return View("~/Areas/CharCreation/Views/ShowChar/NotLoggedIn.cshtml");
        }
    }
}