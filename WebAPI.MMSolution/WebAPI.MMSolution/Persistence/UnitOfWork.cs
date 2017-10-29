using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.MMSolution.Core;
using WebAPI.MMSolution.Core.InterfaceRepositories;
using WebAPI.MMSolution.Models;
using WebAPI.MMSolution.Persistence.Reposistories;

namespace WebAPI.MMSolution.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MNMSolutionsDevDBEntities _context;

        public UnitOfWork(MNMSolutionsDevDBEntities context)
        {
            _context = context;
            OrderDetails = new OrderDetailRepository(_context);
            SalesOrderDetails = new SalesOrderDetailsRepository(_context);
            SalesOrderHeader = new SalesOrderHeaderRepository(_context);
        }
        public IOrderDetailRepository OrderDetails { get; set; }
        public ISalesOrderDetailsRepository SalesOrderDetails { get; set; }
        public ISalesOrderHeaderRepository SalesOrderHeader { get; set; }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}