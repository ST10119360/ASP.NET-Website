//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iwish.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rental
    {
        public int RentalNo { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public int RentalFee { get; set; }
        public string CarNo { get; set; }
        public string InspectNO { get; set; }
        public Nullable<int> DriverID { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Inspector Inspector { get; set; }
    }
}
