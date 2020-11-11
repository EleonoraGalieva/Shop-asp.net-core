using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryShop.Models
{
    public class Order
    {
        [BindingBehavior(BindingBehavior.Never)]
        public int OrderId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        [Required(ErrorMessage = "Please, make sure to enter your first name.")]
        [Display(Name = "First name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please, make sure to enter your last name.")]
        [Display(Name = "Last name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please, make sure to enter your country.")]
        [Display(Name = "Country")]
        [StringLength(20)]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please, make sure to enter your city.")]
        [Display(Name = "City")]
        [StringLength(20)]
        public string City { get; set; }
        [Required(ErrorMessage = "Please, make sure to enter your zipcode.")]
        [Display(Name = "Zipcode")]
        [StringLength(10)]
        public string Zipcode { get; set; }
        [Required(ErrorMessage = "Please, make sure to enter your phone number.")]
        [Display(Name = "Phone number")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please, make sure to enter your email.")]
        [Display(Name = "Email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Total")]
        [BindingBehavior(BindingBehavior.Never)]
        public decimal OrderTotal { get; set; }
        [BindingBehavior(BindingBehavior.Never)]
        public DateTime OrderPlaced { get; set; }
    }
}
