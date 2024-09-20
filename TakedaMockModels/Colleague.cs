using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakedaMockModels
{
    public class Colleague
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; } 

        public string ImageURL { get; set; }

        public Boolean IsTeamMemeber {  get; set; }

        [Required]
        public int MemberId { get; set; }
        [ForeignKey(nameof(MemberId))]
        public Member Member { get; set; }
    }
}
