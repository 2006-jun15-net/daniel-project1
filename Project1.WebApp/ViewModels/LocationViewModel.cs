using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebApp.ViewModels
{
    public class LocationViewModel
    {
        [Display(Name = "Location ID")]
        public int LocationID { get; set; }


        [Display(Name = "Location Name")]
        public string Name { get; set; }

        [Display(Name = "How to get from here to There")]
        public string Address { get; set; }
    }
}
