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
    public partial class UCUser : UserControl
    {
        #region Instantiates

        UserManager userManager = new();

        #endregion

        #region Constructor

        public UCUser()
        {
            InitializeComponent();

            GetUsersTable();
        }

        #endregion

        #region Methods

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            AddUser addUser = new(this);
            addUser.Show();
        }

        public void GetUsersTable()
        {
            List<User> users = userManager.GetUsersList();
            users.ForEach(user => {
                dgvUser.Rows.Add(user.Id, user.UserName, user.CreationTime, user.MailAdress, user.PhoneNumber);
            });
        }

        private void dgvBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] == cutomersUpdate &&
                e.RowIndex >= 0)
            {
                try
                {
                    User user = userManager.GetUserId(e.RowIndex + 1);
                    user.UserName = dgvUser[1, e.RowIndex].Value.ToString();
                    user.MailAdress = dgvUser[3, e.RowIndex].Value.ToString();
                    user.PhoneNumber = dgvUser[4, e.RowIndex].Value.ToString();
                    userManager.UpdateUser(user);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.Message);
                }
            }
            else if (senderGrid.Columns[e.ColumnIndex] == customersDel &&
                e.RowIndex >= 0)
            {
                User user = userManager.GetUserId(e.RowIndex + 1);
                bool item = userManager.RemoveUser(user);
                dgvUser.Rows.RemoveAt(e.RowIndex);

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
