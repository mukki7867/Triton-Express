using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Triton_Express.Models
{
    public class Parcel : BaseModel
    {

        [Display(Name = "Parcel Type")]
        public int ParcelTypeId { get; set; }

        [ForeignKey("ParcelTypeId")]
        public ParcelType ParcelType { get; set; }

        [Display(Name = "Parcel Weight")]
        public int ParcelWeight { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Dimensions in cm")]
        public int DimensionsInCm { get; set; }

        [Display(Name = "Waybill Number")]
        public int WaybillNumber { get; set; }

        [Display(Name = "Waybill Id")]
        public int? WaybillId { get; set; }

        [ForeignKey("WaybillId")]
        public Waybill Waybill { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        [Display(Name = "Branch")]
        public int? BranchId { get; set; }

        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }

    }
}
