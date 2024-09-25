using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace TakedaMockModels
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public String DateOfBirth { get; set; }


        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }

        [Required]
        public string PinCode { get; set; }

        [MaxLength(300)]
        public string BackGround { get; set; }

        public string UnivEducation { get; set; }
        
    }
}
