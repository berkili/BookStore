using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Windows.Forms;
using BookStore.Entity.Concrete;
using BookStore.Business.Functions;
using BookStore.UI.UserControls;

namespace BookStore.UI.Forms
{
    public partial class AddUser : Form
    {
        #region Properties

        public UCUser uC { get; set; }

        #endregion

        #region Constructors

        public AddUser()
        {
            InitializeComponent();
        }
        public AddUser(UCUser uCUser) : this()
        {
            uC = uCUser;
        }

        #endregion

        #region Methods

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            User user = new();
            UserManager userManager = new();

            user.UserName = txtUserName.Text;
            user.PhoneNumber = txtPhone.Text;
            user.CreationTime = DateTime.UtcNow;
            try
            {
                user.MailAdress = new MailAddress(txtMail.Text).Address;
            }
            catch (FormatException)
            {
                throw new FormatException("You did not write the email address in the correct format.");
            }

            var item = userManager.AddUser(user);

            if (item == true)
            {
                uC.dgvUser.Rows.Clear();
                uC.GetUsersTable();
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
