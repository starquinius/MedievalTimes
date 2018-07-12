using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MedievalTimes.Areas.Identity.Data;
using MedievalTimes.Data;
using MedievalTimes.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedievalTimes.Areas.Identity.Controllers
{
    [Authorize(Roles ="Leader")]
    public class RoleController : Controller
    {

        //****************************************************************** Injections

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public RoleController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //****************************************************************** Methods
        
        public IActionResult Index()
        {
            var namenLijst = _context.Users.Select(user => user.Name).ToList();

            return View(namenLijst);
        }

        /// <summary>
        /// Show UserDetails including Role (selection by username)
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public IActionResult ShowUser(string userName)
        {
  
            //Get selected Userinfo         
            var gebruiker = _context.Users.Where(usr => usr.Name == userName).FirstOrDefault();
            //Get role of the selected user
            var gebruikersRolId = _context.UserRoles.Where(rle => rle.UserId == gebruiker.Id).FirstOrDefault();
            var gebruikersRol = _context.Roles.Where(rl => rl.Id == gebruikersRolId.RoleId).FirstOrDefault();

            //Build ViewModel
            UserDetailVM gebruikersDetail = new UserDetailVM()
            {
                Gebruikers = gebruiker,
                GebruikersRol = gebruikersRol
            };

            //Show ViewModel
            return View(gebruikersDetail);
        }


    }
}




