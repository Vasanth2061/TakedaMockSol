using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakedaMockModels
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; }


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

        public List<string> Hobbies { get; set; }

        [Required]

        public List<String> Tegnologies { get; set; }


    }
}
