using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Triton_Express.Models
{
    public class Waybill : BaseModel
    {
        [Display(Name = "Total Weight")]
        public int TotalWeight { get; set; }

        [Display(Name = "Total Number of Parcels")]
        public int TotalNumberofParcels { get; set; }

        [Display(Name = "Vehicle")]
        public int? VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }

        [Display(Name = "Branch")]
        public int? BranchId { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }

    }
}
