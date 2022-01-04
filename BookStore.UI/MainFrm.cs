using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStore.UI.UserControls;

namespace BookStore.UI
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
            UCHome uch = new();
            AddControlsToPanel(uch);
        }
        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }
        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);
        }

        #region Buton methods
        private void btnHome_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnHome);
            UCHome uch = new();
            AddControlsToPanel(uch);
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnBooks);
            UCBook uch = new();
            AddControlsToPanel(uch);
        }

        private void btnAuthor_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnAuthor);
            UCAuthor uca = new();
            AddControlsToPanel(uca);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnCategory);
            UCCategory ucc = new();
            AddControlsToPanel(ucc);
        }

        private void btnPublisher_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnPublisher);
            UCPublisher ucp = new();
            AddControlsToPanel(ucp);
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnSales);
            UCSale ucs = new();
            AddControlsToPanel(ucs);
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnStock);
            UCStock us = new();
            AddControlsToPanel(us);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnUser);
            UCUser ucu = new();
            AddControlsToPanel(ucu);
        }
        #endregion
    }
}
