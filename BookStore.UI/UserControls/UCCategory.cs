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
    public partial class UCCategory : UserControl
    {
        #region Instantiates

        CategoryManager categoryManager = new();
        BookManager bookManager = new();

        #endregion

        #region Constructor

        public UCCategory()
        {
            InitializeComponent();
            GetCategoryTable();
        }

        #endregion

        #region Methods

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            AddCategory addCategory = new(this);
            addCategory.Show();
        }
        public void GetCategoryTable()
        {
            List<Category> categories = categoryManager.GetCategoriesList();
            categories.ForEach(x => {
                dgvCategory.Rows.Add(x.Id, x.Name);
            });
        }

        private void dgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] == colUp &&
                e.RowIndex >= 0)
            {
                try
                {
                    Category category = categoryManager.GetCategoryId(e.RowIndex + 1);
                    category.Name = dgvCategory[1, e.RowIndex].Value.ToString();
                    categoryManager.UpdateCategory(category);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.InnerException.Message);
                }
            }
            else if (senderGrid.Columns[e.ColumnIndex] == colDel &&
                e.RowIndex >= 0)
            {
                Category category = categoryManager.GetCategoryId(e.RowIndex + 1);
                int result = RemoveControl(category);
                if (result == 0)
                {
                    bool item = categoryManager.RemoveCategory(category);
                    dgvCategory.Rows.RemoveAt(e.RowIndex);

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
                    MessageBox.Show("The category you want to delete is associated with another table.");
                }                
            }
        }

        private int RemoveControl(Category category)
        {
            List<Book> books = bookManager.GetBooksList();

            var result = (from t1 in books
                          where t1.CategoryId == category.Id
                          select books).Count();
            return result;
        }

        #endregion
    }
}
