using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Entity.Concrete;

namespace BookStore.Business.Abstract
{
    public interface ISaleService
    {
        bool AddSales(List<Sales> sales);
        Sales GetSalesId(int salesId);
        List<Sales> GetSalesList();
    }
}
