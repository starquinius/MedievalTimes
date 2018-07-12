using MedievalTimes.Areas.Identity.Data;
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

        }
    }
}
