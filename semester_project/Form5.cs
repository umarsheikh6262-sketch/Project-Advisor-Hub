using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace semester_project
{
    public partial class Form5 : Form
    {
        private string advisorIdentifier; // Holds AdvisorID or Email passed from login
        private readonly string connectionString = @"Data Source=Your Server Name;Initial Catalog=ProjectAdvisorHub;Integrated Security=True;";

        public Form5(string identifier)
        {
            InitializeComponent();
            this.advisorIdentifier = identifier;
            LoadAssignedGroups();
        }

        private void LoadAssignedGroups()
        {
            // Query: Grab groups, project specifications, deadlines linked to this Advisor
            string query = @"
                SELECT ga.GroupID, p.Title AS [Project Title], p.Description AS [Project Specification], p.Deadline
                FROM GroupAdvisors ga
                INNER JOIN Advisors adv ON ga.AdvisorID = adv.AdvisorID
                LEFT JOIN Projects p ON ga.GroupID = p.GroupID
                WHERE adv.AdvisorID = @Identifier OR adv.Email = @Identifier;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@Identifier", SqlDbType.NVarChar, 100).Value = advisorIdentifier;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            dgvAssignedGroups.DataSource = dt;
                            lblTotalGroups.Text = $"Total Active Groups Advising: {dt.Rows.Count}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading advisor workspace data: {ex.Message}", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdvisorDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Prevents process lock issues
        }
    }
}