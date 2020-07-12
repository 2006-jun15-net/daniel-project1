using SolrNet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebApp.ViewModels
{
    public class OrderHistoryViewModel
    {
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        [Display(Name = "Location ID")]
        public int LocationId { get; set; }

        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }

        [Display(Name = "Date MM-dd-yyyy ")]
        public string Date { get; set; }


        [Display(Name = "Time HH:mm")]
        public string Time { get; set; }

        public IEnumerable<OrdersViewModel> Orders { get; set; }
    }
}
