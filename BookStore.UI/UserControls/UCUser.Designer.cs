
namespace BookStore.UI.UserControls
{
    partial class UCUser
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddBook = new System.Windows.Forms.Button();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MailAdress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cutomersUpdate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.customersDel = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddBook
            // 
            this.btnAddBook.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddBook.FlatAppearance.BorderSize = 0;
            this.btnAddBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBook.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddBook.ForeColor = System.Drawing.Color.White;
            this.btnAddBook.Location = new System.Drawing.Point(372, 660);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(138, 56);
            this.btnAddBook.TabIndex = 7;
            this.btnAddBook.Text = "Add ";
            this.btnAddBook.UseVisualStyleBackColor = false;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.UserName,
            this.CreationTime,
            this.MailAdress,
            this.PhoneNumber,
            this.cutomersUpdate,
            this.customersDel});
            this.dgvUser.Location = new System.Drawing.Point(25, 33);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowTemplate.Height = 25;
            this.dgvUser.Size = new System.Drawing.Size(836, 554);
            this.dgvUser.TabIndex = 6;
            this.dgvUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBook_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "Name";
            this.UserName.Name = "UserName";
            this.UserName.Width = 192;
            // 
            // CreationTime
            // 
            this.CreationTime.HeaderText = "Creation Time";
            this.CreationTime.Name = "CreationTime";
            this.CreationTime.ReadOnly = true;
            this.CreationTime.Visible = false;
            // 
            // MailAdress
            // 
            this.MailAdress.HeaderText = "E-mail";
            this.MailAdress.Name = "MailAdress";
            this.MailAdress.Width = 200;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.HeaderText = "Phone Number";
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.Width = 200;
            // 
            // cutomersUpdate
            // 
            this.cutomersUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cutomersUpdate.HeaderText = "";
            this.cutomersUpdate.Name = "cutomersUpdate";
            this.cutomersUpdate.ReadOnly = true;
            this.cutomersUpdate.Text = "Update";
            this.cutomersUpdate.UseColumnTextForButtonValue = true;
            // 
            // customersDel
            // 
            this.customersDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customersDel.HeaderText = "";
            this.customersDel.Name = "customersDel";
            this.customersDel.ReadOnly = true;
            this.customersDel.Text = "Delete";
            this.customersDel.UseColumnTextForButtonValue = true;
            // 
            // UCUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.dgvUser);
            this.Name = "UCUser";
            this.Size = new System.Drawing.Size(886, 790);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn MailAdress;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumber;
        private System.Windows.Forms.DataGridViewButtonColumn cutomersUpdate;
        private System.Windows.Forms.DataGridViewButtonColumn customersDel;
        public System.Windows.Forms.DataGridView dgvUser;
    }
}
