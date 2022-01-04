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
using BookStore.UI.UserControls;

namespace BookStore.UI.Forms
{
    public partial class AddBook : Form
    {
        #region Instantiates

        BookManager bookManager = new();
        AuthorManager authorManager = new();
        CategoryManager categoryManager = new();
        PublisherManager publisherManager = new();
        UCBook uC = new();

        #endregion

        #region Constructors

        public AddBook()
        {
            InitializeComponent();
            cmbAuthor.DataSource = authorManager.GetAuthorsList().Select(x => x.Name).ToList();
            cmbCategory.DataSource = categoryManager.GetCategoriesList().Select(x => x.Name).ToList();
            cmbPublisher.DataSource = publisherManager.GetPublishersList().Select(x => x.Name).ToList();
        }

        public AddBook(UCBook uCBook) : this()
        {
            uC = uCBook;
        }

        #endregion

        #region Methods

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Book book = new();

            if (txtISBN.Text == "")
            {
                throw new Exception("Please enter the correct ISBN value.");
            }

            book.ISBN = Convert.ToInt64(txtISBN.Text);
            book.Name = txtTitle.Text;
            book.AuthorId = cmbAuthor.SelectedIndex + 1;
            book.CategoryId = cmbCategory.SelectedIndex + 1;
            book.PublisherId = cmbPublisher.SelectedIndex + 1;
            book.PublicationDate = dtpPublication.Value.Year;
            book.SalePrice = Convert.ToDouble(nudSale.Text);
            book.PurchasePrice = Convert.ToDouble(nudPurchase.Text);
            book.Description = rtbDesc.Text;
            book.TotalStock = 0;

            var item = bookManager.AddBook(book);

            if (item == true)
            {
                uC.dgvBook.Rows.Clear();
                uC.GetBooksTable();
                MessageBox.Show("Task successfully completed.");
                Reset();
            }
            else
            {
                MessageBox.Show("Failed to delete data. Please try again...");
            }
        }

        private void Reset()
        {
            txtTitle.Clear();
            txtTitle.Clear();
        }

        #endregion
    }
}
