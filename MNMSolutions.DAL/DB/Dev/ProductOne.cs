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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductOne()
        {
            this.StockOnes = new HashSet<StockOne>();
        }
    
        public int ProductId { get; set; }
        public int CategoryID { get; set; }
        public string ProductDescription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockOne> StockOnes { get; set; }
    }
}