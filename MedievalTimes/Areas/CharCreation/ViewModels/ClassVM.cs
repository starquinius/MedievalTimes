using MedievalTimes.Areas.CharCreation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedievalTimes.Areas.CharCreation.ViewModels
{
    public class ClassVM
    {
        public Beroep Beroepen { get; set; }
        public int ChosenId { get; set; }
    }
}
