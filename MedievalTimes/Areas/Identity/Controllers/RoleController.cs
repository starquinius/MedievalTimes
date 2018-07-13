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
    [Authorize(Roles = "Leader")]
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
                GebruikersIDRol = gebruikersRol,
                GebruikersRol = gebruikersRolId.ToString()                
            };

            //Show ViewModel
            return View(gebruikersDetail);
        }

        /// <summary>
        /// Save Changes Made To The Users Account
        /// </summary>
        /// <param name="gebruikersDetail"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Leader")]
        [AutoValidateAntiforgeryToken]
        public IActionResult ChangeUserRole(UserDetailVM gebruikersDetail)
        {
            if (ModelState.IsValid)
            {
                //Get eventually new Role for user from from
                var roleName = Enum.GetName(typeof(ApplicationUser.GebruikersRol), Convert.ToInt32(gebruikersDetail.GebruikersRol));
                var nieuweRol = _context.Roles.Single(rl => rl.Name == roleName);
                var oldRol = _context.UserRoles.Single(rl => rl.UserId == gebruikersDetail.Gebruikers.Id);

                //Set new role to the selected user (Single() works, because GuidIds are unique)
                var gebruiker = _context.Users.Single(usr => usr.Id == gebruikersDetail.Gebruikers.Id);

                //Get new role                
                IdentityUserRole<string> newRole = new IdentityUserRole<string> { UserId = gebruiker.Id, RoleId = nieuweRol.Id };       
                //Delete old record
                _context.UserRoles.Remove(oldRol);
                //Add new record
                _context.UserRoles.Add(newRole);                
                //Save all changes to DB Table
                _context.SaveChanges();          
            }
            else
            {
                //Return with error
                return View("ShowUser",gebruikersDetail);
            }

            return RedirectToAction("Index");
        }


    }


}




