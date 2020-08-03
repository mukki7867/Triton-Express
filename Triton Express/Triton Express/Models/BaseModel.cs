using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Web;
using Newtonsoft.Json;

namespace Triton_Express.Models
{
    public class BaseModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Is Locked")]
        public bool? IsLocked { get; set; }

        public int? CreatedBySystemUserId { get; set; }
        [ForeignKey("CreatedBySystemUserId")]
        [Display(Name = "Created By")]
         public DateTime? CreatedDateTime { get; set; }

        public int? ModifiedBySystemUserId { get; set; }
        [ForeignKey("ModifiedBySystemUserId")]
        [Display(Name = "Modified By")]
 

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ModifiedDateTime { get; set; }

         [NotMapped]
        public string Data { get; set; }

         [NotMapped]
        public List<string> DataList { get; set; }

     }
}