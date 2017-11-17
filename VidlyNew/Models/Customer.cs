using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Web;

namespace VidlyNew.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMemeber]
        public DateTime? BirthDate { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }

    }
}