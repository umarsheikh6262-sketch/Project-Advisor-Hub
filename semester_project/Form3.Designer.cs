using System.Drawing;
using System.Windows.Forms;

namespace semester_project
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;

        // Sidebar Navigation Controls
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnManageStudents;
        private System.Windows.Forms.Button btnManageAdvisors;
        private System.Windows.Forms.Button btnManageGroups;
        private System.Windows.Forms.Button btnAssignProjects;
        private System.Windows.Forms.Button btnAssignAdvisors;
        private System.Windows.Forms.Button btnLogout;

        // Main Tab Container
        private System.Windows.Forms.TabControl tabControlDashboard;

        // Tab Pages
        private System.Windows.Forms.TabPage tabHome;
        private System.Windows.Forms.TabPage tabStudents;
        private System.Windows.Forms.TabPage tabAdvisors;
        private System.Windows.Forms.TabPage tabGroups;
        private System.Windows.Forms.TabPage tabProjects;
        private System.Windows.Forms.TabPage tabAssignAdvisors;

        // Tab 1: Home Stats Controls
        private System.Windows.Forms.Panel pnlStatStudents;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.Label lblStatTitle1;
        private System.Windows.Forms.Panel pnlStatAdvisors;
        private System.Windows.Forms.Label lblTotalAdvisors;
        private System.Windows.Forms.Label lblStatTitle2;
        private System.Windows.Forms.Panel pnlStatProjects;
        private System.Windows.Forms.Label lblTotalProjects;
        private System.Windows.Forms.Label lblStatTitle3;
        private System.Windows.Forms.Panel pnlStatGroups;
        private System.Windows.Forms.Label lblTotalGroups;
        private System.Windows.Forms.Label lblStatTitle4;

        // Tab 2: Manage Students Controls
        private System.Windows.Forms.TextBox txtStudName;
        private System.Windows.Forms.TextBox txtStudFather;
        private System.Windows.Forms.TextBox txtStudRoll;
        private System.Windows.Forms.TextBox txtStudSession;
        private System.Windows.Forms.TextBox txtStudProgram;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnUpdateStudent;
        private System.Windows.Forms.Button btnDeleteStudent;
        private System.Windows.Forms.DataGridView dgvStudents;

        // Tab 3: Manage Advisors Controls
        private System.Windows.Forms.TextBox txtAdvName;
        private System.Windows.Forms.TextBox txtAdvFather;
        private System.Windows.Forms.TextBox txtAdvID;
        private System.Windows.Forms.TextBox txtAdvField;
        private System.Windows.Forms.TextBox txtAdvDesignation;
        private System.Windows.Forms.TextBox txtAdvDept;
        private System.Windows.Forms.Button btnAddAdvisor;
        private System.Windows.Forms.Button btnUpdateAdvisor;
        private System.Windows.Forms.Button btnDeleteAdvisor;
        private System.Windows.Forms.DataGridView dgvAdvisors;

        // Tab 4: Manage Groups Controls
        private System.Windows.Forms.TextBox txtGroupId;
        private System.Windows.Forms.Button btnCreateGroup;
        private System.Windows.Forms.Button btnRemoveGroup;
        private System.Windows.Forms.DataGridView dgvGroups;
        private System.Windows.Forms.DataGridView dgvUnassignedStudents;
        private System.Windows.Forms.Button btnAssignStudentToGroup;

        // Tab 5: Assign Projects Controls
        private System.Windows.Forms.ComboBox cbSelectGroup;
        private System.Windows.Forms.TextBox txtProjectTitle;
        private System.Windows.Forms.TextBox txtProjectDesc;
        private System.Windows.Forms.DateTimePicker dtpDeadline;
        private System.Windows.Forms.Button btnAssignProject;
        private System.Windows.Forms.Label lblScopeGuidanceText;

        // Tab 6: Assign Advisors Controls
        private System.Windows.Forms.ComboBox cbAdvGroupSelect;
        private System.Windows.Forms.ComboBox cbAdvisorSelect;
        private System.Windows.Forms.Button btnAssignAdvisorToGroup;

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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnManageStudents = new System.Windows.Forms.Button();
            this.btnManageAdvisors = new System.Windows.Forms.Button();
            this.btnManageGroups = new System.Windows.Forms.Button();
            this.btnAssignProjects = new System.Windows.Forms.Button();
            this.btnAssignAdvisors = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tabControlDashboard = new System.Windows.Forms.TabControl();

            this.tabHome = new System.Windows.Forms.TabPage();
            this.tabStudents = new System.Windows.Forms.TabPage();
            this.tabAdvisors = new System.Windows.Forms.TabPage();
            this.tabGroups = new System.Windows.Forms.TabPage();
            this.tabProjects = new System.Windows.Forms.TabPage();
            this.tabAssignAdvisors = new System.Windows.Forms.TabPage();

            this.pnlSidebar.SuspendLayout();
            this.tabControlDashboard.SuspendLayout();
            this.tabHome.SuspendLayout();
            this.tabStudents.SuspendLayout();
            this.tabAdvisors.SuspendLayout();
            this.tabGroups.SuspendLayout();
            this.tabProjects.SuspendLayout();
            this.tabAssignAdvisors.SuspendLayout();
            this.SuspendLayout();

            // 
            // Form Architecture Configurations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Text = "Project Advisor Hub - Admin Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // 
            // Left Navigation Sidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            // add only the logo here; navigation buttons are created programmatically below
            this.pnlSidebar.Controls.Add(this.lblLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Size = new System.Drawing.Size(240, 650);

            // Logo
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(14, 12);
            this.lblLogo.Size = new System.Drawing.Size(212, 36);
            this.lblLogo.BorderStyle = BorderStyle.None;
            this.lblLogo.Text = "Project Advisor Hub";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Set up common styles for navigation items sidebar buttons
            Button[] navButtons = { btnHome, btnManageStudents, btnManageAdvisors, btnManageGroups, btnAssignProjects, btnAssignAdvisors, btnLogout };
            string[] navTexts = { "Dashboard Home", "Manage Students", "Manage Advisors", "Manage Groups", "Assign Projects", "Assign Advisors", "Logout" };
            int startY = 90;

            for (int i = 0; i < navButtons.Length; i++)
            {
                // Create the visible button and also assign it back to the corresponding field
                Button btn = new Button();
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Font = new System.Drawing.Font("Segoe UI", 10F);
                btn.ForeColor = System.Drawing.Color.Gainsboro;
                btn.Size = new System.Drawing.Size(220, 45);
                btn.Text = "  " + navTexts[i];
                btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

                if (i == navButtons.Length - 1) // Anchor Logout to the bottom
                {
                    btn.Location = new System.Drawing.Point(10, 580);
                    btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                    btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
                    btn.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    btn.Location = new System.Drawing.Point(10, startY + (i * 52));
                }

                // assign to both array and the declared field so event wiring references the visible control
                navButtons[i] = btn;
                switch (i)
                {
                    case 0: btnHome = btn; break;
                    case 1: btnManageStudents = btn; break;
                    case 2: btnManageAdvisors = btn; break;
                    case 3: btnManageGroups = btn; break;
                    case 4: btnAssignProjects = btn; break;
                    case 5: btnAssignAdvisors = btn; break;
                    case 6: btnLogout = btn; break;
                }

                this.pnlSidebar.Controls.Add(navButtons[i]);
            }

            // Bind Navigation Events
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            this.btnManageStudents.Click += new System.EventHandler(this.btnManageStudents_Click);
            this.btnManageAdvisors.Click += new System.EventHandler(this.btnManageAdvisors_Click);
            this.btnManageGroups.Click += new System.EventHandler(this.btnManageGroups_Click);
            this.btnAssignProjects.Click += new System.EventHandler(this.btnAssignProjects_Click);
            this.btnAssignAdvisors.Click += new System.EventHandler(this.btnAssignAdvisors_Click);
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // 
            // Main Central Display (TabControl Window)
            // 
            this.tabControlDashboard.Controls.Add(this.tabHome);
            this.tabControlDashboard.Controls.Add(this.tabStudents);
            this.tabControlDashboard.Controls.Add(this.tabAdvisors);
            this.tabControlDashboard.Controls.Add(this.tabGroups);
            this.tabControlDashboard.Controls.Add(this.tabProjects);
            this.tabControlDashboard.Controls.Add(this.tabAssignAdvisors);
            this.tabControlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDashboard.Location = new System.Drawing.Point(240, 0);
            this.tabControlDashboard.Size = new System.Drawing.Size(860, 650);

            // Styling colors across layouts - subtle warm theme
            Color contentBg = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            foreach (TabPage tab in new TabPage[] { tabHome, tabStudents, tabAdvisors, tabGroups, tabProjects, tabAssignAdvisors })
            {
                tab.BackColor = contentBg;
            }

            // Global form accent and font
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            // make sidebar padding clear and avoid stray focus rectangles
            this.pnlSidebar.Padding = new Padding(8, 8, 8, 8);

            // ==========================================
            // TAB 1: HOME PANEL (Metrics View)
            // ==========================================
            InitializeHomeTab();

            // ==========================================
            // TAB 2: MANAGE STUDENTS PANEL
            // ==========================================
            InitializeStudentsTab();

            // ==========================================
            // TAB 3: MANAGE ADVISORS PANEL
            // ==========================================
            InitializeAdvisorsTab();

            // ==========================================
            // TAB 4: MANAGE GROUPS PANEL
            // ==========================================
            InitializeGroupsTab();

            // ==========================================
            // TAB 5: ASSIGN PROJECTS PANEL
            // ==========================================
            InitializeProjectsTab();

            // ==========================================
            // TAB 6: LINKING ADVISORS PANEL
            // ==========================================
            InitializeAssignAdvisorsTab();

            // Assemble everything
            this.Controls.Add(this.tabControlDashboard);
            this.Controls.Add(this.pnlSidebar);
            this.pnlSidebar.ResumeLayout(false);
            this.tabControlDashboard.ResumeLayout(false);
            this.tabHome.ResumeLayout(false);
            this.tabStudents.ResumeLayout(false);
            this.tabAdvisors.ResumeLayout(false);
            this.tabGroups.ResumeLayout(false);
            this.tabProjects.ResumeLayout(false);
            this.tabAssignAdvisors.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #region Programmatic Layout Component Builders

        private void InitializeHomeTab()
        {
            Label lblTitle = CreateHeaderLabel("System Metrics Summary", 30, 30);
            this.tabHome.Controls.Add(lblTitle);

            pnlStatStudents = CreateStatCard("Total Registered Students", "0", 40, 100, System.Drawing.Color.FromArgb(52, 152, 219), out lblTotalStudents, out lblStatTitle1);
            pnlStatAdvisors = CreateStatCard("Total Active Advisors", "0", 300, 100, System.Drawing.Color.FromArgb(46, 204, 113), out lblTotalAdvisors, out lblStatTitle2);
            pnlStatProjects = CreateStatCard("Allocated Projects", "0", 40, 240, System.Drawing.Color.FromArgb(155, 89, 182), out lblTotalProjects, out lblStatTitle3);
            pnlStatGroups = CreateStatCard("Formed Student Groups", "0", 300, 240, System.Drawing.Color.FromArgb(230, 126, 34), out lblTotalGroups, out lblStatTitle4);

            this.tabHome.Controls.AddRange(new Control[] { pnlStatStudents, pnlStatAdvisors, pnlStatProjects, pnlStatGroups });
        }

        private void InitializeStudentsTab()
        {
            this.tabStudents.Controls.Clear();
            this.tabStudents.Controls.Add(CreateHeaderLabel("Manage Student Registrations Directory", 25, 20));

            int formX = 25, startY = 85, spacingY = 55;
            txtStudName = CreateLabeledTextBox(tabStudents, "Student Full Name:", formX, startY);
            txtStudFather = CreateLabeledTextBox(tabStudents, "Father's Name:", formX, startY + spacingY);
            txtStudRoll = CreateLabeledTextBox(tabStudents, "Academic Roll Number:", formX, startY + (spacingY * 2));
            txtStudSession = CreateLabeledTextBox(tabStudents, "Session Frame (e.g., 2022-2026):", formX, startY + (spacingY * 3));
            txtStudProgram = CreateLabeledTextBox(tabStudents, "Degree Program Discipline:", formX, startY + (spacingY * 4));

            int btnX = formX; int btnWidth = 220; int btnYBase = startY + (spacingY * 5) + 10; int btnGap = 45;
            btnAddStudent = new Button { Text = "Register New Student", Location = new System.Drawing.Point(btnX, btnYBase), Size = new System.Drawing.Size(btnWidth, 36), BackColor = System.Drawing.Color.FromArgb(46, 204, 113), ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold), FlatStyle = FlatStyle.Flat };
            btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);

            btnUpdateStudent = new Button { Text = "Update Selected", Location = new System.Drawing.Point(btnX, btnYBase + btnGap), Size = new System.Drawing.Size(btnWidth, 36), BackColor = System.Drawing.Color.FromArgb(41, 128, 185), ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold), FlatStyle = FlatStyle.Flat };
            btnUpdateStudent.Click += new System.EventHandler(this.btnUpdateStudent_Click);

            btnDeleteStudent = new Button { Text = "Drop Highlighted", Location = new System.Drawing.Point(btnX, btnYBase + (btnGap * 2)), Size = new System.Drawing.Size(btnWidth, 36), BackColor = System.Drawing.Color.FromArgb(192, 57, 43), ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold), FlatStyle = FlatStyle.Flat };
            btnDeleteStudent.Click += new System.EventHandler(this.btnDeleteStudent_Click);

            this.tabStudents.Controls.AddRange(new Control[] { btnAddStudent, btnUpdateStudent, btnDeleteStudent });

            // Wide display bounds expanded to perfectly match extra field profiles (e.g., Passwords)
            dgvStudents = CreateCentralGrid(300, 85, 540, 485);
            dgvStudents.CellClick += new DataGridViewCellEventHandler(this.dgvStudents_CellClick); // wire up selection click
            this.tabStudents.Controls.Add(dgvStudents);
        }

        private void InitializeAdvisorsTab()
        {
            this.tabAdvisors.Controls.Clear();
            this.tabAdvisors.Controls.Add(CreateHeaderLabel("Manage Faculty Advisors Directory", 25, 20));

            int formX = 25, startY = 85, spacingY = 55;
            txtAdvName = CreateLabeledTextBox(tabAdvisors, "Advisor Faculty Name:", formX, startY);
            txtAdvFather = CreateLabeledTextBox(tabAdvisors, "Father's Name:", formX, startY + spacingY);
            txtAdvID = CreateLabeledTextBox(tabAdvisors, "Employee / Advisor ID:", formX, startY + (spacingY * 2));
            txtAdvField = CreateLabeledTextBox(tabAdvisors, "Specialized Field of Study:", formX, startY + (spacingY * 3));
            txtAdvDesignation = CreateLabeledTextBox(tabAdvisors, "Designation Role:", formX, startY + (spacingY * 4));
            txtAdvDept = CreateLabeledTextBox(tabAdvisors, "Department Branch:", formX, startY + (spacingY * 5));

            int adbX = formX; int adbWidth = 220; int adbYBase = startY + (spacingY * 6); int adbGap = 45;
            btnAddAdvisor = new Button { Text = "Register Advisor", Location = new System.Drawing.Point(adbX, adbYBase), Size = new System.Drawing.Size(adbWidth, 36), BackColor = System.Drawing.Color.FromArgb(46, 204, 113), ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold), FlatStyle = FlatStyle.Flat };
            btnAddAdvisor.Click += new System.EventHandler(this.btnAddAdvisor_Click);

            btnUpdateAdvisor = new Button { Text = "Update Selected", Location = new System.Drawing.Point(adbX, adbYBase + adbGap), Size = new System.Drawing.Size(adbWidth, 36), BackColor = System.Drawing.Color.FromArgb(41, 128, 185), ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold), FlatStyle = FlatStyle.Flat };
            btnUpdateAdvisor.Click += new System.EventHandler(this.btnUpdateAdvisor_Click);

            btnDeleteAdvisor = new Button { Text = "Remove Selected", Location = new System.Drawing.Point(adbX, adbYBase + (adbGap * 2)), Size = new System.Drawing.Size(adbWidth, 36), BackColor = System.Drawing.Color.FromArgb(192, 57, 43), ForeColor = System.Drawing.Color.White, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold), FlatStyle = FlatStyle.Flat };
            btnDeleteAdvisor.Click += new System.EventHandler(this.btnDeleteAdvisor_Click);

            this.tabAdvisors.Controls.AddRange(new Control[] { btnAddAdvisor, btnUpdateAdvisor, btnDeleteAdvisor });

            dgvAdvisors = CreateCentralGrid(300, 85, 540, 485);
            dgvAdvisors.CellClick += new DataGridViewCellEventHandler(this.dgvAdvisors_CellClick); // wire up selection click
            this.tabAdvisors.Controls.Add(dgvAdvisors);
        }

        private void InitializeGroupsTab()
        {
            // 1. Reset layout states
            this.tabGroups.Controls.Clear();

            // 2. Tab Section Title Header
            this.tabGroups.Controls.Add(CreateHeaderLabel("Form Student Groups Desk", 25, 20));

            // 3. Top Section: Group Registration Container
            txtGroupId = CreateLabeledTextBox(tabGroups, "Create Unique Group ID String:", 25, 75);

            btnCreateGroup = new Button
            {
                Text = "Establish Group",
                Location = new System.Drawing.Point(240, 93),
                Size = new System.Drawing.Size(150, 30),
                BackColor = System.Drawing.Color.FromArgb(52, 152, 219),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
            this.tabGroups.Controls.Add(btnCreateGroup);

            btnRemoveGroup = new Button
            {
                Text = "Remove Selected Group",
                Location = new System.Drawing.Point(400, 93),
                Size = new System.Drawing.Size(180, 30),
                BackColor = System.Drawing.Color.FromArgb(192, 57, 43),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnRemoveGroup.Click += new System.EventHandler(this.btnRemoveGroup_Click);
            this.tabGroups.Controls.Add(btnRemoveGroup);

            // 4. Section Title Sub-headers
            Label lblGroupsTitle = new Label { Text = "1. Select Established Group:", Location = new System.Drawing.Point(25, 145), Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(44, 62, 80), AutoSize = true };
            Label lblStudentsTitle = new Label { Text = "2. Select Unassigned Student:", Location = new System.Drawing.Point(430, 145), Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(44, 62, 80), AutoSize = true };
            this.tabGroups.Controls.AddRange(new Control[] { lblGroupsTitle, lblStudentsTitle });

            // 5. Left Grid View: Groups List (Built manually to guarantee boundaries)
            dgvGroups = new DataGridView();
            dgvGroups.Location = new System.Drawing.Point(25, 175);
            dgvGroups.Size = new System.Drawing.Size(380, 330);
            dgvGroups.AllowUserToAddRows = false;
            dgvGroups.ReadOnly = true;
            dgvGroups.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGroups.MultiSelect = false;
            dgvGroups.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGroups.BackgroundColor = System.Drawing.Color.White;
            dgvGroups.BorderStyle = BorderStyle.FixedSingle;
            dgvGroups.Dock = DockStyle.None; // Stops auto-stretching
            dgvGroups.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.tabGroups.Controls.Add(dgvGroups);

            // 6. Right Grid View: Unassigned Students List (Built manually to guarantee boundaries)
            dgvUnassignedStudents = new DataGridView();
            dgvUnassignedStudents.Location = new System.Drawing.Point(430, 175);
            dgvUnassignedStudents.Size = new System.Drawing.Size(400, 330);
            dgvUnassignedStudents.AllowUserToAddRows = false;
            dgvUnassignedStudents.ReadOnly = true;
            dgvUnassignedStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUnassignedStudents.MultiSelect = false;
            dgvUnassignedStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUnassignedStudents.BackgroundColor = System.Drawing.Color.White;
            dgvUnassignedStudents.BorderStyle = BorderStyle.FixedSingle;
            dgvUnassignedStudents.Dock = DockStyle.None; // Stops auto-stretching
            dgvUnassignedStudents.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.tabGroups.Controls.Add(dgvUnassignedStudents);

            // 7. Action Control Linkage Button
            btnAssignStudentToGroup = new Button
            {
                Text = "Link Selected Student To Group ➔",
                Location = new System.Drawing.Point(25, 525),
                Size = new System.Drawing.Size(805, 45),
                BackColor = System.Drawing.Color.FromArgb(46, 204, 113),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            btnAssignStudentToGroup.Click += new System.EventHandler(this.btnAssignStudentToGroup_Click);
            this.tabGroups.Controls.Add(btnAssignStudentToGroup);
        }

        private void InitializeProjectsTab()
        {
            this.tabProjects.Controls.Add(CreateHeaderLabel("Project Assignment Desk", 25, 20));
            int formX = 25, startY = 80;

            CreateFieldLabel(tabProjects, "Select Target Student Group ID:", formX, startY);
            cbSelectGroup = new ComboBox { Location = new System.Drawing.Point(formX, startY + 22), Size = new System.Drawing.Size(360, 28), DropDownStyle = ComboBoxStyle.DropDownList };

            txtProjectTitle = CreateLabeledTextBox(tabProjects, "Project Structural Title:", formX, startY + 60);
            txtProjectTitle.Width = 420;
            txtProjectDesc = CreateLabeledTextBox(tabProjects, "Project Scope Statement Description:", formX, startY + 110, true);
            txtProjectDesc.Multiline = true;
            txtProjectDesc.Size = new System.Drawing.Size(520, 140);

            lblScopeGuidanceText = new Label { Text = "Provide a concise objective and key deliverables.", Location = new System.Drawing.Point(formX, startY + 260), Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic), ForeColor = System.Drawing.Color.DimGray, AutoSize = true };
            this.tabProjects.Controls.Add(lblScopeGuidanceText);

            CreateFieldLabel(tabProjects, "Target Delivery Submission Deadline:", formX, startY + 285);
            dtpDeadline = new DateTimePicker { Location = new System.Drawing.Point(formX, startY + 310), Size = new System.Drawing.Size(360, 28) };

            btnAssignProject = new Button { Text = "Allocate Project Specification", Location = new System.Drawing.Point(formX, startY + 360), Size = new System.Drawing.Size(360, 40), BackColor = System.Drawing.Color.FromArgb(142, 68, 173), ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnAssignProject.Click += new System.EventHandler(this.btnAssignProject_Click);

            this.tabProjects.Controls.AddRange(new Control[] { cbSelectGroup, dtpDeadline, btnAssignProject });
        }

        private void InitializeAssignAdvisorsTab()
        {
            this.tabAssignAdvisors.Controls.Add(CreateHeaderLabel("Link Project Supervisors to Groups", 25, 20));
            int formX = 25, startY = 80;

            CreateFieldLabel(tabAssignAdvisors, "Select Target Student Group Node:", formX, startY);
            cbAdvGroupSelect = new ComboBox { Location = new System.Drawing.Point(formX, startY + 20), Size = new System.Drawing.Size(350, 28), DropDownStyle = ComboBoxStyle.DropDownList };

            CreateFieldLabel(tabAssignAdvisors, "Select Faculty Advisor to Link:", formX, startY + 70);
            cbAdvisorSelect = new ComboBox { Location = new System.Drawing.Point(formX, startY + 90), Size = new System.Drawing.Size(350, 28), DropDownStyle = ComboBoxStyle.DropDownList };

            btnAssignAdvisorToGroup = new Button { Text = "Attach Advisor Dependency Link", Location = new System.Drawing.Point(formX, startY + 150), Size = new System.Drawing.Size(350, 40), BackColor = System.Drawing.Color.FromArgb(41, 128, 185), ForeColor = System.Drawing.Color.White, FlatStyle = FlatStyle.Flat };
            btnAssignAdvisorToGroup.Click += new System.EventHandler(this.btnAssignAdvisorToGroup_Click);

            this.tabAssignAdvisors.Controls.AddRange(new Control[] { cbAdvGroupSelect, cbAdvisorSelect, btnAssignAdvisorToGroup });
        }

        #endregion

        #region UI Component Assembly Helper Layout Primitives

        private Label CreateHeaderLabel(string text, int x, int y)
        {
            return new Label
            {
                Text = text,
                Location = new System.Drawing.Point(x, y),
                Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(34, 49, 63),
                AutoSize = true
            };
        }

        private void CreateFieldLabel(Control container, string title, int x, int y)
        {
            Label lbl = new Label { Text = title, Location = new System.Drawing.Point(x, y), Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular), ForeColor = System.Drawing.Color.DarkSlateGray, AutoSize = true };
            container.Controls.Add(lbl);
        }

        private TextBox CreateLabeledTextBox(Control parent, string labelTitle, int x, int y, bool multiLine = false)
        {
            CreateFieldLabel(parent, labelTitle, x, y);
            TextBox box = new TextBox { Location = new System.Drawing.Point(x, y + 20), Size = new System.Drawing.Size(200, 26), Font = new System.Drawing.Font("Segoe UI", 10F), Multiline = multiLine };
            parent.Controls.Add(box);
            return box;
        }

        private DataGridView CreateCentralGrid(int x, int y, int width, int height)
        {
            DataGridView dgv = new DataGridView();
            dgv.Location = new System.Drawing.Point(x, y);
            dgv.Size = new System.Drawing.Size(width, height);
            dgv.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            dgv.BackgroundColor = System.Drawing.Color.White;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            // Let the polishing engine handle column widths; disable automatic fill to allow horizontal scrolling
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.ScrollBars = ScrollBars.Both;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            return dgv;
        }

        private Panel CreateStatCard(string header, string value, int x, int y, Color theme, out Label lblVal, out Label lblHead)
        {
            Panel card = new Panel { Size = new System.Drawing.Size(230, 110), Location = new System.Drawing.Point(x, y), BackColor = System.Drawing.Color.White, BorderStyle = BorderStyle.None };

            Panel strip = new Panel { Size = new System.Drawing.Size(8, 110), Dock = DockStyle.Left, BackColor = theme };
            card.Controls.Add(strip);

            lblVal = new Label { Text = value, Location = new System.Drawing.Point(20, 15), Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(44, 62, 80), AutoSize = true };
            lblHead = new Label { Text = header, Location = new System.Drawing.Point(22, 70), Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular), ForeColor = System.Drawing.Color.Gray, AutoSize = true };

            card.Controls.AddRange(new Control[] { lblVal, lblHead });
            return card;
        }

        #endregion
    }
}