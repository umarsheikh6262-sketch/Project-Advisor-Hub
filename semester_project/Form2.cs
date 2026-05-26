using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace semester_project
{
    public partial class Form2 : Form
    {
        private const string UserPlaceholder = "Username, Roll No, or Advisor ID";
        private const string PassPlaceholder = "Password";

        public Form2()
        {
            InitializeComponent();
            SetupPlaceholders();
        }

        private void SetupPlaceholders()
        {
            SetPlaceholder(txtUsername, UserPlaceholder);
            SetPlaceholder(txtPassword, PassPlaceholder, true);
        }

        private void SetPlaceholder(TextBox textBox, string placeholder, bool isPassword = false)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;
            if (isPassword) textBox.UseSystemPasswordChar = false;
        }

        private void RemovePlaceholder(TextBox textBox, string placeholder, bool isPassword = false)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
                if (isPassword) textBox.UseSystemPasswordChar = !chkShowPassword.Checked;
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e) => RemovePlaceholder(txtUsername, UserPlaceholder);
        private void txtUsername_Leave(object sender, EventArgs e) { if (string.IsNullOrWhiteSpace(txtUsername.Text)) SetPlaceholder(txtUsername, UserPlaceholder); }

        private void txtPassword_Enter(object sender, EventArgs e) => RemovePlaceholder(txtPassword, PassPlaceholder, true);
        private void txtPassword_Leave(object sender, EventArgs e) { if (string.IsNullOrWhiteSpace(txtPassword.Text)) SetPlaceholder(txtPassword, PassPlaceholder, true); }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != PassPlaceholder)
            {
                txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (IsInputInvalid(username, password))
            {
                MessageBox.Show("Please enter both username and password.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string role = AuthenticateUser(username, password);
                if (role != null)
                {
                    NavigateToDashboard(role, username);
                }
                else
                {
                    MessageBox.Show("Invalid credentials. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during login: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsInputInvalid(string user, string pass)
        {
            return user == UserPlaceholder || pass == PassPlaceholder || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass);
        }

        private string AuthenticateUser(string username, string password)
        {
            string query = @"
                SELECT Role FROM Users WHERE Username = @User AND Password = @Pass
                UNION
                SELECT 'STUDENT' FROM Students WHERE (RollNo = @User OR Email = @User) AND Password = @Pass
                UNION
                SELECT 'ADVISOR' FROM Advisors WHERE (AdvisorID = @User OR Email = @User) AND Password = @Pass";

            var parameters = new Dictionary<string, object>
            {
                { "@User", username },
                { "@Pass", password }
            };

            object result = DatabaseHelper.ExecuteScalar(query, parameters);
            return result?.ToString()?.ToUpper();
        }

        private void NavigateToDashboard(string role, string identifier)
        {
            this.Hide();
            Form dashboard = null;

            switch (role)
            {
                case "ADMIN":
                    dashboard = new Form3();
                    break;
                case "STUDENT":
                    dashboard = new Form4(identifier);
                    break;
                case "ADVISOR":
                    dashboard = new Form5(identifier);
                    break;
            }

            if (dashboard != null)
            {
                dashboard.Show();
                dashboard.FormClosed += (s, e) => Application.Exit();
            }
        }

        private void tblRightInner_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
