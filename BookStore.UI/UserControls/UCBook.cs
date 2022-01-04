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
using BookStore.UI.Forms;

namespace BookStore.UI.UserControls
{
    public partial class UCBook : UserControl
    {
        #region Instantiates

        BookManager bookManager = new();
        PublisherManager publisherManager = new();
        AuthorManager authorManager = new();
        CategoryManager categoryManager = new();
        StockManager stockManager = new();
        SaleManager saleManager = new();

        #endregion

        #region Constructors

        public UCBook()
        {
            InitializeComponent();
            GetBooksTable();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            AddBook addBook = new(this);
            addBook.Show();
        }

        #endregion

        #region Methods

        public void GetBooksTable()
        {

            List<Book> books = bookManager.GetBooksList();
            List<Publisher> publishers = publisherManager.GetPublishersList();
            List<Author> authors = authorManager.GetAuthorsList();
            List<Category> categories = categoryManager.GetCategoriesList();

            var result = (from t1 in books
                          join t2 in publishers
                          on t1.PublisherId equals t2.Id
                          join t3 in authors
                          on t1.AuthorId equals t3.Id
                          join t4 in categories
                          on t1.CategoryId equals t4.Id
                          select new {
                              colISBN = t1.ISBN,
                              colName = t1.Name,
                              colDate = t1.PublicationDate,
                              colDesc = t1.Description,
                              colPurchase = t1.PurchasePrice,
                              colSale = t1.SalePrice,
                              colAuthor = t3.Name,
                              colCategory = t4.Name,
                              colPub = t2.Name,
                              colStock = t1.TotalStock
                          }).ToList();

            result.ForEach(x => {
                dgvBook.Rows.Add(x.colISBN, x.colName, x.colDate, x.colDesc, x.colPurchase, x.colSale, x.colAuthor, x.colCategory, x.colPub, x.colStock);
            });
        }

        private void dgvBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] == colUp &&
                e.RowIndex >= 0)
            {
                try
                {
                    Book book = bookManager.GetBookId(Convert.ToInt64(dgvBook[0, e.RowIndex].Value));
                    book.Name = dgvBook[1, e.RowIndex].Value.ToString();
                    book.PublicationDate = Convert.ToInt32(dgvBook[2, e.RowIndex].Value);
                    book.Description = dgvBook[3, e.RowIndex].Value.ToString();
                    book.PurchasePrice = Convert.ToInt32(dgvBook[4, e.RowIndex].Value);
                    book.SalePrice = Convert.ToInt32(dgvBook[5, e.RowIndex].Value);
                    book.AuthorId = authorManager.GetAuthorsList().Find(x => x.Name == dgvBook[6, e.RowIndex].Value.ToString()).Id;
                    book.CategoryId = categoryManager.GetCategoriesList().Find(x => x.Name == dgvBook[7, e.RowIndex].Value.ToString()).Id;
                    book.PublisherId = publisherManager.GetPublishersList().Find(x => x.Name == dgvBook[8, e.RowIndex].Value.ToString()).Id;
                    book.TotalStock = Convert.ToInt32(dgvBook[9, e.RowIndex].Value);
                    bookManager.UpdateBook(book);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.Message);
                }
            }
            else if (senderGrid.Columns[e.ColumnIndex] == colDel &&
                e.RowIndex >= 0)
            {
                Book book = bookManager.GetBookId(Convert.ToInt64(dgvBook[0, e.RowIndex].Value));

                if (book.TotalStock != 0)
                {
                    throw new Exception("There are unsold books in stock. Therefore, you cannot do this.");
                }

                bool item = bookManager.RemoveBook(book);
                dgvBook.Rows.RemoveAt(e.RowIndex);//eksik bura

                if (item == true)
                {
                    MessageBox.Show("Task successfully completed.");
                }
                else
                {
                    MessageBox.Show("Failed to delete data. Please try again...");
                }
            }
        }

        #endregion
    }
}
