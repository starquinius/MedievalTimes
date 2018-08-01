using MedievalTimes.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalTimes.Areas.CharCreation.ViewModels
{
    public class RaceVM
    {
        public Race Race { get; set; }
        public int ChosenId { get; set; }
    }
}
