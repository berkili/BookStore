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

namespace BookStore.UI.UserControls
{
    public partial class UCHome : UserControl
    {
        #region Instantiates

        SaleManager saleManager = new();
        UserManager userManager = new();
        AuthorManager authorManager = new();
        BookManager bookManager = new();

        #endregion

        #region Constructor

        public UCHome()
        {
            InitializeComponent();
            ReloadData();
        }

        #endregion

        #region Methods

        private void btnReload_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void ReloadData()
        {
            lblSold.Text = saleManager.GetSalesList().Count().ToString();
            lblCustomers.Text = userManager.GetUsersList().Count().ToString();
            lblTotalBooks.Text = bookManager.GetBooksList().Count().ToString();
            lblTotalAuthors.Text = authorManager.GetAuthorsList().Distinct().Count().ToString();
        }

        #endregion

    }
}
