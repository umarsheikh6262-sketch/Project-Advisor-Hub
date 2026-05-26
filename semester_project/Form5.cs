using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace semester_project
{
    public partial class Form5 : Form
    {
        private readonly string _advisorIdentifier;

        public Form5(string identifier)
        {
            InitializeComponent();
            _advisorIdentifier = identifier;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            LoadAssignedGroups();
        }

        private void LoadAssignedGroups()
        {
            // Query groups where this advisor is assigned (AdvisorID stored on Groups table)
            string query = @"
                SELECT g.GroupID, p.Title AS [Project Title], p.Description AS [Project Specification], p.Deadline
                FROM Groups g
                INNER JOIN Advisors adv ON g.AdvisorID = adv.AdvisorID
                LEFT JOIN Projects p ON g.GroupID = p.GroupID
                WHERE adv.AdvisorID = @ID OR adv.Email = @ID";

            var parameters = new Dictionary<string, object> { { "@ID", _advisorIdentifier } };
            
            try
            {
                DataTable groupsTable = DatabaseHelper.GetDataTable(query, parameters);
                dgvAssignedGroups.DataSource = groupsTable;
                lblTotalGroups.Text = $"Total Active Groups: {groupsTable.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading groups: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
