//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MNMSolutions.DAL.DB.Dev
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductOne
    {
        public int ProductId { get; set; }
        public int CategoryID { get; set; }
        public string ProductTitle { get; set; }
        public Nullable<short> UnitsInStock { get; set; }
        public Nullable<short> UnitsOnOrder { get; set; }
        public Nullable<short> ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public Nullable<bool> isTaxFree { get; set; }
    
        public virtual CategoryOne CategoryOne { get; set; }
    }
}
