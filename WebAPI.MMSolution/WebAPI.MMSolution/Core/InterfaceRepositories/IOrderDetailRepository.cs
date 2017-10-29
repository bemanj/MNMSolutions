using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.MMSolution.Core.Domain;

namespace WebAPI.MMSolution.Core.InterfaceRepositories
{
   public interface IOrderDetailRepository : IRepository<OrderDetails>
    {
        void Insert(OrderDetails d);
        void Delete(int OrderID,int ProductID);
        void Update(OrderDetails d);
        IList<OrderDetails> GetByOrderIDProductID(int OrderID, int ProductID);

    }
}
