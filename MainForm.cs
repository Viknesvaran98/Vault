using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PasswordManager.Models;
using PasswordManager.Services;

namespace PasswordManager
{
    public partial class MainForm : Form
    {
        private readonly List<PasswordEntry> entries = new List<PasswordEntry>();
        private readonly List<bool> passwordRevealed = new List<bool>();

        public MainForm()
        {
            InitializeComponent();
            InitializeGrid();
            entries.AddRange(FileService.Load());
            for (int i = 0; i < entries.Count; i++)
            {
                passwordRevealed.Add(false);
            }
            LoadGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var entry = new PasswordEntry
            {
                Website = txtWebsite.Text,
                Username = txtUsername.Text,
                Password = EncryptionService.Encrypt(txtPassword.Text)
            };

            entries.Add(entry);
            passwordRevealed.Add(false);
            FileService.Save(entries);

            LoadGrid();

            txtWebsite.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtWebsite.Focus();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Toggle")
            {
                passwordRevealed[e.RowIndex] = !passwordRevealed[e.RowIndex];
                LoadGrid();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                entries.RemoveAt(e.RowIndex);
                passwordRevealed.RemoveAt(e.RowIndex);
                FileService.Save(entries);
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < entries.Count; i++)
            {
                var entry = entries[i];
                bool revealed = passwordRevealed[i];
                string passwordText = revealed
                    ? EncryptionService.Decrypt(entry.Password)
                    : new string('•', 10);
                string toggleText = revealed ? "🙈" : "👁";

                int rowIndex = dataGridView1.Rows.Add(entry.Website, entry.Username, passwordText, toggleText, "Delete");
                dataGridView1.Rows[rowIndex].Cells[3].Value = toggleText;
                dataGridView1.Rows[rowIndex].Cells[4].Value = "Delete";
            }
        }

        private void InitializeGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Website",
                HeaderText = "Website",
                ReadOnly = true,
                Width = 200
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Username",
                HeaderText = "Username",
                ReadOnly = true,
                Width = 180
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Password",
                HeaderText = "Password",
                ReadOnly = true,
                Width = 180
            });

            dataGridView1.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Toggle",
                HeaderText = "Show/Hide",
                UseColumnTextForButtonValue = false,
                Width = 70,
                ReadOnly = true
            });

            dataGridView1.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Delete",
                UseColumnTextForButtonValue = false,
                Width = 70,
                ReadOnly = true
            });

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.CellClick += DataGridView1_CellClick;
        }
    }
}
