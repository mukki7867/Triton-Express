using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Triton_Express.Models
{
    public class Customer : BaseModel
    {
        [Display( Name = "ID/ Passport No" )]
        [MaxLength(100)]
        public string IdentificationNumber { get; set; }

        [Display( Name = "Title" )]
        public int ? TitleTypeId { get; set; }
        [ForeignKey( "TitleTypeId" )]
        public TitleType TitleType { get; set; }

        [Display( Name = "First Name" )]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [MaxLength(25)]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display( Name = "Deceased" )]
        public bool ? IsDeceased { get; set; }

        [MaxLength(100)]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [MaxLength(100)]
        [Display(Name = "Work Phone")]
        public string WorkPhoneNumber { get; set; }

        [MaxLength(100)]
        [Display(Name = "Home Phone")]
        public string HomePhoneNumber { get; set; }

        [MaxLength(100)]
        [Display(Name = "Cell Phone")]
        public string CellPhoneNumber { get; set; }

        [MaxLength(25)]
        [Display(Name = "Unit No")]
        public string PhysicalAddress1 { get; set; }

        [MaxLength(100)]
        [Display(Name = "Block/ Complex Name")]
        public string PhysicalAddress2 { get; set; }

        [MaxLength(100)]
        [Display(Name = "Street No")]
        public string PhysicalAddress3 { get; set; }

        [MaxLength(100)]
        [Display(Name = "Street Name")]
        public string PhysicalAddress4 { get; set; }

        [MaxLength(100)]
        [Display(Name = "Suburb")]
        public string PhysicalAddress5 { get; set; }

        [Display(Name = "Postal Code")]
        public int PhysicalAddressCode { get; set; }

        [MaxLength(25)]
        [Display(Name = "Unit No")]
        public string PostalAddress1 { get; set; }

        [MaxLength(100)]
        [Display(Name = "Block/ Complex Name")]
        public string PostalAddress2 { get; set; }

        [MaxLength(100)]
        [Display(Name = "Street No")]
        public string PostalAddress3 { get; set; }

        [MaxLength(100)]
        [Display(Name = "Street Name/ Postal Box")]
        public string PostalAddress4 { get; set; }

        [MaxLength(100)]
        [Display(Name = "Suburb/ Postal Area")]
        public string PostalAddress5 { get; set; }

        [Display(Name = "Postal Code")]
        public int PostalAddressCode { get; set; }

        [Display( Name = "Status" )]
        public int StatusId { get; set; }
        [ForeignKey( "StatusId" )]
        public Status Status { get; set; }
        
    }
}