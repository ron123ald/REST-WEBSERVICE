//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatManagerService.ChatEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}
