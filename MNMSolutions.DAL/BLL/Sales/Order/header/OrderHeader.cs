using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MNMSolutions.DAL.Models.Sales.Order;
using MNMSolutions.DAL.DB.Dev;

namespace MNMSolutions.DAL.BLL.Sales.Order.header
{
    public class OrderHeader
    {
        private readonly MNMSolutionsDevDBEntities _db = new MNMSolutionsDevDBEntities();

        public  void UpdateTotalDue(int id, SalesOrderHeader _soHeader)
        {
            var result = _db.SalesOrderHeaders.SingleOrDefault(d => d.SalesOrderID == id);
            if (result != null)
            {
                result.TotalDue = _soHeader.TotalDue;
                _db.SaveChanges();
            }

        }
    }
}
