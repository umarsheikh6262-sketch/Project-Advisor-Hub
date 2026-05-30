using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace semester_project
{
    public partial class Form3 : Form
    {
        private readonly Random _random = new Random();
        private string _originalStudentRoll;
        private string _originalAdvisorId;

        public Form3()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            HideTabHeaders();
            ApplyStyles();
        }

        private void HideTabHeaders()
        {
            tabControlDashboard.Appearance = TabAppearance.FlatButtons;
            tabControlDashboard.ItemSize = new Size(0, 1);
            tabControlDashboard.SizeMode = TabSizeMode.Fixed;
        }

        private void ApplyStyles()
        {
            ApplyGridStyle(dgvStudents);
            ApplyGridStyle(dgvAdvisors);
            ApplyGridStyle(dgvGroups);
            ApplyGridStyle(dgvUnassignedStudents);
        }

        private void ApplyGridStyle(DataGridView dgv)
        {
            if (dgv == null) return;
            dgv.EnableHeadersVisualStyles = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ScrollBars = ScrollBars.Both;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.BackgroundColor = Color.White;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgv.RowTemplate.Height = 35;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async void Form3_Load(object sender, EventArgs e)
        {
            await LoadDashboardStats();
            await InitializeDropdowns();
        }

        #region Navigation
        private async void btnHome_Click(object sender, EventArgs e)
        {
            tabControlDashboard.SelectedTab = tabHome;
            await LoadDashboardStats();
        }

        private void btnManageStudents_Click(object sender, EventArgs e)
        {
            tabControlDashboard.SelectedTab = tabStudents;
            RefreshStudents();
        }

        private void btnManageAdvisors_Click(object sender, EventArgs e)
        {
            tabControlDashboard.SelectedTab = tabAdvisors;
            RefreshAdvisors();
        }

        private async void btnManageGroups_Click(object sender, EventArgs e)
        {
            tabControlDashboard.SelectedTab = tabGroups;
            await RefreshGroupsData();
        }

        private void btnAssignProjects_Click(object sender, EventArgs e)
        {
            tabControlDashboard.SelectedTab = tabProjects;
            _ = InitializeDropdowns();
        }

        private void btnAssignAdvisors_Click(object sender, EventArgs e)
        {
            tabControlDashboard.SelectedTab = tabAssignAdvisors;
            _ = InitializeDropdowns();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                new Form2().Show();
            }
        }
        #endregion

        #region Dashboard
        private async Task LoadDashboardStats()
        {
            try
            {
                string query = @"
                    SELECT 
                        (SELECT COUNT(*) FROM Students) as Students,
                        (SELECT COUNT(*) FROM Advisors) as Advisors,
                        (SELECT COUNT(*) FROM Projects) as Projects,
                        (SELECT COUNT(*) FROM Groups) as Groups";

                DataTable dt = DatabaseHelper.GetDataTable(query);
                if (dt.Rows.Count > 0)
                {
                    lblTotalStudents.Text = dt.Rows[0]["Students"].ToString();
                    lblTotalAdvisors.Text = dt.Rows[0]["Advisors"].ToString();
                    lblTotalProjects.Text = dt.Rows[0]["Projects"].ToString();
                    lblTotalGroups.Text = dt.Rows[0]["Groups"].ToString();
                }
            }
            catch { /* Handle error or ignore for stats */ }
        }
        #endregion

        #region Student Management
        private void RefreshStudents()
        {
            dgvStudents.DataSource = DatabaseHelper.GetDataTable("SELECT RollNo, Name, FatherName, Session, Program, Email, Password FROM Students");
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudRoll.Text) || string.IsNullOrWhiteSpace(txtStudName.Text)) return;
            string roll = txtStudRoll.Text.Trim();

            // Prevent duplicate roll registration
            try
            {
                var exists = DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM Students WHERE RollNo=@Roll", new Dictionary<string, object> { { "@Roll", roll } });
                int cnt = Convert.ToInt32(exists ?? 0);
                if (cnt > 0)
                {
                    MessageBox.Show("A student with this Roll Number already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string email = GenerateEmail(txtStudName.Text, "student");
                string password = GeneratePassword();

                string query = "INSERT INTO Students (RollNo, Name, FatherName, Session, Program, Email, Password) VALUES (@Roll, @Name, @Father, @Session, @Prog, @Email, @Pass)";
                var pars = new Dictionary<string, object> {
                    {"@Roll", roll}, {"@Name", txtStudName.Text.Trim()}, {"@Father", txtStudFather.Text.Trim()},
                    {"@Session", txtStudSession.Text.Trim()}, {"@Prog", txtStudProgram.Text.Trim()}, {"@Email", email}, {"@Pass", password}
                };

                DatabaseHelper.ExecuteNonQuery(query, pars);
                MessageBox.Show($"Student added.\nEmail: {email}\nPassword: {password}");
                ClearStudentFields();
                RefreshStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding student: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_originalStudentRoll)) return;

            string query = "UPDATE Students SET RollNo=@NewRoll, Name=@Name, FatherName=@Father, Session=@Session, Program=@Prog WHERE RollNo=@OldRoll";
            var pars = new Dictionary<string, object> {
                {"@NewRoll", txtStudRoll.Text.Trim()}, {"@Name", txtStudName.Text.Trim()}, {"@Father", txtStudFather.Text.Trim()},
                {"@Session", txtStudSession.Text.Trim()}, {"@Prog", txtStudProgram.Text.Trim()}, {"@OldRoll", _originalStudentRoll}
            };

            DatabaseHelper.ExecuteNonQuery(query, pars);
            RefreshStudents();
            ClearStudentFields();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null) return;
            string roll = dgvStudents.CurrentRow.Cells["RollNo"].Value.ToString();

            if (MessageBox.Show("Delete student?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DatabaseHelper.ExecuteNonQuery("DELETE FROM Students WHERE RollNo=@Roll", new Dictionary<string, object> { { "@Roll", roll } });
                RefreshStudents();
            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvStudents.Rows[e.RowIndex];
            _originalStudentRoll = txtStudRoll.Text = row.Cells["RollNo"].Value.ToString();
            txtStudName.Text = row.Cells["Name"].Value.ToString();
            txtStudFather.Text = row.Cells["FatherName"].Value.ToString();
            txtStudSession.Text = row.Cells["Session"].Value.ToString();
            txtStudProgram.Text = row.Cells["Program"].Value.ToString();
        }

        private void ClearStudentFields()
        {
            txtStudRoll.Clear(); txtStudName.Clear(); txtStudFather.Clear(); txtStudSession.Clear(); txtStudProgram.Clear();
            _originalStudentRoll = null;
        }
        #endregion

        #region Advisor Management
        private void RefreshAdvisors()
        {
            dgvAdvisors.DataSource = DatabaseHelper.GetDataTable("SELECT * FROM Advisors");
        }

        private void btnAddAdvisor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdvID.Text) || string.IsNullOrWhiteSpace(txtAdvName.Text)) return;
            string id = txtAdvID.Text.Trim();
            try
            {
                var exists = DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM Advisors WHERE AdvisorID=@ID", new Dictionary<string, object> { { "@ID", id } });
                int cnt = Convert.ToInt32(exists ?? 0);
                if (cnt > 0)
                {
                    MessageBox.Show("An advisor with this ID already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string email = GenerateEmail(txtAdvName.Text, "advisor");
                string password = GeneratePassword();

                string query = "INSERT INTO Advisors (AdvisorID, Name, FatherName, FieldOfStudy, Designation, Department, Email, Password) VALUES (@ID, @Name, @Father, @Field, @Desig, @Dept, @Email, @Pass)";
                var pars = new Dictionary<string, object> {
                    {"@ID", id}, {"@Name", txtAdvName.Text.Trim()}, {"@Father", txtAdvFather.Text.Trim()},
                    {"@Field", txtAdvField.Text.Trim()}, {"@Desig", txtAdvDesignation.Text.Trim()}, {"@Dept", txtAdvDept.Text.Trim()},
                    {"@Email", email}, {"@Pass", password}
                };

                DatabaseHelper.ExecuteNonQuery(query, pars);
                MessageBox.Show($"Advisor added.\nEmail: {email}\nPassword: {password}");
                ClearAdvisorFields();
                RefreshAdvisors();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding advisor: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateAdvisor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_originalAdvisorId)) return;

            string query = "UPDATE Advisors SET AdvisorID=@NewID, Name=@Name, FatherName=@Father, FieldOfStudy=@Field, Designation=@Desig, Department=@Dept WHERE AdvisorID=@OldID";
            var pars = new Dictionary<string, object> {
                {"@NewID", txtAdvID.Text.Trim()}, {"@Name", txtAdvName.Text.Trim()}, {"@Father", txtAdvFather.Text.Trim()},
                {"@Field", txtAdvField.Text.Trim()}, {"@Desig", txtAdvDesignation.Text.Trim()}, {"@Dept", txtAdvDept.Text.Trim()},
                {"@OldID", _originalAdvisorId}
            };

            DatabaseHelper.ExecuteNonQuery(query, pars);
            RefreshAdvisors();
            ClearAdvisorFields();
        }

        private void btnDeleteAdvisor_Click(object sender, EventArgs e)
        {
            if (dgvAdvisors.CurrentRow == null) return;
            string id = dgvAdvisors.CurrentRow.Cells["AdvisorID"].Value.ToString();

            if (MessageBox.Show("Delete advisor?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DatabaseHelper.ExecuteNonQuery("DELETE FROM Advisors WHERE AdvisorID=@ID", new Dictionary<string, object> { { "@ID", id } });
                RefreshAdvisors();
            }
        }

        private void dgvAdvisors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvAdvisors.Rows[e.RowIndex];
            _originalAdvisorId = txtAdvID.Text = row.Cells["AdvisorID"].Value.ToString();
            txtAdvName.Text = row.Cells["Name"].Value.ToString();
            txtAdvFather.Text = row.Cells["FatherName"].Value.ToString();
            txtAdvField.Text = row.Cells["FieldOfStudy"].Value.ToString();
            txtAdvDesignation.Text = row.Cells["Designation"].Value.ToString();
            txtAdvDept.Text = row.Cells["Department"].Value.ToString();
        }

        private void ClearAdvisorFields()
        {
            txtAdvID.Clear(); txtAdvName.Clear(); txtAdvFather.Clear(); txtAdvField.Clear(); txtAdvDesignation.Clear(); txtAdvDept.Clear();
            _originalAdvisorId = null;
        }
        #endregion

        #region Group & Project Management
        private async Task RefreshGroupsData()
        {
            // Include assigned advisor name via LEFT JOIN so UI can show which advisor (if any) is assigned
            dgvGroups.DataSource = DatabaseHelper.GetDataTable("SELECT g.GroupID, adv.AdvisorID, adv.Name AS AdvisorName FROM Groups g LEFT JOIN Advisors adv ON g.AdvisorID = adv.AdvisorID");
            dgvUnassignedStudents.DataSource = DatabaseHelper.GetDataTable("SELECT RollNo, Name, Program FROM Students WHERE GroupID IS NULL");
        }

        private async void btnCreateGroup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGroupId.Text)) return;
            string gid = txtGroupId.Text.Trim();
            try
            {
                // Check existence first
                var existsObj = DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM Groups WHERE GroupID=@GID", new Dictionary<string, object> { { "@GID", gid } });
                int exists = Convert.ToInt32(existsObj ?? 0);
                if (exists > 0)
                {
                    MessageBox.Show("Group ID already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Ensure GroupName is provided to satisfy NOT NULL constraint in schema
                string gname = gid; // default GroupName same as ID; caller can update later

                string insertSql = "INSERT INTO Groups (GroupID, GroupName) VALUES (@GID, @GName)";
                DatabaseHelper.ExecuteNonQuery(insertSql, new Dictionary<string, object> { { "@GID", gid }, { "@GName", gname } });
                txtGroupId.Clear();
                await RefreshGroupsData();
                MessageBox.Show("Group created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating group: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRemoveGroup_Click(object sender, EventArgs e)
        {
            if (dgvGroups.CurrentRow == null) return;
            string gid = dgvGroups.CurrentRow.Cells["GroupID"].Value.ToString();
            if (MessageBox.Show($"Remove group {gid}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Simple version: rely on DB cascades or do it manually if needed. 
                // Based on provided SQL, some are SET NULL, some CASCADE.
                DatabaseHelper.ExecuteNonQuery("DELETE FROM Groups WHERE GroupID=@GID", new Dictionary<string, object> { { "@GID", gid } });
                await RefreshGroupsData();
            }
        }

        private async void btnAssignStudentToGroup_Click(object sender, EventArgs e)
        {
            if (dgvGroups.CurrentRow == null || dgvUnassignedStudents.CurrentRow == null) return;
            string gid = dgvGroups.CurrentRow.Cells["GroupID"].Value.ToString();
            string roll = dgvUnassignedStudents.CurrentRow.Cells["RollNo"].Value.ToString();

            DatabaseHelper.ExecuteNonQuery("UPDATE Students SET GroupID=@GID WHERE RollNo=@Roll", new Dictionary<string, object> { { "@GID", gid }, { "@Roll", roll } });
            await RefreshGroupsData();
        }

        private void btnAssignProject_Click(object sender, EventArgs e)
        {
            if (cbSelectGroup.SelectedValue == null || string.IsNullOrWhiteSpace(txtProjectTitle.Text)) return;

            string gid = cbSelectGroup.SelectedValue.ToString();

            // Check if a project already exists for this group
            var existsObj = DatabaseHelper.ExecuteScalar("SELECT COUNT(1) FROM Projects WHERE GroupID=@GID", new Dictionary<string, object> { { "@GID", gid } });
            int exists = Convert.ToInt32(existsObj ?? 0);
            if (exists > 0)
            {
                var res = MessageBox.Show("Selected group already has a project assigned. Assigning another will create multiple projects for the same group. Continue?", "Confirm Multiple Projects", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res != DialogResult.Yes)
                    return;
            }

            string query = "INSERT INTO Projects (GroupID, Title, Description, Deadline) VALUES (@GID, @Title, @Desc, @Dl)";
            var pars = new Dictionary<string, object> {
                {"@GID", gid}, {"@Title", txtProjectTitle.Text.Trim()},
                {"@Desc", txtProjectDesc.Text.Trim()}, {"@Dl", dtpDeadline.Value}
            };

            DatabaseHelper.ExecuteNonQuery(query, pars);
            MessageBox.Show("Project assigned.");
            txtProjectTitle.Clear(); txtProjectDesc.Clear();
        }

        private void btnAssignAdvisorToGroup_Click(object sender, EventArgs e)
        {
            if (cbAdvGroupSelect.SelectedValue == null || cbAdvisorSelect.SelectedValue == null) return;
            string gid = cbAdvGroupSelect.SelectedValue.ToString();
            string aid = cbAdvisorSelect.SelectedValue.ToString();
            try
            {
                var cur = DatabaseHelper.ExecuteScalar("SELECT AdvisorID FROM Groups WHERE GroupID=@GID", new Dictionary<string, object> { { "@GID", gid } });
                string currentAdvisor = cur == null || cur == DBNull.Value ? null : cur.ToString();

                if (!string.IsNullOrEmpty(currentAdvisor) && currentAdvisor == aid)
                {
                    MessageBox.Show("This advisor is already assigned to the selected group.", "No Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!string.IsNullOrEmpty(currentAdvisor) && currentAdvisor != aid)
                {
                    // Ask before replacing an existing advisor
                    var existingName = DatabaseHelper.ExecuteScalar("SELECT Name FROM Advisors WHERE AdvisorID=@ID", new Dictionary<string, object> { { "@ID", currentAdvisor } });
                    string existingDisplay = existingName == null ? currentAdvisor : existingName.ToString();
                    var res = MessageBox.Show($"Selected group already has advisor '{existingDisplay}'. Replace with the new advisor?", "Confirm Replace", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res != DialogResult.Yes) return;
                }

                DatabaseHelper.ExecuteNonQuery("UPDATE Groups SET AdvisorID=@AID WHERE GroupID=@GID",
                    new Dictionary<string, object> { { "@GID", gid }, { "@AID", aid } });
                MessageBox.Show("Advisor assigned to group.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ = RefreshGroupsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error assigning advisor: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task InitializeDropdowns()
        {
            // Use groups with GroupID (and optional advisor info) so dropdowns still bind correctly
            DataTable groups = DatabaseHelper.GetDataTable("SELECT GroupID FROM Groups");
            cbSelectGroup.DataSource = groups;
            cbSelectGroup.DisplayMember = "GroupID";
            cbSelectGroup.ValueMember = "GroupID";

            cbAdvGroupSelect.DataSource = groups.Copy();
            cbAdvGroupSelect.DisplayMember = "GroupID";
            cbAdvGroupSelect.ValueMember = "GroupID";

            cbAdvisorSelect.DataSource = DatabaseHelper.GetDataTable("SELECT AdvisorID, Name FROM Advisors");
            cbAdvisorSelect.DisplayMember = "Name";
            cbAdvisorSelect.ValueMember = "AdvisorID";
        }
        #endregion

        #region Helpers
        private string GenerateEmail(string name, string role) => $"{name.Replace(" ", ".").ToLower()}{_random.Next(100, 999)}@{role}.hub.com";
        private string GeneratePassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var sb = new StringBuilder();
            for (int i = 0; i < 8; i++) sb.Append(chars[_random.Next(chars.Length)]);
            return sb.ToString();
        }
        #endregion
    }
}
