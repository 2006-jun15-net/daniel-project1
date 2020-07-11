using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebApp.ViewModels
{
    public class ProductViewModel
    {
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}
