using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesSoftware.Models
{
    public class Software
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [Display(Name = "Publisher/Developer")]
        public string Publisher { get; set; }
        
        public string Vendor { get; set; }

        [Display(Name ="License Key")]
        public string LicenseKey { get; set; }

        [Display(Name = "PO #")]
        public string PONumber { get; set; }

        public string Location { get; set; }

        [Display(Name = "License Qty")]
        public int LicenseQuantity { get; set; }        

        [Display(Name = "Renewal Date")]
        [DataType(DataType.Date)]
        public DateTime RenewalDate { get; set; }

        [Display(Name = "Instructional Software")]
        public bool IsInstructional { get; set; }

        [Display(Name = "Faculty/Staff Software")]
        public bool IsFacStaff { get; set; }

        [Display(Name = "Archived")]
        public bool IsArchived { get; set; }
    }
}
