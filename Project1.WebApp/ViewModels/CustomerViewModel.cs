using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.WebApp.ViewModels
{
    public class CustomerViewModel
    {
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Customer First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Customer Last Name")]
        public string LastName { get; set; }

        public IEnumerable<OrderHistoryViewModel> OrderHistoryViewModels { get; set; }

    }
}
