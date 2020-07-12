using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebApp.ViewModels
{
    public class OrdersViewModel
    {
        [Display(Name = "Order ID")]
        public int OrderID { get; set; }

        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Amount")]
        public int Amount { get; set; }

    }
}
