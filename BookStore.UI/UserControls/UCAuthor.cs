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
using BookStore.Business.Functions;
using BookStore.Entity.Concrete;

namespace BookStore.UI.UserControls
{
    public partial class UCAuthor : UserControl
    {
        #region Instantiates

        PublisherManager publisherManager = new();
        AuthorManager authorManager = new();
        BookManager bookManager = new();

        #endregion

        #region Constructors

        public UCAuthor()
        {
            InitializeComponent();

            GetAuthorsTable();
        }

        #endregion

        #region Methods

        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            AddAuthor addAuthor = new(this);
            addAuthor.Show();
        }
        public void GetAuthorsTable()
        {

            List<Author> authors = authorManager.GetAuthorsList();
            List<Publisher> publishers = publisherManager.GetPublishersList();

            var result = (from t1 in authors
                          join t2 in publishers
                          on t1.PublisherId equals t2.Id
                          select new {
                              colName = t1.Name,
                              colPublisher = t2.Name
                          }).ToList();

            result.ForEach(x => {
                dgvAuthor.Rows.Add(x.colName, x.colPublisher);
            });
        }

        private void dgvAuthor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] == colUp &&
                e.RowIndex >= 0)
            {
                try
                {
                    Author author = authorManager.GetAuthorId(e.RowIndex + 1);
                    author.Name = dgvAuthor[0, e.RowIndex].Value.ToString();
                    author.PublisherId = publisherManager.GetPublishersList().Find(x => x.Name == dgvAuthor[1, e.RowIndex].Value.ToString()).Id;
                    authorManager.UpdateAuthor(author);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.Message);
                }
            }
            else if (senderGrid.Columns[e.ColumnIndex] == colDel &&
                e.RowIndex >= 0)
            {
                Author author = authorManager.GetAuthorId(e.RowIndex + 1);
                int result = RemoveControl(author);
                if (result == 0)
                {
                    bool item = authorManager.RemoveAuthor(author);
                    dgvAuthor.Rows.RemoveAt(e.RowIndex);

                    if (item == true)
                    {
                        MessageBox.Show("Task successfully completed.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete data. Please try again...");
                    }
                }
                else
                {
                    MessageBox.Show("The author you want to delete is associated with another table.");
                }
            }
        }
        private int RemoveControl(Author author)
        {
            List<Book> books = bookManager.GetBooksList();

            var result = (from t1 in books
                          where t1.AuthorId == author.Id
                          select books).Count();
            return result;
        }

        #endregion
    }
}
