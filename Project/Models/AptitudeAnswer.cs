//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AptitudeAnswer
    {
        public int AnsSheetId { get; set; }
        public Nullable<int> CandidateId { get; set; }
        public Nullable<int> QueID { get; set; }
        public string UserResponse { get; set; }
        public Nullable<int> Score { get; set; }
        public Nullable<int> Duration { get; set; }
    
        public virtual Candidate Candidate { get; set; }
        public virtual AptitudeQuestion AptitudeQuestion { get; set; }
    }
}
