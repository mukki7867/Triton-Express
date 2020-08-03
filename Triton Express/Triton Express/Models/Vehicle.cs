using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Triton_Express.Models
{
    public class Vehicle : BaseModel
    {
        [Display(Name = "Registration Number")]
        public string RegistrationNo { get; set; }

        [Display(Name = "Colour")]
        public string Colour { get; set; }

        [Display(Name = "Brand")]
        public string Brand { get; set; }
 
        [Display(Name = "Branch")]
        public int? BranchId { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }

    }
}
