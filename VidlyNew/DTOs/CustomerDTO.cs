using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyNew.Models;

namespace VidlyNew.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        //[Min18YearsIfAMemeber]
        public DateTime? BirthDate { get; set; }

        public int MembershipTypeId { get; set; }

        public MembershipTypeDTO MembershipType { get; set; }
    }
}