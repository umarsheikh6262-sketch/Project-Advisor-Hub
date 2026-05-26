using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace semester_project
{
    public partial class Form4 : Form
    {
        private readonly string _studentIdentifier;
        private string _currentGroupId;

        public Form4(string identifier)
        {
            InitializeComponent();
            this._studentIdentifier = identifier;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadStudentDashboardData();
        }

        private void LoadStudentDashboardData()
        {
            var parameters = new Dictionary<string, object> { { "@ID", _studentIdentifier } };

            // FIXED: Removed GroupAdvisors and joined Groups directly to Advisors
            string query = @"
                SELECT p.Title, p.Description, p.Deadline, s.GroupID, adv.Name AS AdvisorName, adv.Email AS AdvisorEmail
                FROM Students s
                LEFT JOIN Projects p ON s.GroupID = p.GroupID
                LEFT JOIN Groups g ON s.GroupID = g.GroupID
                LEFT JOIN Advisors adv ON g.AdvisorID = adv.AdvisorID
                WHERE s.RollNo = @ID OR s.Email = @ID";

            try
            {
                DataTable dt = DatabaseHelper.GetDataTable(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    _currentGroupId = row["GroupID"]?.ToString();
                    UpdateUI(row);
                    LoadTeamMembers();
                    LoadSubmissionStatus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading dashboard: " + ex.Message);
            }
        }

        private void UpdateUI(DataRow row)
        {
            lblGroupDisplay.Text = string.IsNullOrEmpty(_currentGroupId) ? "No Group Assigned" : $"Group ID: {_currentGroupId}";
            lblProjectTitle.Text = row["Title"] != DBNull.Value ? row["Title"].ToString() : "Project Not Assigned";
            txtProjectDesc.Text = row["Description"] != DBNull.Value ? row["Description"].ToString() : "No description available.";
            lblDeadlineDisplay.Text = row["Deadline"] != DBNull.Value ? Convert.ToDateTime(row["Deadline"]).ToShortDateString() : "N/A";

            lblAdvisorName.Text = row["AdvisorName"] != DBNull.Value ? $"Name: {row["AdvisorName"]}" : "Name: Unassigned";
            lblAdvisorEmail.Text = row["AdvisorEmail"] != DBNull.Value ? $"Email: {row["AdvisorEmail"]}" : "";
        }

        private void LoadTeamMembers()
        {
            if (string.IsNullOrEmpty(_currentGroupId)) return;

            string query = "SELECT RollNo, Name, Program, Email FROM Students WHERE GroupID = @GID AND RollNo != @ID AND Email != @ID";
            var pars = new Dictionary<string, object> { { "@GID", _currentGroupId }, { "@ID", _studentIdentifier } };
            dgvGroupMembers.DataSource = DatabaseHelper.GetDataTable(query, pars);
        }

        private void LoadSubmissionStatus()
        {
            if (string.IsNullOrEmpty(_currentGroupId)) return;

            string query = "SELECT ProposalDate, DocumentationDate FROM Submissions WHERE GroupID = @GID";
            DataTable dt = DatabaseHelper.GetDataTable(query, new Dictionary<string, object> { { "@GID", _currentGroupId } });

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["ProposalDate"] != DBNull.Value)
                    SetStatus(lblProposalStatus, Convert.ToDateTime(dt.Rows[0]["ProposalDate"]));
                if (dt.Rows[0]["DocumentationDate"] != DBNull.Value)
                    SetStatus(lblDocStatus, Convert.ToDateTime(dt.Rows[0]["DocumentationDate"]));
            }
        }

        private void SetStatus(Label lbl, DateTime date)
        {
            lbl.Text = "Submitted: " + date.ToString("g");
            lbl.ForeColor = System.Drawing.Color.Green;
        }

        private void btnSubmitProposal_Click(object sender, EventArgs e) => SubmitFile("ProposalPath", "ProposalDate", lblProposalStatus);
        private void btnSubmitDoc_Click(object sender, EventArgs e) => SubmitFile("DocumentationPath", "DocumentationDate", lblDocStatus);

        private void SubmitFile(string pathCol, string dateCol, Label lbl)
        {
            if (string.IsNullOrEmpty(_currentGroupId))
            {
                MessageBox.Show("Group assignment required for submissions.");
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "PDF|*.pdf|Word|*.docx|All|*.*" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string checkSql = "SELECT COUNT(*) FROM Submissions WHERE GroupID=@G";
                    int count = (int)DatabaseHelper.ExecuteScalar(checkSql, new Dictionary<string, object> { { "@G", _currentGroupId } });

                    string query = count == 0
                        ? $"INSERT INTO Submissions (GroupID, {pathCol}, {dateCol}) VALUES (@G, @P, GETDATE())"
                        : $"UPDATE Submissions SET {pathCol}=@P, {dateCol}=GETDATE() WHERE GroupID=@G";

                    DatabaseHelper.ExecuteNonQuery(query, new Dictionary<string, object> { { "@G", _currentGroupId }, { "@P", ofd.FileName } });
                    SetStatus(lbl, DateTime.Now);
                    MessageBox.Show("File submitted successfully!");
                }
            }
        }

        private void StudentDashboard_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();
    }
}