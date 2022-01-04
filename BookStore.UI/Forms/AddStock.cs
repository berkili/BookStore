using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.Business.Functions;
using BookStore.Entity.Concrete;
using BookStore.UI.UserControls;

namespace BookStore.UI.Forms
{
    public partial class AddStock : Form
    {
        #region Instantiates

        StockManager stockManager = new();
        BookManager bookManager = new();

        #endregion

        #region Properties

        public UCStock uC { get; set; }

        #endregion

        #region Constructors

        public AddStock()
        {
            InitializeComponent();
            var bookList = bookManager.GetBooksList();
            cmbISBN.DataSource = bookList.Select(x => x.ISBN).ToList();
        }
        public AddStock(UCStock uCStock) : this()
        {
            uC = uCStock;
        }

        #endregion

        #region Methods

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Stock stock = new();

            stock.ISBNId = Convert.ToInt64(cmbISBN.Text);
            stock.CreateTime = DateTime.UtcNow;
            stock.AmountOfStock = Convert.ToInt32(txtAmount.Text);

            var item = stockManager.AddStock(stock);

            if (item == true)
            {
                uC.dgvStock.Rows.Clear();
                uC.GetStocksTable();
                MessageBox.Show("Task successfully completed.");
            }
            else
            {
                MessageBox.Show("Failed to delete data. Please try again...");
            }
        }

        #endregion
    }
}
