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
    public partial class AddAuthor : Form
    {
        #region Instantiates

        public UCAuthor uC { get; set; }

        #endregion

        #region Constructors

        public AddAuthor()
        {
            InitializeComponent();
            PublisherManager publisherManager = new();
            cmbPublisher.DataSource = publisherManager.GetPublishersList().Select(x => x.Name).ToList();
        }

        public AddAuthor(UCAuthor uCAuthor) : this()
        {
            uC = uCAuthor;
        }

        #endregion

        #region Methods

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Author author = new();
            AuthorManager authorManager = new();

            author.Name = txtName.Text;
            author.PublisherId = cmbPublisher.SelectedIndex + 1;

            var item = authorManager.AddAuthor(author);

            if (item == true)
            {
                uC.dgvAuthor.Rows.Clear();
                uC.GetAuthorsTable();
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
