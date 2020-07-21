using System;
using System.ComponentModel.DataAnnotations;

namespace Synel.Web.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Payroll number")]
        public string PayrollNo { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile phone")]
        public string MobilePhone { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string AddressLine1 { get; set; }

        [Required]
        [Display(Name = "Address 2")]
        public string AddressLine2 { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Postal code")]
        public string AddressPostalCode { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
    }
}