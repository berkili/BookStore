using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.Entity.Concrete;
using BookStore.Business.Functions;
using BookStore.UI.Forms;
using BookStore.UI.UserControls;

namespace BookStore.UI.Forms
{
    public partial class AddSales : Form
    {      

        bool control = false; 
        int amount = 0;

        #region Instantiates

        List<Sales> salesList = new();
        BookManager bookManager = new();
        UserManager userManager = new();
        SaleManager saleManager = new();
        UCSale uC = new();

        #endregion

        #region Constructors

        public AddSales()
        {
            InitializeComponent();
            var bookList = bookManager.GetBooksList();
            cmbISBN.DataSource = bookList.Select(x => x.ISBN).ToList();

            var userList = userManager.GetUsersList();
            cmbUser.DataSource = userList.Select(x => x.UserName).ToList();
        }
        public AddSales(UCSale uCSale) : this()
        {
            uC = uCSale;
        }

        #endregion

        #region Methods

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSell_Click(object sender, EventArgs e)
        {
            var item = saleManager.AddSales(salesList);
            if (item)
            {
                salesList.Clear();
                this.dgvSaleList.DataSource = null;
                this.dgvSaleList.Rows.Clear();
                uC.dgvSale.Rows.Clear();
                amount = 0;
                lblAmount.Text = amount.ToString();
                uC.GetSaleTable();
                MessageBox.Show("Task successfully completed.");
            }
            else
            {
                MessageBox.Show("Insufficient stock!");
            }
        }

        private void btnAddCart_Click(object sender, EventArgs e)
        {
            Sales sales = new();
            sales.Name = txtName.Text;
            sales.ISBNId = Convert.ToInt64(cmbISBN.Text);
            sales.UserId = cmbUser.SelectedIndex + 1;
            sales.Pieces = Convert.ToInt32(txtAmount.Text);
            salesList.Add(sales);
            AddTable();
        }

        private void AddTable()
        {
            List<Book> books = bookManager.GetBooksList();
            List<User> users = userManager.GetUsersList();

            var result = (from t1 in salesList
                          join t2 in books
                          on t1.ISBNId equals t2.ISBN
                          select new {
                              colText = t2.Name,
                              colAmount = t1.Pieces
                          }).ToList();
            dgvSaleList.Rows.Clear();
            amount = 0;
            result.ForEach(x => {
                dgvSaleList.Rows.Add(x.colText, x.colAmount);  //Satış işlemi tamamlanacak
                amount += x.colAmount;                         //UCSale ekranı da yapılacak
            });
            lblAmount.Text = amount.ToString();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUser user = new();
            user.Show();
            control = true;
        }

        private void AddSales_Activated(object sender, EventArgs e)
        {
            if (control)
            {
                var userList = userManager.GetUsersList();
                cmbUser.DataSource = userList.Select(x => x.UserName).ToList();
                control = false;
            }
        }

        private void cmbISBN_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedISBN = cmbISBN.Text;
            var book = bookManager.GetBookId(Convert.ToInt64(selectedISBN));
            txtName.Text = book.Name;
        }

        private void dgvSaleList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] == colDel && e.RowIndex >= 0)
            {
                try
                {
                    var item = salesList.Find(x => x.Name == dgvSaleList[0, e.RowIndex].Value.ToString());
                    int amount = Convert.ToInt32(lblAmount.Text);
                    if (item == null)
                    {
                        amount -= 1;
                    }
                    else
                    {
                        amount -= item.Pieces;
                    }
                    lblAmount.Text = amount.ToString();
                    salesList.Remove(item);
                    dgvSaleList.Rows.RemoveAt(e.RowIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.Message);
                }
            }
        }

        #endregion
    }
}
