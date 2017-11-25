using System.Linq;
using MNMSolutions.DAL.DB.Dev;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;

namespace MNMSolutions.DAL.BLL.Sales
{
    public class SalesReport
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        // NotSettledSalesOrderController
        // GetNotSettledSalesOrder
        public IEnumerable<vsp_SOH_NotSettled_DueDate_Result> ReturnNotSettledSalesOrders()
        {
            var list = _db.vsp_SOH_NotSettled_DueDate();

            return list;
        }

        // SettledSalesOrderController
        // GetSettledSalesOrder
        public IEnumerable<vsp_SOH_Settled_DueDate_Result> ReturnSettledSalesOrders()
        {
            var list = _db.vsp_SOH_Settled_DueDate();

            return list;
        }

        public IEnumerable<vsp_SOH_NotSettled_DueToday_Result> ReturnNotSettledSalesOrdersDueToday()
        {
            var list = _db.vsp_SOH_NotSettled_DueToday();

            return list;
        }

        public IEnumerable<vsp_SOH_NotSettled_OverDue_Result> ReturnNotSettledSalesOrdersOverDue()
        {
            var list = _db.vsp_SOH_NotSettled_OverDue();

            return list;
        }

        public IEnumerable<vsp_SOH_NotSettled_IncomingDue_Result> ReturnNotSettledSalesOrdersIncomingDue()
        {
            var list = _db.vsp_SOH_NotSettled_IncomingDue();

            return list;
        }

        // list of fulfilled sales orders filter by date range
        public IEnumerable<vsp_order_Result_SalesOrderFulfilled_DateRange_Result> ReturnListFulfilledSalesOrdersDateRange(int id, string daterange)
        {
            var list = _db.vsp_order_Result_SalesOrderFulfilled_DateRange(id, daterange);

            return list;
        }

        // SUM of fullfilled sales orders filter by date range
        public ObjectResult<decimal?>  ReturnSumFulfilledSalesOrdersDateRange(int id, string daterange)
        {
            var list = _db.vsp_order_SUM_SalesOrderFulfilled_DateRange(id, daterange);

            return list;
        }

        //public  void UpdateTotalDue(int id, SalesOrderHeader _soHeader)
        //{
        //    var result = _db.SalesOrderHeaders.SingleOrDefault(d => d.SalesOrderID == id);
        //    if (result != null)
        //    {
        //        result.TotalDue = _soHeader.TotalDue;
        //        _db.SaveChanges();
        //    }

        //}

        //public void CompleteOrder(int id)
        //{
        //    var result = _db.SalesOrderHeaders.SingleOrDefault(d => d.SalesOrderID == id);
        //    if (result != null)
        //    {
        //        result.Fulfilled = true;
        //        _db.SaveChanges();
        //    }

        //}
    }
}
