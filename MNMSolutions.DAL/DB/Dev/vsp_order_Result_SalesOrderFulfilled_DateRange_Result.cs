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
    
    public partial class vsp_order_Result_SalesOrderFulfilled_DateRange_Result
    {
        public int SalesOrderID { get; set; }
        public Nullable<int> Customer { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public string OnlineOrderFlag { get; set; }
        public string SalesOrderNumber { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public string Comment { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> Fulfilled { get; set; }
        public decimal TotalDueAmt { get; set; }
        public decimal TaxableAmt { get; set; }
        public decimal TaxFreeAmt { get; set; }
        public bool ComputeTax { get; set; }
        public bool isSettled { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> EmployeeSales { get; set; }
        public Nullable<System.DateTime> SettledDate { get; set; }
    }
}
