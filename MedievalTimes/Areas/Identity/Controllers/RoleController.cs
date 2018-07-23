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
    //*****************************************************************************************
    //I made this controller in the Identity Area, because it's about changing Identity Records
    //*****************************************************************************************

    //Only Leader role can change records within the Identity Tables.
    [Authorize(Roles = "Leader")]
    public class RoleController : Controller
    {
        //****************************************************************************************************************************************
        //* Injections *
        //**************

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public RoleController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
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
            List<UserListVM> gebruikersLijst = new List<UserListVM>();

            //add each user to list (checks if role is desired role)
            foreach (var user in _context.Users)
            {
                //Put correct info in gebruiker
                UserListVM gebruiker = new UserListVM()
                {
                    userName = user.Name,
                    correctRole = CheckRole(user)
                };

                //Add gebruiker to list
                gebruikersLijst.Add(gebruiker);
            }

            //Order correctrole, then on username alfa
            gebruikersLijst = gebruikersLijst.OrderBy(gebr => gebr.correctRole).ThenBy(gbr => gbr.userName).ToList();

            //Show userlisting (order by correctrole)
            return View(gebruikersLijst);
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

            UserDetailVM gebruikersDetail = new UserDetailVM()
            {
                Gebruikers = gebruiker,
                GebruikersIDRol = GetRole(gebruiker),
                GebruikersRol = GetRole(gebruiker).ToString(),
                CorrectRole = CheckRole(gebruiker)
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
                var gebruiker = _context.Users.Single(usr => usr.Id == gebruikersDetail.Gebruikers.Id);

                //Check if at least 1 leader role keeps present <======================================================================================================
                var leaderRoleId = _context.Roles.Where(rolename => rolename.Name == "Leader").FirstOrDefault().Id;
                var aantalLeaders = _context.UserRoles.Where(roleid => roleid.RoleId == leaderRoleId).Count();
                var currentUserRole = _context.UserRoles.Single(plr => plr.UserId == gebruiker.Id);

                //Check : are their remaining leaders, is the change effecting a leader to a not leader role
                if ((aantalLeaders == 1) && (currentUserRole.RoleId == leaderRoleId) && (nieuweRol.Id != leaderRoleId) )
                {
                    //Cant change role, because there wont be any leaders left 
                    var alert = "You can't change the role of this user, because their won't be any leaders left.";
                }

                //Eventuele veranderingen synchroniseren met het betreffende useraccount
                gebruiker.Name = gebruikersDetail.Gebruikers.Name;
                gebruiker.UserName = gebruikersDetail.Gebruikers.UserName;

                //Get new role                
                IdentityUserRole<string> newRole = new IdentityUserRole<string> { UserId = gebruiker.Id, RoleId = nieuweRol.Id };
                //Delete old record
                _context.UserRoles.Remove(oldRol);
                //Add new record
                _context.UserRoles.Add(newRole);
                //Update userrecord
                _context.Users.Update(gebruiker);
                //Save all changes to DB Table
                _context.SaveChanges();
            }
            //Get username which is changed
            var changedUserName = gebruikersDetail.Gebruikers.Name;

            //Return to the corrected user account with correct parameter
            return RedirectToAction("ShowUser", "Role", new { userName = changedUserName });
        }

        /// <summary>
        /// Check if desiredrole is current role
        /// </summary>
        /// <param name="gebruiker"></param>
        /// <returns></returns>
        public bool CheckRole(ApplicationUser gebruiker)
        {
            //init
            var check = false;

            //check desiredrole vs current role
            if (GetRole(gebruiker).Name == gebruiker.DesiredRol.ToString())
                check = true;

            //return check value
            return check;
        }

        /// <summary>
        /// Get correct Role for selected user
        /// </summary>
        /// <param name="gebruiker"></param>
        /// <returns></returns>
        public IdentityRole GetRole(ApplicationUser gebruiker)
        {
            //Get RoleId and RoleName
            var gebruikersRolId = _context.UserRoles.Where(rle => rle.UserId == gebruiker.Id).FirstOrDefault();
            var gebruikersRol = _context.Roles.Where(rl => rl.Id == gebruikersRolId.RoleId).FirstOrDefault();

            //Return Role
            return gebruikersRol;
        }
    }


}




