//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SignUpLogin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class candidate
    {
        public int ID { get; set; }
        public string location { get; set; }
        public Nullable<int> MobileNo { get; set; }
    
        public virtual Usr Usr { get; set; }
    }
}
