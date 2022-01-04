using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.UI.Forms;
using BookStore.Entity.Concrete;
using BookStore.Business.Functions;

namespace BookStore.UI.UserControls
{
    public partial class UCStock : UserControl
    {
        #region Instantiates

        StockManager stockManager = new();
        BookManager bookManager = new();

        #endregion

        #region Constructor
        public UCStock()
        {
            InitializeComponent();
            GetStocksTable();
        }

        #endregion

        #region Methods

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            AddStock addStock = new(this);
            addStock.Show();
        }
        public void GetStocksTable()
        {

            List<Stock> stocks = stockManager.GetStocksList();
            List<Book> books = bookManager.GetBooksList();

            var result = (from t1 in stocks
                          join t2 in books
                          on t1.ISBNId equals t2.ISBN
                          select new {
                              colISBN = t2.Name,
                              colStock = t1.AmountOfStock,
                              colTime = t1.CreateTime
                          }).ToList();

            result.ForEach(x => {
                dgvStock.Rows.Add(x.colISBN, x.colStock, x.colTime);
            });
        }

        #endregion

    }
}
