namespace semester_project
{
    partial class Form5
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnIncreaseDeadline = new System.Windows.Forms.Button();
            this.btnUpdateProject = new System.Windows.Forms.Button();
            this.btnUncompleted = new System.Windows.Forms.Button();
            this.btnEvaluationPending = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.lblPortalTitle = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlHome = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.card1 = new System.Windows.Forms.Panel();
            this.lblCardTotalProjectsCount = new System.Windows.Forms.Label();
            this.lblCardTotalProjectsTitle = new System.Windows.Forms.Label();
            this.strip1 = new System.Windows.Forms.Panel();
            this.card2 = new System.Windows.Forms.Panel();
            this.lblCardPendingCount = new System.Windows.Forms.Label();
            this.lblCardPendingTitle = new System.Windows.Forms.Label();
            this.strip2 = new System.Windows.Forms.Panel();
            this.card3 = new System.Windows.Forms.Panel();
            this.lblCardCompletedCount = new System.Windows.Forms.Label();
            this.lblCardCompletedTitle = new System.Windows.Forms.Label();
            this.strip3 = new System.Windows.Forms.Panel();
            this.card4 = new System.Windows.Forms.Panel();
            this.lblCardUncompletedCount = new System.Windows.Forms.Label();
            this.lblCardUncompletedTitle = new System.Windows.Forms.Label();
            this.strip4 = new System.Windows.Forms.Panel();
            this.pnlEvaluation = new System.Windows.Forms.Panel();
            this.lblEvalTitle = new System.Windows.Forms.Label();
            this.lblEvalSubtitle = new System.Windows.Forms.Label();
            this.pnlEvalCard = new System.Windows.Forms.Panel();
            this.pnlSearchContainer = new System.Windows.Forms.Panel();
            this.txtSearchEval = new System.Windows.Forms.TextBox();
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.dgvEvaluationPending = new System.Windows.Forms.DataGridView();
            this.pnlUncompleted = new System.Windows.Forms.Panel();
            this.dgvUncompleted = new System.Windows.Forms.DataGridView();
            this.pnlUpdate = new System.Windows.Forms.Panel();
            this.dgvUpdateProjects = new System.Windows.Forms.DataGridView();
            this.pnlIncreaseDeadline = new System.Windows.Forms.Panel();
            this.lblCurrentDeadline = new System.Windows.Forms.Label();
            this.btnUpdateDeadline = new System.Windows.Forms.Button();
            this.dtpNewDeadline = new System.Windows.Forms.DateTimePicker();
            this.dgvDeadlines = new System.Windows.Forms.DataGridView();
            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlHome.SuspendLayout();
            this.card1.SuspendLayout();
            this.card2.SuspendLayout();
            this.card3.SuspendLayout();
            this.card4.SuspendLayout();
            this.pnlEvaluation.SuspendLayout();
            this.pnlEvalCard.SuspendLayout();
            this.pnlSearchContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvaluationPending)).BeginInit();
            this.pnlUncompleted.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUncompleted)).BeginInit();
            this.pnlUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateProjects)).BeginInit();
            this.pnlIncreaseDeadline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeadlines)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(40)))), ((int)(((byte)(85)))));
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.btnIncreaseDeadline);
            this.pnlSidebar.Controls.Add(this.btnUpdateProject);
            this.pnlSidebar.Controls.Add(this.btnUncompleted);
            this.pnlSidebar.Controls.Add(this.btnEvaluationPending);
            this.pnlSidebar.Controls.Add(this.btnHome);
            this.pnlSidebar.Controls.Add(this.lblPortalTitle);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(250, 700);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(15, 640);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(220, 40);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnIncreaseDeadline
            // 
            this.btnIncreaseDeadline.BackColor = System.Drawing.Color.Transparent;
            this.btnIncreaseDeadline.FlatAppearance.BorderSize = 0;
            this.btnIncreaseDeadline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncreaseDeadline.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnIncreaseDeadline.ForeColor = System.Drawing.Color.White;
            this.btnIncreaseDeadline.Location = new System.Drawing.Point(10, 330);
            this.btnIncreaseDeadline.Name = "btnIncreaseDeadline";
            this.btnIncreaseDeadline.Size = new System.Drawing.Size(230, 42);
            this.btnIncreaseDeadline.TabIndex = 5;
            this.btnIncreaseDeadline.Text = "  ⏱  Increase Project Deadline";
            this.btnIncreaseDeadline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIncreaseDeadline.UseVisualStyleBackColor = false;
            this.btnIncreaseDeadline.Click += new System.EventHandler(this.btnIncreaseDeadline_Click);
            // 
            // btnUpdateProject
            // 
            this.btnUpdateProject.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdateProject.FlatAppearance.BorderSize = 0;
            this.btnUpdateProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateProject.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnUpdateProject.ForeColor = System.Drawing.Color.White;
            this.btnUpdateProject.Location = new System.Drawing.Point(10, 270);
            this.btnUpdateProject.Name = "btnUpdateProject";
            this.btnUpdateProject.Size = new System.Drawing.Size(230, 42);
            this.btnUpdateProject.TabIndex = 4;
            this.btnUpdateProject.Text = "  ✏️  Update Project";
            this.btnUpdateProject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateProject.UseVisualStyleBackColor = false;
            this.btnUpdateProject.Click += new System.EventHandler(this.btnUpdateProject_Click);
            // 
            // btnUncompleted
            // 
            this.btnUncompleted.BackColor = System.Drawing.Color.Transparent;
            this.btnUncompleted.FlatAppearance.BorderSize = 0;
            this.btnUncompleted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUncompleted.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnUncompleted.ForeColor = System.Drawing.Color.White;
            this.btnUncompleted.Location = new System.Drawing.Point(10, 210);
            this.btnUncompleted.Name = "btnUncompleted";
            this.btnUncompleted.Size = new System.Drawing.Size(230, 42);
            this.btnUncompleted.TabIndex = 3;
            this.btnUncompleted.Text = "  ⚠️  Uncompleted Projects";
            this.btnUncompleted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUncompleted.UseVisualStyleBackColor = false;
            this.btnUncompleted.Click += new System.EventHandler(this.btnUncompleted_Click);
            // 
            // btnEvaluationPending
            // 
            this.btnEvaluationPending.BackColor = System.Drawing.Color.Transparent;
            this.btnEvaluationPending.FlatAppearance.BorderSize = 0;
            this.btnEvaluationPending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvaluationPending.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnEvaluationPending.ForeColor = System.Drawing.Color.White;
            this.btnEvaluationPending.Location = new System.Drawing.Point(10, 150);
            this.btnEvaluationPending.Name = "btnEvaluationPending";
            this.btnEvaluationPending.Size = new System.Drawing.Size(230, 42);
            this.btnEvaluationPending.TabIndex = 2;
            this.btnEvaluationPending.Text = "  📝  Evaluation Pending";
            this.btnEvaluationPending.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEvaluationPending.UseVisualStyleBackColor = false;
            this.btnEvaluationPending.Click += new System.EventHandler(this.btnEvaluationPending_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Location = new System.Drawing.Point(10, 90);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(230, 42);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "  🏠  Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // lblPortalTitle
            // 
            this.lblPortalTitle.AutoSize = true;
            this.lblPortalTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblPortalTitle.ForeColor = System.Drawing.Color.White;
            this.lblPortalTitle.Location = new System.Drawing.Point(15, 18);
            this.lblPortalTitle.Name = "lblPortalTitle";
            this.lblPortalTitle.Size = new System.Drawing.Size(212, 30);
            this.lblPortalTitle.TabIndex = 0;
            this.lblPortalTitle.Text = "Project Advisor Hub";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(250, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(930, 80);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(40)))), ((int)(((byte)(85)))));
            this.lblHeader.Location = new System.Drawing.Point(24, 22);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(132, 32);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Dashboard";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMain.Controls.Add(this.pnlHome);
            this.pnlMain.Controls.Add(this.pnlEvaluation);
            this.pnlMain.Controls.Add(this.pnlUncompleted);
            this.pnlMain.Controls.Add(this.pnlUpdate);
            this.pnlMain.Controls.Add(this.pnlIncreaseDeadline);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(250, 80);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(930, 620);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlHome
            // 
            this.pnlHome.BackColor = System.Drawing.Color.White;
            this.pnlHome.Controls.Add(this.lblWelcome);
            this.pnlHome.Controls.Add(this.card1);
            this.pnlHome.Controls.Add(this.card2);
            this.pnlHome.Controls.Add(this.card3);
            this.pnlHome.Controls.Add(this.card4);
            this.pnlHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHome.Location = new System.Drawing.Point(0, 0);
            this.pnlHome.Name = "pnlHome";
            this.pnlHome.Padding = new System.Windows.Forms.Padding(20);
            this.pnlHome.Size = new System.Drawing.Size(930, 620);
            this.pnlHome.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblWelcome.Location = new System.Drawing.Point(10, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(250, 37);
            this.lblWelcome.TabIndex = 10;
            this.lblWelcome.Text = "Advisor Dashboard\n";
            // 
            // card1
            // 
            this.card1.BackColor = System.Drawing.Color.White;
            this.card1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.card1.Controls.Add(this.lblCardTotalProjectsCount);
            this.card1.Controls.Add(this.lblCardTotalProjectsTitle);
            this.card1.Controls.Add(this.strip1);
            this.card1.Location = new System.Drawing.Point(10, 30);
            this.card1.Name = "card1";
            this.card1.Size = new System.Drawing.Size(200, 110);
            this.card1.TabIndex = 0;
            // 
            // lblCardTotalProjectsCount
            // 
            this.lblCardTotalProjectsCount.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblCardTotalProjectsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(40)))), ((int)(((byte)(85)))));
            this.lblCardTotalProjectsCount.Location = new System.Drawing.Point(20, 30);
            this.lblCardTotalProjectsCount.Name = "lblCardTotalProjectsCount";
            this.lblCardTotalProjectsCount.Size = new System.Drawing.Size(160, 45);
            this.lblCardTotalProjectsCount.TabIndex = 1;
            this.lblCardTotalProjectsCount.Text = "0";
            this.lblCardTotalProjectsCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCardTotalProjectsTitle
            // 
            this.lblCardTotalProjectsTitle.AutoSize = true;
            this.lblCardTotalProjectsTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCardTotalProjectsTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblCardTotalProjectsTitle.Location = new System.Drawing.Point(20, 10);
            this.lblCardTotalProjectsTitle.Name = "lblCardTotalProjectsTitle";
            this.lblCardTotalProjectsTitle.Size = new System.Drawing.Size(77, 15);
            this.lblCardTotalProjectsTitle.TabIndex = 0;
            this.lblCardTotalProjectsTitle.Text = "Total Projects";
            // 
            // strip1
            // 
            this.strip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.strip1.Location = new System.Drawing.Point(0, 0);
            this.strip1.Name = "strip1";
            this.strip1.Size = new System.Drawing.Size(6, 110);
            this.strip1.TabIndex = 2;
            // 
            // card2
            // 
            this.card2.BackColor = System.Drawing.Color.White;
            this.card2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.card2.Controls.Add(this.lblCardPendingCount);
            this.card2.Controls.Add(this.lblCardPendingTitle);
            this.card2.Controls.Add(this.strip2);
            this.card2.Location = new System.Drawing.Point(230, 30);
            this.card2.Name = "card2";
            this.card2.Size = new System.Drawing.Size(200, 110);
            this.card2.TabIndex = 1;
            // 
            // lblCardPendingCount
            // 
            this.lblCardPendingCount.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblCardPendingCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.lblCardPendingCount.Location = new System.Drawing.Point(20, 30);
            this.lblCardPendingCount.Name = "lblCardPendingCount";
            this.lblCardPendingCount.Size = new System.Drawing.Size(160, 45);
            this.lblCardPendingCount.TabIndex = 1;
            this.lblCardPendingCount.Text = "0";
            this.lblCardPendingCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCardPendingTitle
            // 
            this.lblCardPendingTitle.AutoSize = true;
            this.lblCardPendingTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCardPendingTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblCardPendingTitle.Location = new System.Drawing.Point(20, 10);
            this.lblCardPendingTitle.Name = "lblCardPendingTitle";
            this.lblCardPendingTitle.Size = new System.Drawing.Size(172, 15);
            this.lblCardPendingTitle.TabIndex = 0;
            this.lblCardPendingTitle.Text = "Projects Pending for Evaluation";
            this.lblCardPendingTitle.Click += new System.EventHandler(this.lblCardPendingTitle_Click);
            // 
            // strip2
            // 
            this.strip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(83)))));
            this.strip2.Location = new System.Drawing.Point(0, 0);
            this.strip2.Name = "strip2";
            this.strip2.Size = new System.Drawing.Size(6, 110);
            this.strip2.TabIndex = 2;
            // 
            // card3
            // 
            this.card3.BackColor = System.Drawing.Color.White;
            this.card3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.card3.Controls.Add(this.lblCardCompletedCount);
            this.card3.Controls.Add(this.lblCardCompletedTitle);
            this.card3.Controls.Add(this.strip3);
            this.card3.Location = new System.Drawing.Point(460, 30);
            this.card3.Name = "card3";
            this.card3.Size = new System.Drawing.Size(200, 110);
            this.card3.TabIndex = 2;
            // 
            // lblCardCompletedCount
            // 
            this.lblCardCompletedCount.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblCardCompletedCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.lblCardCompletedCount.Location = new System.Drawing.Point(20, 30);
            this.lblCardCompletedCount.Name = "lblCardCompletedCount";
            this.lblCardCompletedCount.Size = new System.Drawing.Size(160, 45);
            this.lblCardCompletedCount.TabIndex = 1;
            this.lblCardCompletedCount.Text = "0";
            this.lblCardCompletedCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCardCompletedTitle
            // 
            this.lblCardCompletedTitle.AutoSize = true;
            this.lblCardCompletedTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCardCompletedTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblCardCompletedTitle.Location = new System.Drawing.Point(20, 10);
            this.lblCardCompletedTitle.Name = "lblCardCompletedTitle";
            this.lblCardCompletedTitle.Size = new System.Drawing.Size(129, 15);
            this.lblCardCompletedTitle.TabIndex = 0;
            this.lblCardCompletedTitle.Text = "Evaluations Completed";
            // 
            // strip3
            // 
            this.strip3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(77)))), ((int)(((byte)(255)))));
            this.strip3.Location = new System.Drawing.Point(0, 0);
            this.strip3.Name = "strip3";
            this.strip3.Size = new System.Drawing.Size(6, 110);
            this.strip3.TabIndex = 2;
            // 
            // card4
            // 
            this.card4.BackColor = System.Drawing.Color.White;
            this.card4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.card4.Controls.Add(this.lblCardUncompletedCount);
            this.card4.Controls.Add(this.lblCardUncompletedTitle);
            this.card4.Controls.Add(this.strip4);
            this.card4.Location = new System.Drawing.Point(690, 30);
            this.card4.Name = "card4";
            this.card4.Size = new System.Drawing.Size(200, 110);
            this.card4.TabIndex = 3;
            // 
            // lblCardUncompletedCount
            // 
            this.lblCardUncompletedCount.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblCardUncompletedCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.lblCardUncompletedCount.Location = new System.Drawing.Point(20, 30);
            this.lblCardUncompletedCount.Name = "lblCardUncompletedCount";
            this.lblCardUncompletedCount.Size = new System.Drawing.Size(160, 45);
            this.lblCardUncompletedCount.TabIndex = 1;
            this.lblCardUncompletedCount.Text = "0";
            this.lblCardUncompletedCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCardUncompletedTitle
            // 
            this.lblCardUncompletedTitle.AutoSize = true;
            this.lblCardUncompletedTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCardUncompletedTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblCardUncompletedTitle.Location = new System.Drawing.Point(20, 10);
            this.lblCardUncompletedTitle.Name = "lblCardUncompletedTitle";
            this.lblCardUncompletedTitle.Size = new System.Drawing.Size(144, 15);
            this.lblCardUncompletedTitle.TabIndex = 0;
            this.lblCardUncompletedTitle.Text = "Uncompleted by Students";
            // 
            // strip4
            // 
            this.strip4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(0)))));
            this.strip4.Location = new System.Drawing.Point(0, 0);
            this.strip4.Name = "strip4";
            this.strip4.Size = new System.Drawing.Size(6, 110);
            this.strip4.TabIndex = 2;
            // 
            // pnlEvaluation
            // 
            this.pnlEvaluation.BackColor = System.Drawing.Color.White;
            this.pnlEvaluation.Controls.Add(this.lblEvalTitle);
            this.pnlEvaluation.Controls.Add(this.lblEvalSubtitle);
            this.pnlEvaluation.Controls.Add(this.pnlEvalCard);
            this.pnlEvaluation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEvaluation.Location = new System.Drawing.Point(0, 0);
            this.pnlEvaluation.Name = "pnlEvaluation";
            this.pnlEvaluation.Size = new System.Drawing.Size(930, 620);
            this.pnlEvaluation.TabIndex = 1;
            this.pnlEvaluation.Visible = false;
            // 
            // lblEvalTitle
            // 
            this.lblEvalTitle.AutoSize = true;
            this.lblEvalTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.lblEvalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.lblEvalTitle.Location = new System.Drawing.Point(20, 12);
            this.lblEvalTitle.Name = "lblEvalTitle";
            this.lblEvalTitle.Size = new System.Drawing.Size(252, 37);
            this.lblEvalTitle.TabIndex = 0;
            this.lblEvalTitle.Text = "Evaluation Pending";
            // 
            // lblEvalSubtitle
            // 
            this.lblEvalSubtitle.AutoSize = true;
            this.lblEvalSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEvalSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblEvalSubtitle.Location = new System.Drawing.Point(22, 50);
            this.lblEvalSubtitle.Name = "lblEvalSubtitle";
            this.lblEvalSubtitle.Size = new System.Drawing.Size(225, 15);
            this.lblEvalSubtitle.TabIndex = 1;
            this.lblEvalSubtitle.Text = "List of all projects pending for evaluation.";
            // 
            // pnlEvalCard
            // 
            this.pnlEvalCard.BackColor = System.Drawing.Color.White;
            this.pnlEvalCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEvalCard.Controls.Add(this.pnlSearchContainer);
            this.pnlEvalCard.Controls.Add(this.dgvEvaluationPending);
            this.pnlEvalCard.Location = new System.Drawing.Point(20, 80);
            this.pnlEvalCard.Name = "pnlEvalCard";
            this.pnlEvalCard.Size = new System.Drawing.Size(880, 500);
            this.pnlEvalCard.TabIndex = 2;
            // 
            // pnlSearchContainer
            // 
            this.pnlSearchContainer.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearchContainer.Controls.Add(this.txtSearchEval);
            this.pnlSearchContainer.Controls.Add(this.picSearch);
            this.pnlSearchContainer.Location = new System.Drawing.Point(520, 14);
            this.pnlSearchContainer.Name = "pnlSearchContainer";
            this.pnlSearchContainer.Size = new System.Drawing.Size(340, 36);
            this.pnlSearchContainer.TabIndex = 3;
            // 
            // txtSearchEval
            // 
            this.txtSearchEval.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearchEval.Location = new System.Drawing.Point(6, 6);
            this.txtSearchEval.Name = "txtSearchEval";
            this.txtSearchEval.Size = new System.Drawing.Size(298, 25);
            this.txtSearchEval.TabIndex = 0;
            this.txtSearchEval.TextChanged += new System.EventHandler(this.txtSearchEval_TextChanged);
            // 
            // picSearch
            // 
            this.picSearch.BackColor = System.Drawing.Color.Transparent;
            this.picSearch.Location = new System.Drawing.Point(310, 6);
            this.picSearch.Name = "picSearch";
            this.picSearch.Size = new System.Drawing.Size(24, 24);
            this.picSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSearch.TabIndex = 1;
            this.picSearch.TabStop = false;
            // 
            // dgvEvaluationPending
            // 
            this.dgvEvaluationPending.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEvaluationPending.Location = new System.Drawing.Point(12, 60);
            this.dgvEvaluationPending.Name = "dgvEvaluationPending";
            this.dgvEvaluationPending.Size = new System.Drawing.Size(852, 420);
            this.dgvEvaluationPending.TabIndex = 1;
            this.dgvEvaluationPending.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvaluationPending_CellContentClick);
            // 
            // pnlUncompleted
            // 
            this.pnlUncompleted.BackColor = System.Drawing.Color.White;
            this.pnlUncompleted.Controls.Add(this.dgvUncompleted);
            this.pnlUncompleted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUncompleted.Location = new System.Drawing.Point(0, 0);
            this.pnlUncompleted.Name = "pnlUncompleted";
            this.pnlUncompleted.Size = new System.Drawing.Size(930, 620);
            this.pnlUncompleted.TabIndex = 2;
            this.pnlUncompleted.Visible = false;
            // 
            // dgvUncompleted
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.dgvUncompleted.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUncompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUncompleted.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUncompleted.BackgroundColor = System.Drawing.Color.White;
            this.dgvUncompleted.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUncompleted.ColumnHeadersHeight = 38;
            this.dgvUncompleted.Location = new System.Drawing.Point(20, 20);
            this.dgvUncompleted.Name = "dgvUncompleted";
            this.dgvUncompleted.RowHeadersVisible = false;
            this.dgvUncompleted.RowTemplate.Height = 32;
            this.dgvUncompleted.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUncompleted.Size = new System.Drawing.Size(880, 580);
            this.dgvUncompleted.TabIndex = 0;
            this.dgvUncompleted.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUncompleted_CellContentClick);
            // 
            // pnlUpdate
            // 
            this.pnlUpdate.BackColor = System.Drawing.Color.White;
            this.pnlUpdate.Controls.Add(this.dgvUpdateProjects);
            this.pnlUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUpdate.Location = new System.Drawing.Point(0, 0);
            this.pnlUpdate.Name = "pnlUpdate";
            this.pnlUpdate.Size = new System.Drawing.Size(930, 620);
            this.pnlUpdate.TabIndex = 3;
            this.pnlUpdate.Visible = false;
            // 
            // dgvUpdateProjects
            // 
            this.dgvUpdateProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUpdateProjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUpdateProjects.BackgroundColor = System.Drawing.Color.White;
            this.dgvUpdateProjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUpdateProjects.ColumnHeadersHeight = 38;
            this.dgvUpdateProjects.Location = new System.Drawing.Point(20, 20);
            this.dgvUpdateProjects.Name = "dgvUpdateProjects";
            this.dgvUpdateProjects.RowHeadersVisible = false;
            this.dgvUpdateProjects.RowTemplate.Height = 32;
            this.dgvUpdateProjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUpdateProjects.Size = new System.Drawing.Size(880, 580);
            this.dgvUpdateProjects.TabIndex = 0;
            this.dgvUpdateProjects.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUpdateProjects_CellContentClick);
            // 
            // pnlIncreaseDeadline
            // 
            this.pnlIncreaseDeadline.BackColor = System.Drawing.Color.White;
            this.pnlIncreaseDeadline.Controls.Add(this.lblCurrentDeadline);
            this.pnlIncreaseDeadline.Controls.Add(this.btnUpdateDeadline);
            this.pnlIncreaseDeadline.Controls.Add(this.dtpNewDeadline);
            this.pnlIncreaseDeadline.Controls.Add(this.dgvDeadlines);
            this.pnlIncreaseDeadline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlIncreaseDeadline.Location = new System.Drawing.Point(0, 0);
            this.pnlIncreaseDeadline.Name = "pnlIncreaseDeadline";
            this.pnlIncreaseDeadline.Size = new System.Drawing.Size(930, 620);
            this.pnlIncreaseDeadline.TabIndex = 4;
            this.pnlIncreaseDeadline.Visible = false;
            // 
            // lblCurrentDeadline
            // 
            this.lblCurrentDeadline.AutoSize = true;
            this.lblCurrentDeadline.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCurrentDeadline.Location = new System.Drawing.Point(260, 20);
            this.lblCurrentDeadline.Name = "lblCurrentDeadline";
            this.lblCurrentDeadline.Size = new System.Drawing.Size(87, 19);
            this.lblCurrentDeadline.TabIndex = 3;
            this.lblCurrentDeadline.Text = "Current: N/A";
            // 
            // btnUpdateDeadline
            // 
            this.btnUpdateDeadline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(40)))), ((int)(((byte)(85)))));
            this.btnUpdateDeadline.FlatAppearance.BorderSize = 0;
            this.btnUpdateDeadline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateDeadline.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUpdateDeadline.ForeColor = System.Drawing.Color.White;
            this.btnUpdateDeadline.Location = new System.Drawing.Point(420, 14);
            this.btnUpdateDeadline.Name = "btnUpdateDeadline";
            this.btnUpdateDeadline.Size = new System.Drawing.Size(120, 28);
            this.btnUpdateDeadline.TabIndex = 2;
            this.btnUpdateDeadline.Text = "Update Deadline";
            this.btnUpdateDeadline.UseVisualStyleBackColor = false;
            this.btnUpdateDeadline.Click += new System.EventHandler(this.btnUpdateDeadline_Click);
            // 
            // dtpNewDeadline
            // 
            this.dtpNewDeadline.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNewDeadline.Location = new System.Drawing.Point(20, 16);
            this.dtpNewDeadline.Name = "dtpNewDeadline";
            this.dtpNewDeadline.Size = new System.Drawing.Size(220, 25);
            this.dtpNewDeadline.TabIndex = 1;
            // 
            // dgvDeadlines
            // 
            this.dgvDeadlines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDeadlines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDeadlines.BackgroundColor = System.Drawing.Color.White;
            this.dgvDeadlines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDeadlines.ColumnHeadersHeight = 38;
            this.dgvDeadlines.Location = new System.Drawing.Point(20, 60);
            this.dgvDeadlines.Name = "dgvDeadlines";
            this.dgvDeadlines.RowHeadersVisible = false;
            this.dgvDeadlines.RowTemplate.Height = 32;
            this.dgvDeadlines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeadlines.Size = new System.Drawing.Size(880, 520);
            this.dgvDeadlines.TabIndex = 0;
            this.dgvDeadlines.SelectionChanged += new System.EventHandler(this.dgvDeadlines_SelectionChanged);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1180, 700);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProjectAdvisorHub - Advisor Dashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form5_FormClosed);
            this.Load += new System.EventHandler(this.Form5_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlHome.ResumeLayout(false);
            this.pnlHome.PerformLayout();
            this.card1.ResumeLayout(false);
            this.card1.PerformLayout();
            this.card2.ResumeLayout(false);
            this.card2.PerformLayout();
            this.card3.ResumeLayout(false);
            this.card3.PerformLayout();
            this.card4.ResumeLayout(false);
            this.card4.PerformLayout();
            this.pnlEvaluation.ResumeLayout(false);
            this.pnlEvaluation.PerformLayout();
            this.pnlEvalCard.ResumeLayout(false);
            this.pnlSearchContainer.ResumeLayout(false);
            this.pnlSearchContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvaluationPending)).EndInit();
            this.pnlUncompleted.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUncompleted)).EndInit();
            this.pnlUpdate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpdateProjects)).EndInit();
            this.pnlIncreaseDeadline.ResumeLayout(false);
            this.pnlIncreaseDeadline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeadlines)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblPortalTitle;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnEvaluationPending;
        private System.Windows.Forms.Button btnUncompleted;
        private System.Windows.Forms.Button btnUpdateProject;
        private System.Windows.Forms.Button btnIncreaseDeadline;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel pnlHome;
        private System.Windows.Forms.Panel card1;
        private System.Windows.Forms.Label lblCardTotalProjectsCount;
        private System.Windows.Forms.Label lblCardTotalProjectsTitle;
        private System.Windows.Forms.Panel card2;
        private System.Windows.Forms.Label lblCardPendingCount;
        private System.Windows.Forms.Label lblCardPendingTitle;
        private System.Windows.Forms.Panel card3;
        private System.Windows.Forms.Label lblCardCompletedCount;
        private System.Windows.Forms.Label lblCardCompletedTitle;
        private System.Windows.Forms.Panel card4;
        private System.Windows.Forms.Label lblCardUncompletedCount;
        private System.Windows.Forms.Label lblCardUncompletedTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel strip1;
        private System.Windows.Forms.Panel strip2;
        private System.Windows.Forms.Panel strip3;
        private System.Windows.Forms.Panel strip4;
        private System.Windows.Forms.Panel pnlEvaluation;
        private System.Windows.Forms.TextBox txtSearchEval;
        private System.Windows.Forms.PictureBox picSearch;
        private System.Windows.Forms.Panel pnlEvalCard;
        private System.Windows.Forms.Panel pnlSearchContainer;
        private System.Windows.Forms.Label lblEvalTitle;
        private System.Windows.Forms.Label lblEvalSubtitle;
        private System.Windows.Forms.DataGridView dgvEvaluationPending;
        private System.Windows.Forms.Panel pnlUncompleted;
        private System.Windows.Forms.DataGridView dgvUncompleted;
        private System.Windows.Forms.Panel pnlUpdate;
        private System.Windows.Forms.DataGridView dgvUpdateProjects;
        private System.Windows.Forms.Panel pnlIncreaseDeadline;
        private System.Windows.Forms.DataGridView dgvDeadlines;
        private System.Windows.Forms.DateTimePicker dtpNewDeadline;
        private System.Windows.Forms.Button btnUpdateDeadline;
        private System.Windows.Forms.Label lblCurrentDeadline;
    }
}