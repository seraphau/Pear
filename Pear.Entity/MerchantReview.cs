//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pear.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class MerchantReview
    {
        public long ReviewId { get; set; }
        public int MerchantId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public System.DateTime CreatedDate { get; set; }
    
        public virtual Merchant Merchant { get; set; }
    }
}