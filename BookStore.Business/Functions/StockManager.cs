using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Business.Abstract;
using BookStore.Entity.Concrete;
using BookStore.DataAccess.Functions;

namespace BookStore.Business.Functions
{
    public class StockManager : IStockService
    {
        public List<Stock> stocks = new();
        public bool AddStock(Stock stock)
        {            

            var book = BookFileManager.GetBookId(stock.ISBNId);
            int stockId = GetStocksList().Select(x => x.Id).LastOrDefault();

            stock.Id = stockId == 0 ? 1 : stockId + 1;
            book.TotalStock += stock.AmountOfStock;
            BookFileManager.UpdateBook(book);
            var status = StockFileManager.SaveStocks(stock);
            return status;
        }

        public Stock GetStockId(int stockId)
        {
            return StockFileManager.GetStockId(stockId);
        }

        public List<Stock> GetStocksList()
        {
            return stocks = StockFileManager.GetStocks();
        }

        public void UpdateStock(Stock stockToUpdate)
        {
            StockFileManager.UpdateStock(stockToUpdate);
        }
    }
}
