//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LOGIN
    {
        public string C_Username { get; set; }
        public string C_Password { get; set; }
        public string C_Staff_id { get; set; }
        public int C_Role { get; set; }
    
        public virtual STAFF STAFF { get; set; }
    }
}
