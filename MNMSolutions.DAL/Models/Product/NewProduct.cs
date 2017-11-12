using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNMSolutions.DAL.Models.Product
{
    public class NewProduct
    {
        public short CategoryId { get; set; }
        public string ProductTitle { get; set; }
        public short ReorderLevel { get; set; }
    }
}
