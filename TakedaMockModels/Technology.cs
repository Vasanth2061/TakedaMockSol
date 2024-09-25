using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakedaMockModels
{
    public class Technology
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1,5)]
        public int Proficiency { get; set; }
    }
}
