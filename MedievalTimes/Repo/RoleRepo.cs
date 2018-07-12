using MedievalTimes.Areas.Identity.Data;
using MedievalTimes.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalTimes.Repo
{
    public class RoleRepo
    {
        //****************************************************************** Injections
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public RoleRepo(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
        {
            _context = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //****************************************************************** Methods

        /// <summary>
        /// Create userroles in ID UI
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        public async Task AddRole(string Role)
        {
            if (!await _roleManager.RoleExistsAsync(Role))
                await _roleManager.CreateAsync(new IdentityRole(Role));
        }

        /// <summary>
        /// Give user a userrole (ID UI)
        /// </summary>
        /// <param name="Role"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task DistributeRole(ApplicationUser user, string Role)
        {
            await _userManager.AddToRoleAsync(user, Role);
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
