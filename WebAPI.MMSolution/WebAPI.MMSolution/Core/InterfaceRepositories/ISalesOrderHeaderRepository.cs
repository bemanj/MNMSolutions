using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.MMSolution.Core.Domain;

namespace WebAPI.MMSolution.Core.InterfaceRepositories
{
   public interface ISalesOrderHeaderRepository : IRepository<SalesOrderHeaders>
    {
        void Insert(SalesOrderHeaders d);
        void Delete(int SalesOrderHeaderID);
        void Update(SalesOrderHeaders d);
        IList<SalesOrderHeaders> GetBSalesOrderHeaderID(int SalesOrderID);
    }
}
