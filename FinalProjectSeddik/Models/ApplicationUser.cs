using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectSeddik.Models
{
    public class ApplicationUser : IdentityUser
    {

        public bool IsProjSent { get; set; }
        public bool IsRegSent { get; set; }
        public byte[] ProfilePic { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        public string Specialization { get; set; }
        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        [Phone]
        public string mobileNumber { get; set; }
        [Required]
        [MaxLength(14)]
        [MinLength(14)]
        [Phone]
        public string NationalID { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string Workplace { get; set; }
        [Required]
        public string Qualification { get; set; }
        public string Role { get; set; }
    }
}
