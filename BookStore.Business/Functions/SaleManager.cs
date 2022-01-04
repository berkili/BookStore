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
    public class SaleManager : ISaleService
    {
        public List<Sales> salesList = new();
        public bool AddSales(List<Sales> sales)
        {
            bool status = false;
            sales.ForEach(x => {
                var book = BookFileManager.GetBookId(x.ISBNId);

                int salesId = GetSalesList().Select(x => x.Id).LastOrDefault();
                x.Id = salesId == null ? 0 : salesId + 1;

                if (book.TotalStock < x.Pieces)
                {
                    status = false;
                }
                else
                {
                    book.TotalStock -= x.Pieces;
                    BookFileManager.UpdateBook(book);
                    status = SalesFileManager.SaveSales(x);
                }
            });
            return status;            
        }

        public Sales GetSalesId(int salesId)
        {
            return SalesFileManager.GetSalesId(salesId);
        }

        public List<Sales> GetSalesList()
        {
            return salesList = SalesFileManager.GetSales();
        }
    }
}
