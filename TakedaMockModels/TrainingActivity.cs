using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakedaMockModels
{
    public class TrainingActivity
    {
        public int Id { get; set; }

        [Required]

        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly EndDate { get; set; }
        [Required]
        public int MemberId { get; set; }
        [ForeignKey(nameof(MemberId))]
        public Member Member { get; set; }


    }
}
