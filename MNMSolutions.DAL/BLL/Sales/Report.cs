using System.Linq;
using MNMSolutions.DAL.DB.Dev;
using System.Collections.Generic;

namespace MNMSolutions.DAL.BLL.Sales
{
    public class SalesReport
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        public IEnumerable<vsp_SOH_NotSettled_DueDate_Result> ReturnNotSettledSalesOrders()
        {
            var list = _db.vsp_SOH_NotSettled_DueDate();

            return list;
        }

        public IEnumerable<vsp_SOH_Settled_DueDate_Result> ReturnSettledSalesOrders()
        {
            var list = _db.vsp_SOH_Settled_DueDate();

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
