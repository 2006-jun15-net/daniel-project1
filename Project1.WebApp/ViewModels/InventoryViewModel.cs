using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebApp.ViewModels
{
    public class InventoryViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Location ID")]
        public int LocationId { get; set; }

        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        [Display(Name = "Amount")]
        public int Amount { get; set; }


    }
}
