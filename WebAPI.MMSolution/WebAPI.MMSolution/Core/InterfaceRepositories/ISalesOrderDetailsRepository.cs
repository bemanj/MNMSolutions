using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.MMSolution.Core.Domain;

namespace WebAPI.MMSolution.Core.InterfaceRepositories
{
    public interface ISalesOrderDetailsRepository : IRepository<SalesOrderDetails>
    {
        void Insert(SalesOrderDetails d);
        void Delete(int SODetailsID);
        void Update(SalesOrderDetails d);
        IList<SalesOrderDetails> GetSalesOrderDetailByID(int SODetailsID);

    }
}
