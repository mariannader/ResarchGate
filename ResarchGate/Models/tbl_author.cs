//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ResarchGate.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_author
    {
        public int a_id { get; set; }
        public string a_name { get; set; }
        public Nullable<int> a_fk_paper { get; set; }
        public Nullable<int> a_fk_user { get; set; }
    
        public virtual tbl_paper tbl_paper { get; set; }
        public virtual tbl_user tbl_user { get; set; }
    }
}
