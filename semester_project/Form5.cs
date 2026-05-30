using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace semester_project
{
    public partial class Form5 : Form
    {
        private readonly string _advisorIdentifier;
        private DataTable _dtEvaluation;
        private DataTable _dtUncompleted;
        private DataTable _dtUpdateProjects;
        private DataTable _dtDeadlines;
        private int _selectedDeadlineProjectId = -1;
        private string _selectedDeadlineGroupId = null;

        public Form5(string identifier)
        {
            InitializeComponent();
            _advisorIdentifier = identifier;
            // Set fonts for modern look
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            ShowPanel("Home");
            LoadDashboardCounts();
            LoadEvaluationPending();
            LoadUncompletedProjects();
            LoadUpdateProjects();
            LoadDeadlines();
        }

        #region Navigation
        private void btnHome_Click(object sender, EventArgs e)
        {
            ShowPanel("Home");
        }

        private void btnEvaluationPending_Click(object sender, EventArgs e)
        {
            ShowPanel("Evaluation");
        }

        private void btnUncompleted_Click(object sender, EventArgs e)
        {
            ShowPanel("Uncompleted");
        }

        private void btnUpdateProject_Click(object sender, EventArgs e)
        {
            ShowPanel("Update");
        }

        private void btnIncreaseDeadline_Click(object sender, EventArgs e)
        {
            ShowPanel("Increase");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Try to show an existing Form2 if present, otherwise just close
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType().Name == "Form2")
                {
                    f.Show();
                    break;
                }
            }

            this.Close();
        }

        private void ShowPanel(string name)
        {
            pnlHome.Visible = name == "Home";
            pnlEvaluation.Visible = name == "Evaluation";
            pnlUncompleted.Visible = name == "Uncompleted";
            pnlUpdate.Visible = name == "Update";
            pnlIncreaseDeadline.Visible = name == "Increase";

            lblHeader.Text = name == "Home" ? "Dashboard" :
                             name == "Evaluation" ? "Evaluation Pending" :
                             name == "Uncompleted" ? "Uncompleted Projects" :
                             name == "Update" ? "Update Projects" :
                             name == "Increase" ? "Increase Deadlines" : "Dashboard";
        }
        #endregion

        #region Dashboard
        private void LoadDashboardCounts()
        {
            try
            {
                var parameters = new Dictionary<string, object> { { "@ID", _advisorIdentifier } };
                // Count total projects assigned to this advisor
                string totalQuery = @"SELECT COUNT(*) FROM Projects p INNER JOIN Groups g ON p.GroupID = g.GroupID INNER JOIN Advisors adv ON g.AdvisorID = adv.AdvisorID WHERE adv.AdvisorID = @ID OR adv.Email = @ID";
                object total = DatabaseHelper.ExecuteScalar(totalQuery, parameters);
                int totalCount = (total == null || total == DBNull.Value) ? 0 : Convert.ToInt32(total);
                // Show number when > 0, otherwise show a friendly label and change visual style
                if (totalCount > 0)
                {
                    lblCardTotalProjectsCount.Text = totalCount.ToString();
                    lblCardTotalProjectsCount.ForeColor = System.Drawing.Color.FromArgb(12, 40, 85);
                    lblCardTotalProjectsCount.Font = new System.Drawing.Font(lblCardTotalProjectsCount.Font.FontFamily, 20F, System.Drawing.FontStyle.Bold);
                }
                else
                {
                    lblCardTotalProjectsCount.Text = "No Projects";
                    lblCardTotalProjectsCount.ForeColor = System.Drawing.Color.Gray;
                    lblCardTotalProjectsCount.Font = new System.Drawing.Font(lblCardTotalProjectsCount.Font.FontFamily, 12F, System.Drawing.FontStyle.Regular);
                }

                // Pending evaluations
                string pendingEvalQuery = @"SELECT COUNT(*) FROM Projects p INNER JOIN Groups g ON p.GroupID = g.GroupID INNER JOIN Advisors adv ON g.AdvisorID = adv.AdvisorID LEFT JOIN Submissions s ON g.GroupID = s.GroupID WHERE (adv.AdvisorID = @ID OR adv.Email = @ID) AND (p.EvaluationStatus IS NULL OR p.EvaluationStatus = 'Pending')";
                object pending = DatabaseHelper.ExecuteScalar(pendingEvalQuery, parameters);
                int pendingCount = (pending == null || pending == DBNull.Value) ? 0 : Convert.ToInt32(pending);
                if (pendingCount > 0)
                {
                    lblCardPendingCount.Text = pendingCount.ToString();
                    lblCardPendingCount.ForeColor = System.Drawing.Color.FromArgb(255, 140, 0);
                    lblCardPendingCount.Font = new System.Drawing.Font(lblCardPendingCount.Font.FontFamily, 20F, System.Drawing.FontStyle.Bold);
                }
                else
                {
                    lblCardPendingCount.Text = "No Pending";
                    lblCardPendingCount.ForeColor = System.Drawing.Color.Gray;
                    lblCardPendingCount.Font = new System.Drawing.Font(lblCardPendingCount.Font.FontFamily, 12F, System.Drawing.FontStyle.Regular);
                }

                // Completed evaluations
                string completedQuery = @"SELECT COUNT(*) FROM Projects p INNER JOIN Groups g ON p.GroupID = g.GroupID INNER JOIN Advisors adv ON g.AdvisorID = adv.AdvisorID WHERE (adv.AdvisorID = @ID OR adv.Email = @ID) AND p.EvaluationStatus = 'Completed'";
                object completed = DatabaseHelper.ExecuteScalar(completedQuery, parameters);
                int completedCount = (completed == null || completed == DBNull.Value) ? 0 : Convert.ToInt32(completed);
                if (completedCount > 0)
                {
                    lblCardCompletedCount.Text = completedCount.ToString();
                    lblCardCompletedCount.ForeColor = System.Drawing.Color.FromArgb(34, 139, 34);
                    lblCardCompletedCount.Font = new System.Drawing.Font(lblCardCompletedCount.Font.FontFamily, 20F, System.Drawing.FontStyle.Bold);
                }
                else
                {
                    lblCardCompletedCount.Text = "No Completed";
                    lblCardCompletedCount.ForeColor = System.Drawing.Color.Gray;
                    lblCardCompletedCount.Font = new System.Drawing.Font(lblCardCompletedCount.Font.FontFamily, 12F, System.Drawing.FontStyle.Regular);
                }

                // Uncompleted (not completed)
                string uncompletedQuery = @"SELECT COUNT(*) FROM Projects p INNER JOIN Groups g ON p.GroupID = g.GroupID INNER JOIN Advisors adv ON g.AdvisorID = adv.AdvisorID WHERE (adv.AdvisorID = @ID OR adv.Email = @ID) AND (p.EvaluationStatus IS NULL OR p.EvaluationStatus <> 'Completed')";
                object uncompleted = DatabaseHelper.ExecuteScalar(uncompletedQuery, parameters);
                int uncompletedCount = (uncompleted == null || uncompleted == DBNull.Value) ? 0 : Convert.ToInt32(uncompleted);
                if (uncompletedCount > 0)
                {
                    lblCardUncompletedCount.Text = uncompletedCount.ToString();
                    lblCardUncompletedCount.ForeColor = System.Drawing.Color.FromArgb(200, 30, 50);
                    lblCardUncompletedCount.Font = new System.Drawing.Font(lblCardUncompletedCount.Font.FontFamily, 20F, System.Drawing.FontStyle.Bold);
                }
                else
                {
                    lblCardUncompletedCount.Text = "No Uncompleted";
                    lblCardUncompletedCount.ForeColor = System.Drawing.Color.Gray;
                    lblCardUncompletedCount.Font = new System.Drawing.Font(lblCardUncompletedCount.Font.FontFamily, 12F, System.Drawing.FontStyle.Regular);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load dashboard counts: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Evaluation Pending
        private void LoadEvaluationPending()
        {
            try
            {
                // Use Submissions for file paths; Projects holds project info and Group relation
                string query = @"SELECT p.ProjectID, g.GroupName, p.Title AS ProjectTitle, s.ProposalPath, s.DocumentationPath, COALESCE(s.ProposalDate, s.DocumentationDate) AS SubmittedDate, p.Grade, p.EvaluationStatus FROM Projects p INNER JOIN Groups g ON p.GroupID = g.GroupID LEFT JOIN Submissions s ON g.GroupID = s.GroupID INNER JOIN Advisors adv ON g.AdvisorID = adv.AdvisorID WHERE (adv.AdvisorID = @ID OR adv.Email = @ID) AND (p.EvaluationStatus IS NULL OR p.EvaluationStatus = 'Pending') ORDER BY COALESCE(s.ProposalDate, s.DocumentationDate) DESC";
                var parameters = new Dictionary<string, object> { { "@ID", _advisorIdentifier } };
                _dtEvaluation = DatabaseHelper.GetDataTable(query, parameters);
                dgvEvaluationPending.DataSource = _dtEvaluation;

                // Remove previously added custom columns if present
                for (int i = dgvEvaluationPending.Columns.Count - 1; i >= 0; i--)
                {
                    var c = dgvEvaluationPending.Columns[i];
                    if (c.Name == "Evaluate" || c.Name == "ViewProposal" || c.Name == "ViewDocumentation" || c.Name == "GradeInput" || c.Name == "SubmitGrade")
                        dgvEvaluationPending.Columns.RemoveAt(i);
                }

                // Add Evaluate (grade) button at the start
                var btnEvaluate = new DataGridViewButtonColumn { Name = "Evaluate", HeaderText = "", Text = "Grade", UseColumnTextForButtonValue = true };
                dgvEvaluationPending.Columns.Insert(0, btnEvaluate);

                // Add view buttons, grade input and submit
                var btnProposal = new DataGridViewButtonColumn { Name = "ViewProposal", HeaderText = "Proposal", Text = "View", UseColumnTextForButtonValue = true };
                dgvEvaluationPending.Columns.Add(btnProposal);
                var btnDoc = new DataGridViewButtonColumn { Name = "ViewDocumentation", HeaderText = "Documentation", Text = "View", UseColumnTextForButtonValue = true };
                dgvEvaluationPending.Columns.Add(btnDoc);
                var gradeCol = new DataGridViewTextBoxColumn { Name = "GradeInput", HeaderText = "Grade" };
                dgvEvaluationPending.Columns.Add(gradeCol);
                var submitBtn = new DataGridViewButtonColumn { Name = "SubmitGrade", HeaderText = "Action", Text = "Submit", UseColumnTextForButtonValue = true };
                dgvEvaluationPending.Columns.Add(submitBtn);

                // Hide ProjectID column to keep grid clean
                if (dgvEvaluationPending.Columns.Contains("ProjectID"))
                    dgvEvaluationPending.Columns["ProjectID"].Visible = false;

                // If the original Grade column exists (from DB) hide it and copy values into the editable GradeInput column
                if (dgvEvaluationPending.Columns.Contains("Grade"))
                {
                    // Make DB Grade column hidden
                    dgvEvaluationPending.Columns["Grade"].Visible = false;
                }

                // Make most columns read-only except the GradeInput so advisor can type or use Evaluate button
                foreach (DataGridViewColumn c in dgvEvaluationPending.Columns)
                {
                    if (c.Name == "GradeInput")
                        c.ReadOnly = false;
                    else
                        c.ReadOnly = true;
                }

                // Populate GradeInput cells with any existing grade values from the hidden Grade column
                bool hasGradeCol = dgvEvaluationPending.Columns.Contains("Grade");
                bool hasGradeInputCol = dgvEvaluationPending.Columns.Contains("GradeInput");
                if (hasGradeCol && hasGradeInputCol)
                {
                    foreach (DataGridViewRow row in dgvEvaluationPending.Rows)
                    {
                        if (row.IsNewRow) continue;
                        try
                        {
                            var g = row.Cells["Grade"].Value;
                            row.Cells["GradeInput"].Value = (g == null || g == DBNull.Value) ? string.Empty : g.ToString();
                        }
                        catch
                        {
                            // ignore row population errors
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading evaluation list: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchEval_TextChanged(object sender, EventArgs e)
        {
            if (_dtEvaluation == null) return;
            string filter = txtSearchEval.Text.Replace("'", "''");
            var dv = _dtEvaluation.DefaultView;
            dv.RowFilter = string.IsNullOrWhiteSpace(filter) ? "" : $"GroupName LIKE '%{filter}%' OR ProjectTitle LIKE '%{filter}%'";
            dgvEvaluationPending.DataSource = dv;
        }

        private void dgvEvaluationPending_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var grid = dgvEvaluationPending;
            var col = grid.Columns[e.ColumnIndex].Name;
            var row = grid.Rows[e.RowIndex];

            int projectId = Convert.ToInt32(row.Cells["ProjectID"].Value);

            if (col == "Evaluate")
            {
                int? entered = PromptForGrade();
                if (entered.HasValue)
                {
                    try
                    {
                        int rows = SubmitGrade(projectId, entered.Value);
                        if (rows > 0)
                        {
                            MessageBox.Show("Grade submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadEvaluationPending();
                            LoadDashboardCounts();
                        }
                        else
                        {
                            MessageBox.Show("Grade submission failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error submitting grade: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                return;
            }

            if (col == "ViewProposal")
            {
                string path = Convert.ToString(row.Cells["ProposalPath"].Value);
                OpenFileFromPath(path);
            }
            else if (col == "ViewDocumentation")
            {
                string path = Convert.ToString(row.Cells["DocumentationPath"].Value);
                OpenFileFromPath(path);
            }
            else if (col == "SubmitGrade")
            {
                string gradeVal = Convert.ToString(row.Cells["GradeInput"].Value);
                if (string.IsNullOrWhiteSpace(gradeVal))
                {
                    MessageBox.Show("Please enter a grade before submitting.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int gradeInt;
                if (!int.TryParse(gradeVal, out gradeInt))
                {
                    MessageBox.Show("Grade must be a number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    int rows = SubmitGrade(projectId, gradeInt);
                    if (rows > 0)
                    {
                        MessageBox.Show("Grade submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEvaluationPending();
                        LoadDashboardCounts();
                    }
                    else
                    {
                        MessageBox.Show("Grade submission failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error submitting grade: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Prompt for numeric grade (0-100)
        private int? PromptForGrade()
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 300;
                prompt.Height = 140;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.StartPosition = FormStartPosition.CenterParent;
                prompt.Text = "Enter Grade";

                var lbl = new Label() { Left = 10, Top = 10, Text = "Grade (0-100):", AutoSize = true };
                var num = new NumericUpDown() { Left = 12, Top = 35, Width = 260, Minimum = 0, Maximum = 100 };
                var ok = new Button() { Text = "OK", Left = 60, Width = 80, Top = 70, DialogResult = DialogResult.OK };
                var cancel = new Button() { Text = "Cancel", Left = 150, Width = 80, Top = 70, DialogResult = DialogResult.Cancel };
                prompt.Controls.Add(lbl);
                prompt.Controls.Add(num);
                prompt.Controls.Add(ok);
                prompt.Controls.Add(cancel);
                prompt.AcceptButton = ok;
                prompt.CancelButton = cancel;

                var dr = prompt.ShowDialog();
                if (dr == DialogResult.OK)
                    return (int)num.Value;
                return null;
            }
        }

        // Submit grade to database. Note: Projects table must have Grade and EvaluationStatus columns.
        private int SubmitGrade(int projectId, int grade)
        {
            string update = "UPDATE Projects SET Grade = @Grade, EvaluationStatus = 'Completed' WHERE ProjectID = @ProjectID";
            var parameters = new Dictionary<string, object> { { "@Grade", grade }, { "@ProjectID", projectId } };
            return DatabaseHelper.ExecuteNonQuery(update, parameters);
        }

        // Prompt to edit project title and description. Returns (confirmed, title, description)
        private Tuple<bool, string, string> PromptForProjectEdit(string currentTitle, string currentDesc)
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 500;
                prompt.Height = 300;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.StartPosition = FormStartPosition.CenterParent;
                prompt.Text = "Edit Project";

                var lblTitle = new Label() { Left = 10, Top = 10, Text = "Title:", AutoSize = true };
                var txtTitle = new TextBox() { Left = 10, Top = 30, Width = 460, Text = currentTitle };
                var lblDesc = new Label() { Left = 10, Top = 65, Text = "Description:", AutoSize = true };
                var txtDesc = new TextBox() { Left = 10, Top = 85, Width = 460, Height = 110, Multiline = true, ScrollBars = ScrollBars.Vertical, Text = currentDesc };
                var ok = new Button() { Text = "OK", Left = 200, Width = 80, Top = 205, DialogResult = DialogResult.OK };
                var cancel = new Button() { Text = "Cancel", Left = 290, Width = 80, Top = 205, DialogResult = DialogResult.Cancel };
                prompt.Controls.Add(lblTitle);
                prompt.Controls.Add(txtTitle);
                prompt.Controls.Add(lblDesc);
                prompt.Controls.Add(txtDesc);
                prompt.Controls.Add(ok);
                prompt.Controls.Add(cancel);
                prompt.AcceptButton = ok;
                prompt.CancelButton = cancel;

                var dr = prompt.ShowDialog();
                if (dr == DialogResult.OK)
                    return Tuple.Create(true, txtTitle.Text.Trim(), txtDesc.Text.Trim());
                return Tuple.Create(false, currentTitle, currentDesc);
            }
        }

        private void OpenFileFromPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show("No file path provided.", "File Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(path))
            {
                MessageBox.Show("File not found: " + path, "File Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = path,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Uncompleted Projects
        private void LoadUncompletedProjects()
        {
            try
            {
                // Only select projects that are not completed
                string query = @"SELECT p.ProjectID, g.GroupName, p.Title AS ProjectTitle, p.Deadline, p.EvaluationStatus FROM Projects p INNER JOIN Groups g ON p.GroupID = g.GroupID INNER JOIN Advisors adv ON g.AdvisorID = adv.AdvisorID WHERE (adv.AdvisorID = @ID OR adv.Email = @ID) AND (p.EvaluationStatus IS NULL OR p.EvaluationStatus <> 'Completed') ORDER BY p.Deadline ASC";
                var parameters = new Dictionary<string, object> { { "@ID", _advisorIdentifier } };
                _dtUncompleted = DatabaseHelper.GetDataTable(query, parameters);

                // Bind to grid
                dgvUncompleted.DataSource = _dtUncompleted;

                // Hide ProjectID column to keep grid clean
                if (dgvUncompleted.Columns.Contains("ProjectID"))
                    dgvUncompleted.Columns["ProjectID"].Visible = false;

                // Remove any previously added helper columns to avoid duplicates
                for (int i = dgvUncompleted.Columns.Count - 1; i >= 0; i--)
                {
                    var c = dgvUncompleted.Columns[i];
                    if (c.Name == "DaysOverdue" || c.Name == "StatusBadge" || c.Name == "ViewDetails")
                        dgvUncompleted.Columns.RemoveAt(i);
                }

                // Add DaysOverdue and StatusBadge columns
                if (!dgvUncompleted.Columns.Contains("DaysOverdue"))
                {
                    dgvUncompleted.Columns.Add(new DataGridViewTextBoxColumn { Name = "DaysOverdue", HeaderText = "Days Overdue", ReadOnly = true });
                    dgvUncompleted.Columns.Add(new DataGridViewTextBoxColumn { Name = "StatusBadge", HeaderText = "Status", ReadOnly = true });
                    var btnDetails = new DataGridViewButtonColumn { Name = "ViewDetails", HeaderText = "Action", Text = "View", UseColumnTextForButtonValue = true };
                    dgvUncompleted.Columns.Add(btnDetails);
                }

                // Post-process rows for overdue calculation and coloring
                foreach (DataGridViewRow row in dgvUncompleted.Rows)
                {
                    if (row.IsNewRow) continue;
                    DateTime deadline;
                    if (DateTime.TryParse(Convert.ToString(row.Cells["Deadline"].Value), out deadline))
                    {
                        int daysOver = (DateTime.Now.Date - deadline.Date).Days;
                        row.Cells["DaysOverdue"].Value = daysOver > 0 ? daysOver.ToString() : "0";
                        string status = Convert.ToString(row.Cells["EvaluationStatus"].Value);
                        if (daysOver > 0)
                        {
                            row.Cells["StatusBadge"].Value = "Overdue";
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 230, 230);
                        }
                        else if (string.IsNullOrWhiteSpace(status) || status == "Pending")
                        {
                            row.Cells["StatusBadge"].Value = "Pending";
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 245, 225);
                        }
                        else
                        {
                            row.Cells["StatusBadge"].Value = "Upcoming";
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(230, 255, 230);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading uncompleted projects: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUncompleted_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var grid = dgvUncompleted;
            if (grid.Columns[e.ColumnIndex].Name == "ViewDetails")
            {
                var row = grid.Rows[e.RowIndex];
                string title = Convert.ToString(row.Cells["ProjectTitle"].Value);
                string group = Convert.ToString(row.Cells["GroupName"].Value);
                string deadline = Convert.ToString(row.Cells["Deadline"].Value);
                string status = Convert.ToString(row.Cells["StatusBadge"].Value);
                MessageBox.Show($"Group: {group}\nTitle: {title}\nDeadline: {deadline}\nStatus: {status}", "Project Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Update Projects
        private void LoadUpdateProjects()
        {
            try
            {
                // Include GroupID so we can update by group (ensures changes apply app-wide for that group)
                string query = @"SELECT p.ProjectID, p.GroupID, g.GroupName, p.Title, p.Description FROM Projects p INNER JOIN Groups g ON p.GroupID = g.GroupID INNER JOIN Advisors adv ON g.AdvisorID = adv.AdvisorID WHERE (adv.AdvisorID = @ID OR adv.Email = @ID)";
                var parameters = new Dictionary<string, object> { { "@ID", _advisorIdentifier } };
                _dtUpdateProjects = DatabaseHelper.GetDataTable(query, parameters);
                dgvUpdateProjects.DataSource = _dtUpdateProjects;

                // Prevent inline edits: advisors must use the Update button dialog to change Title/Description
                dgvUpdateProjects.ReadOnly = true;

                // Hide internal identifier columns so they are not editable or shown
                if (dgvUpdateProjects.Columns.Contains("ProjectID"))
                    dgvUpdateProjects.Columns["ProjectID"].Visible = false;
                if (dgvUpdateProjects.Columns.Contains("GroupID"))
                    dgvUpdateProjects.Columns["GroupID"].Visible = false;

                if (!dgvUpdateProjects.Columns.Contains("UpdateRow"))
                {
                    var updateBtn = new DataGridViewButtonColumn { Name = "UpdateRow", HeaderText = "Action", Text = "Update", UseColumnTextForButtonValue = true };
                    dgvUpdateProjects.Columns.Add(updateBtn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading projects to update: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUpdateProjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var grid = dgvUpdateProjects;
            if (grid.Columns[e.ColumnIndex].Name == "UpdateRow")
            {
                var row = grid.Rows[e.RowIndex];
                // Use GroupID so update applies everywhere for that group
                string groupId = Convert.ToString(row.Cells["GroupID"].Value);
                string title = Convert.ToString(row.Cells["Title"].Value);
                string desc = Convert.ToString(row.Cells["Description"].Value);

                // Show a dialog to edit Title and Description only
                var result = PromptForProjectEdit(title, desc);
                if (!result.Item1) return; // cancelled

                try
                {
                    string update = "UPDATE Projects SET Title = @Title, Description = @Description WHERE GroupID = @GroupID";
                    var parameters = new Dictionary<string, object> { { "@Title", result.Item2 }, { "@Description", result.Item3 }, { "@GroupID", groupId } };
                    int rows = DatabaseHelper.ExecuteNonQuery(update, parameters);
                    if (rows > 0)
                    {
                        MessageBox.Show("Project updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Refresh all views so the updated title/description appears everywhere for this group
                        LoadUpdateProjects();
                        LoadDashboardCounts();
                        LoadEvaluationPending();
                        LoadUncompletedProjects();
                        LoadDeadlines();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating project: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Increase Deadline
        private void LoadDeadlines()
        {
            try
            {
                // Include GroupID so deadline updates apply across the app for that group
                string query = @"SELECT p.ProjectID, p.GroupID, g.GroupName, p.Title AS ProjectTitle, p.Deadline FROM Projects p INNER JOIN Groups g ON p.GroupID = g.GroupID INNER JOIN Advisors adv ON g.AdvisorID = adv.AdvisorID WHERE (adv.AdvisorID = @ID OR adv.Email = @ID)";
                var parameters = new Dictionary<string, object> { { "@ID", _advisorIdentifier } };
                _dtDeadlines = DatabaseHelper.GetDataTable(query, parameters);
                dgvDeadlines.DataSource = _dtDeadlines;

                // Deadlines should not be edited inline; selection triggers Update dialog
                dgvDeadlines.ReadOnly = true;

                // Hide internal ids from display but keep their values for updates
                if (dgvDeadlines.Columns.Contains("ProjectID"))
                    dgvDeadlines.Columns["ProjectID"].Visible = false;
                if (dgvDeadlines.Columns.Contains("GroupID"))
                    dgvDeadlines.Columns["GroupID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading deadlines: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDeadlines_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDeadlines.SelectedRows.Count == 0) return;
            var row = dgvDeadlines.SelectedRows[0];
            // Store GroupID to change deadline for all projects of this group
            _selectedDeadlineGroupId = Convert.ToString(row.Cells["GroupID"].Value);
            _selectedDeadlineProjectId = Convert.ToInt32(row.Cells["ProjectID"].Value);
            DateTime cur;
            DateTime.TryParse(Convert.ToString(row.Cells["Deadline"].Value), out cur);
            dtpNewDeadline.Value = cur == DateTime.MinValue ? DateTime.Now.Date : cur;
            lblCurrentDeadline.Text = "Current: " + (cur == DateTime.MinValue ? "N/A" : cur.ToShortDateString());
        }

        private void btnUpdateDeadline_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedDeadlineGroupId))
            {
                MessageBox.Show("Please select a project first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime newDate = dtpNewDeadline.Value.Date;
            DateTime curDate;
            var row = dgvDeadlines.SelectedRows.Count > 0 ? dgvDeadlines.SelectedRows[0] : null;
            DateTime.TryParse(Convert.ToString(row?.Cells["Deadline"].Value), out curDate);

            if (newDate <= curDate)
            {
                MessageBox.Show("New deadline must be a future date greater than the current deadline.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Update deadline for all projects of this group so change is global
                string update = "UPDATE Projects SET Deadline = @Deadline WHERE GroupID = @GroupID";
                var parameters = new Dictionary<string, object> { { "@Deadline", newDate }, { "@GroupID", _selectedDeadlineGroupId } };
                int rows = DatabaseHelper.ExecuteNonQuery(update, parameters);
                if (rows > 0)
                {
                    MessageBox.Show("Deadline updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDeadlines();
                    LoadUncompletedProjects();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating deadline: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblCardPendingTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
