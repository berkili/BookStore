using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Entity.Concrete;

namespace BookStore.Business.Abstract
{
    public interface IStockService
    {
        bool AddStock(Stock stock);

        void UpdateStock(Stock stockToUpdate);

        Stock GetStockId(int stockId);

        List<Stock> GetStocksList();
    }
}
