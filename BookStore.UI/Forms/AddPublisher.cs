using BookStore.Business.Functions;
using BookStore.Entity.Concrete;
using BookStore.UI.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore.UI.Forms
{
    public partial class AddPublisher : Form
    {
        #region Properties
        public UCPublisher publisherUc { get; set; }

        #endregion

        #region Constructors
        public AddPublisher()
        {
            InitializeComponent();
        }
        public AddPublisher(UCPublisher uCPublisher) : this()
        {
            publisherUc = uCPublisher;
        }

        #endregion

        #region Methods

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Publisher publisher = new();
            PublisherManager publisherManager = new();


            publisher.Name = txtName.Text;

            var item = publisherManager.AddPublisher(publisher);

            if (item == true)
            {
                publisherUc.dgvPublisher.Rows.Clear();
                publisherUc.GetPublishersTable();
                MessageBox.Show("Task successfully completed.");
            }
            else
            {
                MessageBox.Show("Failed to add data. Please try again...");
            }
        }

        #endregion
    }
}
