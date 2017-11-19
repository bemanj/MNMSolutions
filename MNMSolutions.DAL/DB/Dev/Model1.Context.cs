﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MNMSolutionsDevDBEntities : DbContext
    {
        public MNMSolutionsDevDBEntities()
            : base("name=MNMSolutionsDevDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Billing> Billings { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<CategoryOne> CategoryOnes { get; set; }
        public virtual DbSet<CustomerList> CustomerLists { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<InventoryLocation> InventoryLocations { get; set; }
        public virtual DbSet<InventoryStock> InventoryStocks { get; set; }
        public virtual DbSet<ProductOne> ProductOnes { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual DbSet<SalesOrderHeader> SalesOrderHeaders { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<StockOne> StockOnes { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Term> Terms { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }
        public virtual DbSet<inventory_view> inventory_view { get; set; }
        public virtual DbSet<View_Category> View_Category { get; set; }
        public virtual DbSet<View_Inventory> View_Inventory { get; set; }
        public virtual DbSet<View_Product> View_Product { get; set; }
        public virtual DbSet<View_SalesOrderDetails> View_SalesOrderDetails { get; set; }
        public virtual DbSet<View_SalesOrderHeaders> View_SalesOrderHeaders { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int usp_OrderDetail_Delete(Nullable<int> orderID, Nullable<int> productID)
        {
            var orderIDParameter = orderID.HasValue ?
                new ObjectParameter("OrderID", orderID) :
                new ObjectParameter("OrderID", typeof(int));
    
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_OrderDetail_Delete", orderIDParameter, productIDParameter);
        }
    
        public virtual int usp_OrderDetail_GetOrderDetail(Nullable<int> orderID, Nullable<int> productID)
        {
            var orderIDParameter = orderID.HasValue ?
                new ObjectParameter("OrderID", orderID) :
                new ObjectParameter("OrderID", typeof(int));
    
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_OrderDetail_GetOrderDetail", orderIDParameter, productIDParameter);
        }
    
        public virtual int usp_OrderDetail_Insert(Nullable<int> orderID, Nullable<int> productID, Nullable<decimal> unitPrice, Nullable<short> quantity, Nullable<float> discount, Nullable<decimal> totalAmount)
        {
            var orderIDParameter = orderID.HasValue ?
                new ObjectParameter("OrderID", orderID) :
                new ObjectParameter("OrderID", typeof(int));
    
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(int));
    
            var unitPriceParameter = unitPrice.HasValue ?
                new ObjectParameter("UnitPrice", unitPrice) :
                new ObjectParameter("UnitPrice", typeof(decimal));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("Quantity", quantity) :
                new ObjectParameter("Quantity", typeof(short));
    
            var discountParameter = discount.HasValue ?
                new ObjectParameter("Discount", discount) :
                new ObjectParameter("Discount", typeof(float));
    
            var totalAmountParameter = totalAmount.HasValue ?
                new ObjectParameter("TotalAmount", totalAmount) :
                new ObjectParameter("TotalAmount", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_OrderDetail_Insert", orderIDParameter, productIDParameter, unitPriceParameter, quantityParameter, discountParameter, totalAmountParameter);
        }
    
        public virtual int usp_OrderDetail_Update(Nullable<int> orderID, Nullable<int> productID, Nullable<decimal> unitPrice, Nullable<short> quantity, Nullable<float> discount, Nullable<decimal> totalAmount)
        {
            var orderIDParameter = orderID.HasValue ?
                new ObjectParameter("OrderID", orderID) :
                new ObjectParameter("OrderID", typeof(int));
    
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(int));
    
            var unitPriceParameter = unitPrice.HasValue ?
                new ObjectParameter("UnitPrice", unitPrice) :
                new ObjectParameter("UnitPrice", typeof(decimal));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("Quantity", quantity) :
                new ObjectParameter("Quantity", typeof(short));
    
            var discountParameter = discount.HasValue ?
                new ObjectParameter("Discount", discount) :
                new ObjectParameter("Discount", typeof(float));
    
            var totalAmountParameter = totalAmount.HasValue ?
                new ObjectParameter("TotalAmount", totalAmount) :
                new ObjectParameter("TotalAmount", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_OrderDetail_Update", orderIDParameter, productIDParameter, unitPriceParameter, quantityParameter, discountParameter, totalAmountParameter);
        }
    
        public virtual int usp_SOD_Delete(Nullable<int> salesDetailsID)
        {
            var salesDetailsIDParameter = salesDetailsID.HasValue ?
                new ObjectParameter("SalesDetailsID", salesDetailsID) :
                new ObjectParameter("SalesDetailsID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_SOD_Delete", salesDetailsIDParameter);
        }
    
        public virtual ObjectResult<usp_SOD_GetBySID_Result> usp_SOD_GetBySID(Nullable<int> salesDetailsID)
        {
            var salesDetailsIDParameter = salesDetailsID.HasValue ?
                new ObjectParameter("SalesDetailsID", salesDetailsID) :
                new ObjectParameter("SalesDetailsID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_SOD_GetBySID_Result>("usp_SOD_GetBySID", salesDetailsIDParameter);
        }
    
        public virtual int usp_SOD_Insert(Nullable<int> salesOrderID, Nullable<int> stockID, Nullable<int> productID, Nullable<decimal> unitPrice, string article, string uOM, Nullable<short> quantity, Nullable<float> discount, Nullable<decimal> totalAmount)
        {
            var salesOrderIDParameter = salesOrderID.HasValue ?
                new ObjectParameter("SalesOrderID", salesOrderID) :
                new ObjectParameter("SalesOrderID", typeof(int));
    
            var stockIDParameter = stockID.HasValue ?
                new ObjectParameter("StockID", stockID) :
                new ObjectParameter("StockID", typeof(int));
    
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(int));
    
            var unitPriceParameter = unitPrice.HasValue ?
                new ObjectParameter("UnitPrice", unitPrice) :
                new ObjectParameter("UnitPrice", typeof(decimal));
    
            var articleParameter = article != null ?
                new ObjectParameter("Article", article) :
                new ObjectParameter("Article", typeof(string));
    
            var uOMParameter = uOM != null ?
                new ObjectParameter("UOM", uOM) :
                new ObjectParameter("UOM", typeof(string));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("Quantity", quantity) :
                new ObjectParameter("Quantity", typeof(short));
    
            var discountParameter = discount.HasValue ?
                new ObjectParameter("Discount", discount) :
                new ObjectParameter("Discount", typeof(float));
    
            var totalAmountParameter = totalAmount.HasValue ?
                new ObjectParameter("TotalAmount", totalAmount) :
                new ObjectParameter("TotalAmount", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_SOD_Insert", salesOrderIDParameter, stockIDParameter, productIDParameter, unitPriceParameter, articleParameter, uOMParameter, quantityParameter, discountParameter, totalAmountParameter);
        }
    
        public virtual int usp_SOD_Update(Nullable<int> salesDetailsID, Nullable<float> discount, Nullable<decimal> totalAmount)
        {
            var salesDetailsIDParameter = salesDetailsID.HasValue ?
                new ObjectParameter("SalesDetailsID", salesDetailsID) :
                new ObjectParameter("SalesDetailsID", typeof(int));
    
            var discountParameter = discount.HasValue ?
                new ObjectParameter("Discount", discount) :
                new ObjectParameter("Discount", typeof(float));
    
            var totalAmountParameter = totalAmount.HasValue ?
                new ObjectParameter("TotalAmount", totalAmount) :
                new ObjectParameter("TotalAmount", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_SOD_Update", salesDetailsIDParameter, discountParameter, totalAmountParameter);
        }
    
        public virtual int usp_SOH_Delete(Nullable<int> salesOrderID)
        {
            var salesOrderIDParameter = salesOrderID.HasValue ?
                new ObjectParameter("SalesOrderID", salesOrderID) :
                new ObjectParameter("SalesOrderID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_SOH_Delete", salesOrderIDParameter);
        }
    
        public virtual ObjectResult<usp_SOH_GetBySID_Result> usp_SOH_GetBySID(Nullable<int> salesOrderID)
        {
            var salesOrderIDParameter = salesOrderID.HasValue ?
                new ObjectParameter("SalesOrderID", salesOrderID) :
                new ObjectParameter("SalesOrderID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_SOH_GetBySID_Result>("usp_SOH_GetBySID", salesOrderIDParameter);
        }
    
        public virtual int usp_SOH_Update(Nullable<int> salesOrderID, Nullable<int> customer, string onlineOrderFlag, Nullable<decimal> subTotal, Nullable<decimal> taxAmt, Nullable<decimal> freight, string comment, Nullable<bool> fulfilled)
        {
            var salesOrderIDParameter = salesOrderID.HasValue ?
                new ObjectParameter("SalesOrderID", salesOrderID) :
                new ObjectParameter("SalesOrderID", typeof(int));
    
            var customerParameter = customer.HasValue ?
                new ObjectParameter("Customer", customer) :
                new ObjectParameter("Customer", typeof(int));
    
            var onlineOrderFlagParameter = onlineOrderFlag != null ?
                new ObjectParameter("OnlineOrderFlag", onlineOrderFlag) :
                new ObjectParameter("OnlineOrderFlag", typeof(string));
    
            var subTotalParameter = subTotal.HasValue ?
                new ObjectParameter("SubTotal", subTotal) :
                new ObjectParameter("SubTotal", typeof(decimal));
    
            var taxAmtParameter = taxAmt.HasValue ?
                new ObjectParameter("TaxAmt", taxAmt) :
                new ObjectParameter("TaxAmt", typeof(decimal));
    
            var freightParameter = freight.HasValue ?
                new ObjectParameter("Freight", freight) :
                new ObjectParameter("Freight", typeof(decimal));
    
            var commentParameter = comment != null ?
                new ObjectParameter("Comment", comment) :
                new ObjectParameter("Comment", typeof(string));
    
            var fulfilledParameter = fulfilled.HasValue ?
                new ObjectParameter("Fulfilled", fulfilled) :
                new ObjectParameter("Fulfilled", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_SOH_Update", salesOrderIDParameter, customerParameter, onlineOrderFlagParameter, subTotalParameter, taxAmtParameter, freightParameter, commentParameter, fulfilledParameter);
        }
    
        public virtual int vsp_Customer_Create(string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax, Nullable<int> terms)
        {
            var companyNameParameter = companyName != null ?
                new ObjectParameter("CompanyName", companyName) :
                new ObjectParameter("CompanyName", typeof(string));
    
            var contactNameParameter = contactName != null ?
                new ObjectParameter("ContactName", contactName) :
                new ObjectParameter("ContactName", typeof(string));
    
            var contactTitleParameter = contactTitle != null ?
                new ObjectParameter("ContactTitle", contactTitle) :
                new ObjectParameter("ContactTitle", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var regionParameter = region != null ?
                new ObjectParameter("Region", region) :
                new ObjectParameter("Region", typeof(string));
    
            var postalCodeParameter = postalCode != null ?
                new ObjectParameter("PostalCode", postalCode) :
                new ObjectParameter("PostalCode", typeof(string));
    
            var countryParameter = country != null ?
                new ObjectParameter("Country", country) :
                new ObjectParameter("Country", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var faxParameter = fax != null ?
                new ObjectParameter("Fax", fax) :
                new ObjectParameter("Fax", typeof(string));
    
            var termsParameter = terms.HasValue ?
                new ObjectParameter("Terms", terms) :
                new ObjectParameter("Terms", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("vsp_Customer_Create", companyNameParameter, contactNameParameter, contactTitleParameter, addressParameter, cityParameter, regionParameter, postalCodeParameter, countryParameter, phoneParameter, faxParameter, termsParameter);
        }
    
        public virtual int vsp_Customer_UpdateById(string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax, Nullable<int> terms, Nullable<int> iD)
        {
            var companyNameParameter = companyName != null ?
                new ObjectParameter("CompanyName", companyName) :
                new ObjectParameter("CompanyName", typeof(string));
    
            var contactNameParameter = contactName != null ?
                new ObjectParameter("ContactName", contactName) :
                new ObjectParameter("ContactName", typeof(string));
    
            var contactTitleParameter = contactTitle != null ?
                new ObjectParameter("ContactTitle", contactTitle) :
                new ObjectParameter("ContactTitle", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            var regionParameter = region != null ?
                new ObjectParameter("Region", region) :
                new ObjectParameter("Region", typeof(string));
    
            var postalCodeParameter = postalCode != null ?
                new ObjectParameter("PostalCode", postalCode) :
                new ObjectParameter("PostalCode", typeof(string));
    
            var countryParameter = country != null ?
                new ObjectParameter("Country", country) :
                new ObjectParameter("Country", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(string));
    
            var faxParameter = fax != null ?
                new ObjectParameter("Fax", fax) :
                new ObjectParameter("Fax", typeof(string));
    
            var termsParameter = terms.HasValue ?
                new ObjectParameter("Terms", terms) :
                new ObjectParameter("Terms", typeof(int));
    
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("vsp_Customer_UpdateById", companyNameParameter, contactNameParameter, contactTitleParameter, addressParameter, cityParameter, regionParameter, postalCodeParameter, countryParameter, phoneParameter, faxParameter, termsParameter, iDParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> vsp_order_ReturnTotalAmountByDateSelected(Nullable<int> soID, string dateRange)
        {
            var soIDParameter = soID.HasValue ?
                new ObjectParameter("soID", soID) :
                new ObjectParameter("soID", typeof(int));
    
            var dateRangeParameter = dateRange != null ?
                new ObjectParameter("dateRange", dateRange) :
                new ObjectParameter("dateRange", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("vsp_order_ReturnTotalAmountByDateSelected", soIDParameter, dateRangeParameter);
        }
    
        public virtual ObjectResult<vsp_orderdetail_ViewBySalesOrderId_Result> vsp_orderdetail_ViewBySalesOrderId(Nullable<int> salesOrderID)
        {
            var salesOrderIDParameter = salesOrderID.HasValue ?
                new ObjectParameter("salesOrderID", salesOrderID) :
                new ObjectParameter("salesOrderID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<vsp_orderdetail_ViewBySalesOrderId_Result>("vsp_orderdetail_ViewBySalesOrderId", salesOrderIDParameter);
        }
    
        public virtual ObjectResult<vsp_orderHeader_UpdateSubTotal_ViewBySOId_Result> vsp_orderHeader_UpdateSubTotal_ViewBySOId(Nullable<int> soID)
        {
            var soIDParameter = soID.HasValue ?
                new ObjectParameter("soID", soID) :
                new ObjectParameter("soID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<vsp_orderHeader_UpdateSubTotal_ViewBySOId_Result>("vsp_orderHeader_UpdateSubTotal_ViewBySOId", soIDParameter);
        }
    
        public virtual ObjectResult<vsp_Product_CreateThenReturn_Result> vsp_Product_CreateThenReturn(Nullable<short> categoryID, string productTitle, Nullable<short> reorderLevel)
        {
            var categoryIDParameter = categoryID.HasValue ?
                new ObjectParameter("CategoryID", categoryID) :
                new ObjectParameter("CategoryID", typeof(short));
    
            var productTitleParameter = productTitle != null ?
                new ObjectParameter("ProductTitle", productTitle) :
                new ObjectParameter("ProductTitle", typeof(string));
    
            var reorderLevelParameter = reorderLevel.HasValue ?
                new ObjectParameter("ReorderLevel", reorderLevel) :
                new ObjectParameter("ReorderLevel", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<vsp_Product_CreateThenReturn_Result>("vsp_Product_CreateThenReturn", categoryIDParameter, productTitleParameter, reorderLevelParameter);
        }
    
        public virtual int vsp_Product_UpdateById(Nullable<int> categoryId, string producttitle, Nullable<int> reoderlevel, Nullable<bool> discontinued, Nullable<int> productid)
        {
            var categoryIdParameter = categoryId.HasValue ?
                new ObjectParameter("categoryId", categoryId) :
                new ObjectParameter("categoryId", typeof(int));
    
            var producttitleParameter = producttitle != null ?
                new ObjectParameter("producttitle", producttitle) :
                new ObjectParameter("producttitle", typeof(string));
    
            var reoderlevelParameter = reoderlevel.HasValue ?
                new ObjectParameter("reoderlevel", reoderlevel) :
                new ObjectParameter("reoderlevel", typeof(int));
    
            var discontinuedParameter = discontinued.HasValue ?
                new ObjectParameter("discontinued", discontinued) :
                new ObjectParameter("discontinued", typeof(bool));
    
            var productidParameter = productid.HasValue ?
                new ObjectParameter("productid", productid) :
                new ObjectParameter("productid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("vsp_Product_UpdateById", categoryIdParameter, producttitleParameter, reoderlevelParameter, discontinuedParameter, productidParameter);
        }
    
        public virtual ObjectResult<vsp_Product_ViewByProductId_Result> vsp_Product_ViewByProductId(Nullable<int> paramId)
        {
            var paramIdParameter = paramId.HasValue ?
                new ObjectParameter("paramId", paramId) :
                new ObjectParameter("paramId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<vsp_Product_ViewByProductId_Result>("vsp_Product_ViewByProductId", paramIdParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> vsp_Sales_TotalDueForToday()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("vsp_Sales_TotalDueForToday");
        }
    
        public virtual ObjectResult<Nullable<int>> vsp_SOH_InsertThenReturnNewSO(Nullable<decimal> subTotal, Nullable<decimal> taxAmt, Nullable<decimal> freight)
        {
            var subTotalParameter = subTotal.HasValue ?
                new ObjectParameter("SubTotal", subTotal) :
                new ObjectParameter("SubTotal", typeof(decimal));
    
            var taxAmtParameter = taxAmt.HasValue ?
                new ObjectParameter("TaxAmt", taxAmt) :
                new ObjectParameter("TaxAmt", typeof(decimal));
    
            var freightParameter = freight.HasValue ?
                new ObjectParameter("Freight", freight) :
                new ObjectParameter("Freight", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("vsp_SOH_InsertThenReturnNewSO", subTotalParameter, taxAmtParameter, freightParameter);
        }
    }
}
