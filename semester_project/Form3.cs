using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace semester_project
{
    public partial class Form3 : Form
    {
        // Update this string with your local SQL Server instance connection configurations
        private string connectionString = "Server=Your Server Name;Database=ProjectAdvisorHub;Trusted_Connection=True;";
        private Random randomGenerator = new Random();
        // Track currently selected records so Update can reference the original key
        private string originalStudentRoll = null;
        private string originalAdvisorId = null;

        public Form3()
        {
            InitializeComponent();
            HideTabControlHeaders();
            // Defer database work to form load so constructor stays fast and UI remains responsive
            // Do not attach runtime load handler when the form is opened inside the WinForms designer
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                this.Load += Form1_Load;
            }

        }



        private void btnDeleteAdvisor_Click(object sender, EventArgs e)
        {
            if (dgvAdvisors.CurrentRow == null)
            {
                MessageBox.Show("Please select an advisor from the grid list to remove.", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string targetAdvisorId = dgvAdvisors.CurrentRow.Cells["AdvisorID"].Value.ToString();
            string targetAdvisorName = dgvAdvisors.CurrentRow.Cells["Name"].Value.ToString();

            var confirmation = MessageBox.Show(
                $"Are you sure you want to completely remove Prof. {targetAdvisorName} ({targetAdvisorId})?\n\n" +
                "This action will automatically drop them from supervising any project groups.",
                "Confirm Faculty Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmation == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        // Simple delete: rely on database cascade or separate cleanup to handle dependent rows
                        string query = "DELETE FROM Advisors WHERE AdvisorID = @ID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@ID", targetAdvisorId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show($"Prof. {targetAdvisorName} has been successfully removed.", "Advisor Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAdvisorInputFields();
                    RefreshAdvisorGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to complete advisor deletion: " + ex.Message, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        // Global Grid Scrollability & Visual Engine
        private void ApplyGridPolishingStyles(DataGridView dgv)
        {
            if (dgv == null) return;
            dgv.EnableHeadersVisualStyles = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Explicit Scroll Bar Settings for responsiveness
            dgv.ScrollBars = ScrollBars.Both;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Header Setup
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // Cell Formatting
            dgv.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            dgv.RowTemplate.Height = 35;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            dgv.RowHeadersVisible = false;
            dgv.GridColor = System.Drawing.Color.FromArgb(236, 240, 241);

            // Auto fit individual data cell content widths to prevent overflow clips
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Width = 125;
            }
        }

        // Populate advisor input fields when a row is clicked for easy editing
        private void dgvAdvisors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAdvisors.CurrentRow != null)
            {
                DataGridViewRow row = dgvAdvisors.Rows[e.RowIndex];
                txtAdvID.Text = GetCellValueIfExists(dgvAdvisors, row, "AdvisorID");
                // keep original id to allow updating the primary key safely
                originalAdvisorId = GetCellValueIfExists(dgvAdvisors, row, "AdvisorID");
                txtAdvName.Text = GetCellValueIfExists(dgvAdvisors, row, "Name");
                txtAdvFather.Text = GetCellValueIfExists(dgvAdvisors, row, "FatherName");
                txtAdvField.Text = GetCellValueIfExists(dgvAdvisors, row, "FieldOfStudy");
                txtAdvDesignation.Text = GetCellValueIfExists(dgvAdvisors, row, "Designation");
                txtAdvDept.Text = GetCellValueIfExists(dgvAdvisors, row, "Department");
            }
        }

        private void ClearAdvisorInputFields()
        {
            txtAdvID.Clear(); txtAdvName.Clear(); txtAdvFather.Clear(); txtAdvField.Clear(); txtAdvDesignation.Clear(); txtAdvDept.Clear();
        }

        // Populate student input fields when a row is clicked for easy editing
        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvStudents.CurrentRow != null)
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];
                txtStudRoll.Text = GetCellValueIfExists(dgvStudents, row, "RollNo");
                // remember original roll for update WHERE clause
                originalStudentRoll = GetCellValueIfExists(dgvStudents, row, "RollNo");
                txtStudName.Text = GetCellValueIfExists(dgvStudents, row, "Name");
                txtStudFather.Text = GetCellValueIfExists(dgvStudents, row, "FatherName");
                txtStudSession.Text = GetCellValueIfExists(dgvStudents, row, "Session");
                txtStudProgram.Text = GetCellValueIfExists(dgvStudents, row, "Program");
            }
        }

        private void ClearStudentInputFields()
        {
            txtStudRoll.Clear(); txtStudName.Clear(); txtStudFather.Clear(); txtStudSession.Clear(); txtStudProgram.Clear();
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(originalStudentRoll))
            {
                MessageBox.Show("Please select a student row first (click a row) before attempting to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtStudRoll.Text) || string.IsNullOrWhiteSpace(txtStudName.Text))
            {
                MessageBox.Show("Roll and Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newRoll = txtStudRoll.Text.Trim();
            string name = txtStudName.Text.Trim();
            string fatherName = txtStudFather.Text.Trim();
            string session = txtStudSession.Text.Trim();
            string program = txtStudProgram.Text.Trim();

            // Preserve existing email/password if input fields are not provided in the form
            string email = null, password = null;
            if (dgvStudents.CurrentRow != null)
            {
                email = dgvStudents.CurrentRow.Cells["Email"]?.Value?.ToString();
                password = dgvStudents.CurrentRow.Cells["Password"]?.Value?.ToString();
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string updateQuery = @"UPDATE Students SET RollNo=@NewRoll, Name=@Name, FatherName=@FatherName, Session=@Session, Program=@Program, Email=@Email, Password=@Password WHERE RollNo=@OriginalRoll";
                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@NewRoll", newRoll);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@FatherName", fatherName);
                    cmd.Parameters.AddWithValue("@Session", session);
                    cmd.Parameters.AddWithValue("@Program", program);
                    cmd.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Password", (object)password ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OriginalRoll", originalStudentRoll);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Student details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearStudentInputFields();
                originalStudentRoll = null;
                RefreshStudentGrid();
                Task.Run(async () => { await RefreshGroupsGrid(); await RefreshUnassignedStudentsGrid(); }).Wait();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update student: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateAdvisor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(originalAdvisorId))
            {
                MessageBox.Show("Please click an advisor row first to select it before updating.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAdvID.Text) || string.IsNullOrWhiteSpace(txtAdvName.Text))
            {
                MessageBox.Show("Advisor ID and Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newId = txtAdvID.Text.Trim();
            string name = txtAdvName.Text.Trim();
            string fatherName = txtAdvFather.Text.Trim();
            string fieldOfStudy = txtAdvField.Text.Trim();
            string designation = txtAdvDesignation.Text.Trim();
            string department = txtAdvDept.Text.Trim();

            string email = null, password = null;
            if (dgvAdvisors.CurrentRow != null)
            {
                email = dgvAdvisors.CurrentRow.Cells["Email"]?.Value?.ToString();
                password = dgvAdvisors.CurrentRow.Cells["Password"]?.Value?.ToString();
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string updateQuery = @"UPDATE Advisors SET AdvisorID=@NewID, Name=@Name, FatherName=@FatherName, FieldOfStudy=@FieldOfStudy, Designation=@Designation, Department=@Department, Email=@Email, Password=@Password WHERE AdvisorID=@OriginalID";
                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@NewID", newId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@FatherName", fatherName);
                    cmd.Parameters.AddWithValue("@FieldOfStudy", fieldOfStudy);
                    cmd.Parameters.AddWithValue("@Designation", designation);
                    cmd.Parameters.AddWithValue("@Department", department);
                    cmd.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Password", (object)password ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OriginalID", originalAdvisorId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Advisor updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearAdvisorInputFields();
                originalAdvisorId = null;
                RefreshAdvisorGrid();
                Task.Run(async () => { await LoadDashboardStats(); }).Wait();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to modify advisor data: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private async void Form1_Load(object sender, EventArgs e)
        {
            await InitializeDropdownData();
            await LoadDashboardStats();
        }

        // Clean UI Trick: Blends the TabControl smoothly into the sidebar design
        private void HideTabControlHeaders()
        {
            tabControlDashboard.Appearance = TabAppearance.FlatButtons;
            tabControlDashboard.ItemSize = new System.Drawing.Size(0, 1);
            tabControlDashboard.SizeMode = TabSizeMode.Fixed;
        }

        // Populates the dropdown menus on the Project and Advisor assignment tabs
        private async Task InitializeDropdownData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    // Fetch available Group IDs once and reuse copy for the second combo to avoid mirrored selection behavior
                    DataTable dtGroups = new DataTable();
                    using (SqlCommand cmd = new SqlCommand("SELECT GroupID FROM Groups", conn))
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        dtGroups.Load(reader);
                    }

                    cbSelectGroup.DataSource = dtGroups;
                    cbSelectGroup.DisplayMember = "GroupID";
                    cbSelectGroup.ValueMember = "GroupID";

                    cbAdvGroupSelect.DataSource = dtGroups.Copy();
                    cbAdvGroupSelect.DisplayMember = "GroupID";
                    cbAdvGroupSelect.ValueMember = "GroupID";

                    // Fetch Faculty Advisors list
                    DataTable dtAdvisors = new DataTable();
                    using (SqlCommand cmd3 = new SqlCommand("SELECT AdvisorID, Name FROM Advisors", conn))
                    using (var reader3 = await cmd3.ExecuteReaderAsync())
                    {
                        dtAdvisors.Load(reader3);
                    }

                    cbAdvisorSelect.DataSource = dtAdvisors;
                    cbAdvisorSelect.DisplayMember = "Name";
                    cbAdvisorSelect.ValueMember = "AdvisorID";
                }
            }
            catch (Exception ex)
            {
                // Inform user when dropdown initialization fails so they know why UI is empty
                MessageBox.Show("Failed to load dropdown data: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region Embedded Internal Account Generation Logic

        private string GenerateUserEmail(string name, string role)
        {
            if (string.IsNullOrWhiteSpace(name))
                return $"user{randomGenerator.Next(1000, 9999)}@{role}.hub.com";

            string cleanName = name.ToLower().Replace(" ", ".");
            int uniqueId = randomGenerator.Next(1000, 9999);

            return $"{cleanName}{uniqueId}@{role}.hub.com";
        }

        private string GenerateUserPassword()
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$";
            StringBuilder res = new StringBuilder();

            for (int i = 0; i < 8; i++)
            {
                res.Append(validChars[randomGenerator.Next(validChars.Length)]);
            }

            return res.ToString();
        }

        #endregion

        // Safe helper: returns cell value if the named column exists, otherwise empty string
        private string GetCellValueIfExists(DataGridView dgv, DataGridViewRow row, string columnName)
        {
            try
            {
                if (dgv.Columns.Contains(columnName) && row.Cells[columnName].Value != null)
                    return row.Cells[columnName].Value.ToString();
            }
            catch { }
            return string.Empty;
        }

        #region Sidebar Navigation Click Routing
        private async void btnHome_Click(object sender, EventArgs e)
        {
            tabControlDashboard.SelectedTab = tabHome;
            await LoadDashboardStats();
        }

        private void btnManageStudents_Click(object sender, EventArgs e)
        {
            tabControlDashboard.SelectedTab = tabStudents;
            RefreshStudentGrid();
        }

        private void btnManageAdvisors_Click(object sender, EventArgs e)
        {
            tabControlDashboard.SelectedTab = tabAdvisors;
            RefreshAdvisorGrid();
        }

        private async void btnManageGroups_Click(object sender, EventArgs e)
        {
            tabControlDashboard.SelectedTab = tabGroups;
            await RefreshGroupsGrid();
            await RefreshUnassignedStudentsGrid();

            // Forces WinForms to stop using legacy cache dimensions and repaint correctly
            tabGroups.SuspendLayout();
            tabGroups.ResumeLayout(true);
            tabGroups.Refresh();
        }

        // Helper method to look up and list students who don't have a GroupID yet
        private async Task RefreshUnassignedStudentsGrid()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SELECT RollNo, Name, Session, Program, Email FROM Students WHERE GroupID IS NULL", conn))
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dgvUnassignedStudents.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading unassigned students: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAssignStudentToGroup_Click(object sender, EventArgs e)
        {
            // Ensure both grids have a row selected
            if (dgvGroups.CurrentRow == null)
            {
                MessageBox.Show("Please select an target Group from the left grid list.", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvUnassignedStudents.CurrentRow == null)
            {
                MessageBox.Show("Please highlight a Student from the right grid list to add.", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Capture IDs from the highlighted rows
            string selectedGroupId = dgvGroups.CurrentRow.Cells["GroupID"].Value.ToString();
            string selectedStudentRoll = dgvUnassignedStudents.CurrentRow.Cells["RollNo"].Value.ToString();
            string selectedStudentName = dgvUnassignedStudents.CurrentRow.Cells["Name"].Value.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // SQL statement updates the student's GroupID directly
                    string query = "UPDATE Students SET GroupID = @GID WHERE RollNo = @Roll";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@GID", selectedGroupId);
                    cmd.Parameters.AddWithValue("@Roll", selectedStudentRoll);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }

                MessageBox.Show($"Successfully added {selectedStudentName} ({selectedStudentRoll}) to {selectedGroupId}!", "Group Member Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh grids—the assigned student will disappear from the available list instantly
                await RefreshGroupsGrid();
                await RefreshUnassignedStudentsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save group grouping modification: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAssignProjects_Click(object sender, EventArgs e)
        {
            tabControlDashboard.SelectedTab = tabProjects;
            await InitializeDropdownData();
        }

        private async void btnAssignAdvisors_Click(object sender, EventArgs e)
        {
            tabControlDashboard.SelectedTab = tabAssignAdvisors;
            await InitializeDropdownData();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out to the authentication terminal?", "Confirm System Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Form2 loginWindow = new Form2();
                loginWindow.ShowDialog();
                //MessageBox.Show("Logout successful. Redirecting to authentication terminal...", "Session Ended", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        #endregion

        #region TAB 1: System Dashboard Metrics Tracker
        private async Task LoadDashboardStats()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    // Combine counts into a single round-trip to improve startup and refresh speed
                    string combinedQuery = @"
SELECT 
 (SELECT COUNT(*) FROM Students) AS StudentCount,
 (SELECT COUNT(*) FROM Advisors) AS AdvisorCount,
 (SELECT COUNT(*) FROM Projects) AS ProjectCount,
 (SELECT COUNT(*) FROM Groups) AS GroupCount";

                    using (SqlCommand cmd = new SqlCommand(combinedQuery, conn))
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            lblTotalStudents.Text = reader["StudentCount"].ToString();
                            lblTotalAdvisors.Text = reader["AdvisorCount"].ToString();
                            lblTotalProjects.Text = reader["ProjectCount"].ToString();
                            lblTotalGroups.Text = reader["GroupCount"].ToString();
                        }
                    }
                }
            }
            catch (Exception)
            {
                lblTotalStudents.Text = "0";
                lblTotalAdvisors.Text = "0";
                lblTotalProjects.Text = "0";
                lblTotalGroups.Text = "0";
            }
        }
        #endregion

        #region TAB 2: Manage Student Entities
        private async void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudRoll.Text) || string.IsNullOrWhiteSpace(txtStudName.Text))
            {
                MessageBox.Show("Roll Number and Student Name are mandatory system parameters.", "Input Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string email = GenerateUserEmail(txtStudName.Text, "student");
            string password = GenerateUserPassword();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Students (RollNo, Name, FatherName, Session, Program, Email, Password) VALUES (@Roll, @Name, @Father, @Session, @Prog, @Email, @Pass)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Roll", txtStudRoll.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name", txtStudName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Father", txtStudFather.Text.Trim());
                    cmd.Parameters.AddWithValue("@Session", txtStudSession.Text.Trim());
                    cmd.Parameters.AddWithValue("@Prog", txtStudProgram.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Pass", password);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Student Record Saved Successfully!\n\nAuto-Generated System Credentials:\nEmail: {email}\nPassword: {password}", "Credentials Allocated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear out textboxes for subsequent input loops
                txtStudRoll.Clear(); txtStudName.Clear(); txtStudFather.Clear(); txtStudSession.Clear(); txtStudProgram.Clear();
                RefreshStudentGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database write operation failed: " + ex.Message, "SQL Insertion Interrupted", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null) return;

            string targetRoll = dgvStudents.CurrentRow.Cells["RollNo"].Value.ToString();
            var confirmation = MessageBox.Show($"Are you sure you want to completely drop student {targetRoll}? This action cascades structural updates to group tables.", "Confirm Integrity Drop", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmation == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("DELETE FROM Students WHERE RollNo = @Roll", conn);
                        cmd.Parameters.AddWithValue("@Roll", targetRoll);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    RefreshStudentGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Deletion process broke: " + ex.Message, "Execution Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RefreshStudentGrid()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Included Password column for administrative tracking
                    string query = "SELECT RollNo, Name, FatherName, Session, Program, Email, Password FROM Students ORDER BY RollNo ASC";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvStudents.DataSource = dt;
                    ApplyGridPolishingStyles(dgvStudents);
                }
            }
            catch (Exception) { }
        }
        // Placeholder: reserved for future helper methods - no-op patch to preserve file position
        #endregion

        #region TAB 3: Manage Faculty Advisors
        private void btnAddAdvisor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdvID.Text) || string.IsNullOrWhiteSpace(txtAdvName.Text))
            {
                MessageBox.Show("Advisor Faculty ID and Name cannot be null strings.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string email = GenerateUserEmail(txtAdvName.Text, "advisor");
            string password = GenerateUserPassword();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Advisors (AdvisorID, Name, FatherName, FieldOfStudy, Designation, Department, Email, Password) VALUES (@ID, @Name, @Father, @Field, @Desig, @Dept, @Email, @Pass)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", txtAdvID.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name", txtAdvName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Father", txtAdvFather.Text.Trim());
                    cmd.Parameters.AddWithValue("@Field", txtAdvField.Text.Trim());
                    cmd.Parameters.AddWithValue("@Desig", txtAdvDesignation.Text.Trim());
                    cmd.Parameters.AddWithValue("@Dept", txtAdvDept.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Pass", password);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Faculty Member Registered Successfully!\n\nSystem Entry Details:\nEmail: {email}\nPassword: {password}", "Advisor Track Established", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAdvID.Clear(); txtAdvName.Clear(); txtAdvFather.Clear(); txtAdvField.Clear(); txtAdvDesignation.Clear(); txtAdvDept.Clear();
                RefreshAdvisorGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Advisor record insertion failed: " + ex.Message, "Database Crash Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshAdvisorGrid()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Includes FatherName and Password column and explicitly orders dataset by AdvisorID in ascending order
                    string query = "SELECT AdvisorID, Name, FatherName, FieldOfStudy, Designation, Department, Email, Password FROM Advisors ORDER BY AdvisorID ASC";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAdvisors.DataSource = dt;
                    ApplyGridPolishingStyles(dgvAdvisors);
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region TAB 4: Manage Group Formations
        private async void btnCreateGroup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGroupId.Text)) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Groups (GroupID) VALUES (@GID)", conn);
                    cmd.Parameters.AddWithValue("@GID", txtGroupId.Text.Trim());
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                MessageBox.Show("Unique Group ID generated inside architecture indices.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGroupId.Clear();
                await RefreshGroupsGrid();
            }
            catch (SqlException ex) when (ex.Number == 2627) // Key unique constraint primary violation error number
            {
                MessageBox.Show("This Group ID string token has already been mapped. Choose a unique index name.", "Primary Key Conflict", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing group layout instantiation: " + ex.Message);
            }
        }

        private async Task RefreshGroupsGrid()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SELECT GroupID FROM Groups", conn))
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        dgvGroups.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load groups: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRemoveGroup_Click(object sender, EventArgs e)
        {
            if (dgvGroups.CurrentRow == null)
            {
                MessageBox.Show("Please select a group to remove.", "Selection Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string groupId = dgvGroups.CurrentRow.Cells["GroupID"].Value.ToString();

            var confirm = MessageBox.Show($"Are you sure you want to remove group '{groupId}'? This will unassign any students and remove advisor links.", "Confirm Remove Group", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlTransaction tx = conn.BeginTransaction())
                    {
                        // 1) Unassign any students from the group
                        using (SqlCommand cmd1 = new SqlCommand("UPDATE Students SET GroupID = NULL WHERE GroupID = @GID", conn, tx))
                        {
                            cmd1.Parameters.AddWithValue("@GID", groupId);
                            await cmd1.ExecuteNonQueryAsync();
                        }

                        // 2) Remove advisor links
                        using (SqlCommand cmd2 = new SqlCommand("DELETE FROM GroupAdvisors WHERE GroupID = @GID", conn, tx))
                        {
                            cmd2.Parameters.AddWithValue("@GID", groupId);
                            await cmd2.ExecuteNonQueryAsync();
                        }

                        // 3) Remove projects attached to group (optional: keep projects but unlink - here we delete)
                        using (SqlCommand cmd3 = new SqlCommand("DELETE FROM Projects WHERE GroupID = @GID", conn, tx))
                        {
                            cmd3.Parameters.AddWithValue("@GID", groupId);
                            await cmd3.ExecuteNonQueryAsync();
                        }

                        // 4) Delete the group record
                        using (SqlCommand cmd4 = new SqlCommand("DELETE FROM Groups WHERE GroupID = @GID", conn, tx))
                        {
                            cmd4.Parameters.AddWithValue("@GID", groupId);
                            await cmd4.ExecuteNonQueryAsync();
                        }

                        tx.Commit();
                    }
                }

                MessageBox.Show($"Group '{groupId}' removed and all related links cleared.", "Group Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await RefreshGroupsGrid();
                await RefreshUnassignedStudentsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to remove group: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region TAB 5: Allocate Project Schemes
        private async void btnAssignProject_Click(object sender, EventArgs e)
        {
            if (cbSelectGroup.SelectedValue == null || string.IsNullOrWhiteSpace(txtProjectTitle.Text))
            {
                MessageBox.Show("Please map a target Group token and pass a non-empty Title string value.", "Fields Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Projects (GroupID, Title, Description, Deadline) VALUES (@GID, @Title, @Desc, @Dl)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@GID", cbSelectGroup.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Title", txtProjectTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@Desc", txtProjectDesc.Text.Trim());
                    cmd.Parameters.AddWithValue("@Dl", dtpDeadline.Value);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                MessageBox.Show("Project allocation matrix registered successfully.", "Scope Active", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtProjectTitle.Clear(); txtProjectDesc.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to attach project task allocation node: " + ex.Message, "Runtime Database Intercept", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region TAB 6: Linking Advisors
        private async void btnAssignAdvisorToGroup_Click(object sender, EventArgs e)
        {
            if (cbAdvGroupSelect.SelectedValue == null || cbAdvisorSelect.SelectedValue == null) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO GroupAdvisors (GroupID, AdvisorID) VALUES (@GID, @AID)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@GID", cbAdvGroupSelect.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@AID", cbAdvisorSelect.SelectedValue.ToString());

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
                MessageBox.Show("Supervisor dependency constraint bound successfully to group branch.", "Matrix Configured", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("This Faculty Advisor is already assigned to supervise this Student Group.", "Redundant Mapping Prevented", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
    }
}