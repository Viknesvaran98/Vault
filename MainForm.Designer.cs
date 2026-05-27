using System.ComponentModel;
using System.Windows.Forms;

namespace PasswordManager
{
    partial class MainForm
    {
        private IContainer components = null;
        private Label lblWebsite;
        private TextBox txtWebsite;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnAdd;
        private DataGridView dataGridView1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();
            lblWebsite = new Label();
            txtWebsite = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnAdd = new Button();
            dataGridView1 = new DataGridView();

            SuspendLayout();

            lblWebsite.AutoSize = true;
            lblWebsite.Location = new System.Drawing.Point(12, 15);
            lblWebsite.Name = "lblWebsite";
            lblWebsite.Size = new System.Drawing.Size(59, 15);
            lblWebsite.Text = "Website:";

            txtWebsite.Location = new System.Drawing.Point(100, 12);
            txtWebsite.Name = "txtWebsite";
            txtWebsite.Size = new System.Drawing.Size(300, 23);

            lblUsername.AutoSize = true;
            lblUsername.Location = new System.Drawing.Point(12, 50);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(66, 15);
            lblUsername.Text = "Username:";

            txtUsername.Location = new System.Drawing.Point(100, 47);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new System.Drawing.Size(300, 23);

            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(12, 85);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(63, 15);
            lblPassword.Text = "Password:";

            txtPassword.Location = new System.Drawing.Point(100, 82);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new System.Drawing.Size(300, 23);
            txtPassword.UseSystemPasswordChar = true;

            btnAdd.Location = new System.Drawing.Point(100, 120);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(100, 30);
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(12, 170);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(560, 280);

            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(584, 461);
            Controls.Add(dataGridView1);
            Controls.Add(btnAdd);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Controls.Add(txtWebsite);
            Controls.Add(lblWebsite);
            Name = "MainForm";
            Text = "Password Manager";
            StartPosition = FormStartPosition.CenterScreen;

            ResumeLayout(false);
            PerformLayout();
        }
    }
}
