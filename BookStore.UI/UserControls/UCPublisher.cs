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
    public partial class UCPublisher : UserControl
    {
        #region Instantiates

        PublisherManager publisherManager = new();
        AuthorManager authorManager = new();

        #endregion

        #region Constructor

        public UCPublisher()
        {
            InitializeComponent();

            GetPublishersTable();
        }

        #endregion

        #region Methods

        private void btnAddPublisher_Click(object sender, EventArgs e)
        {
            AddPublisher addPublisher = new(this);
            addPublisher.Show();
        }
        public void GetPublishersTable()
        {
            List<Publisher> publishers = publisherManager.GetPublishersList();
            publishers.ForEach(x => {
                dgvPublisher.Rows.Add(x.Id, x.Name);
            });
        }

        private void dgvPublisher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] == colUp &&
                e.RowIndex >= 0)
            {
                try
                {
                    Publisher publisher = publisherManager.GetPublisherId(e.RowIndex + 1);
                    publisher.Name = dgvPublisher[1, e.RowIndex].Value.ToString();
                    publisherManager.UpdatePublisher(publisher);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.Message);                    
                }                
            }
            else if (senderGrid.Columns[e.ColumnIndex] == colDel &&
                e.RowIndex >= 0)
            {
                Publisher publisher = publisherManager.GetPublisherId(e.RowIndex + 1);
                int result = RemoveControl(publisher);

                if (result == 0)
                {
                    bool item = publisherManager.RemovePublisher(publisher);
                    dgvPublisher.Rows.RemoveAt(e.RowIndex);

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
                    MessageBox.Show("The publisher you want to delete is associated with another table.");
                }

            }
        }

        private int RemoveControl(Publisher publisher)
        {
            List<Author> authors = authorManager.GetAuthorsList();

            var result = (from t1 in authors
                          where t1.PublisherId == publisher.Id
                          select authors).Count();
            return result;
        }

        #endregion
    }
}
