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
    public partial class AddCategory : Form
    {
        #region Property

        public UCCategory uC { get; set; }

        #endregion

        #region Constructors

        public AddCategory()
        {
            InitializeComponent();
        }

        public AddCategory(UCCategory uCCategory) : this()
        {
            uC = uCCategory;
        }

        #endregion

        #region Methods

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Category category = new();
            CategoryManager categoryManager = new();

            category.Name = txtName.Text;

            var item = categoryManager.AddCategory(category);

            if (item == true)
            {
                uC.dgvCategory.Rows.Clear();
                uC.GetCategoryTable();
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
