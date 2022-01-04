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
    public partial class UCSale : UserControl
    {
        #region Instantiates

        SaleManager saleManager = new();
        UserManager userManager = new();

        #endregion

        #region Constructor
        public UCSale()
        {
            InitializeComponent();

            GetSaleTable();
        }

        #endregion

        #region Methods

        private void btnSell_Click(object sender, EventArgs e)
        {
            AddSales addSales = new(this);
            addSales.Show();
        }
        public void GetSaleTable()
        {
            List<Sales> sales = saleManager.GetSalesList();
            List<User> users = userManager.GetUsersList();

            var result = (from t1 in sales
                          join t2 in users
                          on t1.UserId equals t2.Id
                          select new {
                              colName = t1.Name,
                              colUser = t2.UserName,
                              colAmount = t1.Pieces
                          }).ToList();

            result.ForEach(x => {
                dgvSale.Rows.Add(x.colName, x.colUser, x.colAmount);
            });
        }

        #endregion

    }
}
