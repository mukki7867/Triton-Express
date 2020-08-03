using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Triton_Express.Models
{
    public class Branch : BaseModel
    {
        [Display(Name = "Branch Name")]
        public string BranchName { get; set; }

        [Display(Name = "Physical Address")]
        public string BranchPhysicalAddress { get; set; }

        [Display(Name = "Branch City")]
        public string BranchCity { get; set; }

        [Display(Name = "Branch Code")]
        public string BranchCode { get; set; }
        [Display(Name = "Branch Country")]
        public string BranchCountry { get; set; }

        [Display(Name = "Branch Contact Number")]
        public string BranchContactNumber { get; set; }

        [Display(Name = "Branch Manager Email")]
        public string BranchManagerEmail { get; set; }

        [Display(Name = "Small Waybill Count")]
        public int SmallWaybillCount { get; set; }

        [Display(Name = "Medium Waybill Count")]
        public int MediumWaybillCount { get; set; }

        [Display(Name = "Large Waybill Count")]
        public int LargeWaybillCount { get; set; }


    }
}
