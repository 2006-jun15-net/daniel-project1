using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebApp.ViewModels
{
    public class LocationViewModel
    {
        [Display(Name = "Location Name")]
        public string Name { get; set; }

        public string Adress { get; set; }
    }
}
