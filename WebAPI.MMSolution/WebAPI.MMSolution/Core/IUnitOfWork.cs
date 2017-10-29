using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.MMSolution.Core.InterfaceRepositories;

namespace WebAPI.MMSolution.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderDetailRepository OrderDetails { get; set; }
        ISalesOrderDetailsRepository SalesOrderDetails { get; set; }
        ISalesOrderHeaderRepository SalesOrderHeader { get; set; }
    }
}
