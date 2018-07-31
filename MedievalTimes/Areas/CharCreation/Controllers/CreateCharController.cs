using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedievalTimes.Areas.CharCreation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedievalTimes.Areas.CharCreation.Controllers
{
    public class CreateCharController : Controller
    {
        public IActionResult StartCreation()
        {
            CharacterVM characterVM = new CharacterVM();

            return View("~/Areas/CharCreation/Views/CreateChar/StartCreation.cshtml",characterVM);
        }

        public IActionResult SubmitChar(CharacterVM characterVM)
        {
            

            return View();
        }
    }
}