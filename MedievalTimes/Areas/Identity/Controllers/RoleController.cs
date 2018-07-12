using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedievalTimes.Areas.Identity.Data;
using MedievalTimes.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MedievalTimes.Areas.Identity.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }

}
