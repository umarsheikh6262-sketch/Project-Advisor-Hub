namespace semester_project
{
    partial class Form4
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

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblGroupDisplay = new System.Windows.Forms.Label();
            this.lblPortalTitle = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblProjectTitle = new System.Windows.Forms.Label();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.grpSubmissions = new System.Windows.Forms.GroupBox();
            this.lblDocStatus = new System.Windows.Forms.Label();
            this.lblProposalStatus = new System.Windows.Forms.Label();
            this.btnSubmitDoc = new System.Windows.Forms.Button();
            this.btnSubmitProposal = new System.Windows.Forms.Button();
            this.pnlAdvisorCard = new System.Windows.Forms.Panel();
            this.lblAdvisorEmail = new System.Windows.Forms.Label();
            this.lblAdvisorName = new System.Windows.Forms.Label();
            this.lblAdvisorHeader = new System.Windows.Forms.Label();
            this.dgvGroupMembers = new System.Windows.Forms.DataGridView();
            this.lblTeamHeader = new System.Windows.Forms.Label();
            this.grpProjectDetails = new System.Windows.Forms.GroupBox();
            this.lblDeadlineDisplay = new System.Windows.Forms.Label();
            this.lblDeadlineHeader = new System.Windows.Forms.Label();
            this.txtProjectDesc = new System.Windows.Forms.TextBox();
            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            this.grpSubmissions.SuspendLayout();
            this.pnlAdvisorCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupMembers)).BeginInit();
            this.grpProjectDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.pnlSidebar.Controls.Add(this.lblGroupDisplay);
            this.pnlSidebar.Controls.Add(this.lblPortalTitle);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Size = new System.Drawing.Size(240, 700);
            // 
            // lblGroupDisplay
            // 
            this.lblGroupDisplay.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblGroupDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(239)))), ((int)(((byte)(186)))));
            this.lblGroupDisplay.Location = new System.Drawing.Point(20, 100);
            this.lblGroupDisplay.Size = new System.Drawing.Size(200, 30);
            this.lblGroupDisplay.Text = "Group ID: ...";
            // 
            // lblPortalTitle
            // 
            this.lblPortalTitle.AutoSize = true;
            this.lblPortalTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblPortalTitle.ForeColor = System.Drawing.Color.White;
            this.lblPortalTitle.Location = new System.Drawing.Point(20, 35);
            this.lblPortalTitle.Text = "Student Portal";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblProjectTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(240, 0);
            this.pnlHeader.Size = new System.Drawing.Size(860, 85);
            // 
            // lblProjectTitle
            // 
            this.lblProjectTitle.AutoSize = true;
            this.lblProjectTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblProjectTitle.Location = new System.Drawing.Point(25, 25);
            this.lblProjectTitle.Text = "Project Title";
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Controls.Add(this.grpSubmissions);
            this.pnlMainContent.Controls.Add(this.pnlAdvisorCard);
            this.pnlMainContent.Controls.Add(this.dgvGroupMembers);
            this.pnlMainContent.Controls.Add(this.lblTeamHeader);
            this.pnlMainContent.Controls.Add(this.grpProjectDetails);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(240, 85);
            this.pnlMainContent.Size = new System.Drawing.Size(860, 615);
            // 
            // grpSubmissions
            // 
            this.grpSubmissions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSubmissions.Controls.Add(this.lblDocStatus);
            this.grpSubmissions.Controls.Add(this.lblProposalStatus);
            this.grpSubmissions.Controls.Add(this.btnSubmitDoc);
            this.grpSubmissions.Controls.Add(this.btnSubmitProposal);
            this.grpSubmissions.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.grpSubmissions.Location = new System.Drawing.Point(580, 210);
            this.grpSubmissions.Size = new System.Drawing.Size(255, 180);
            this.grpSubmissions.Text = "Submission Center";
            // 
            // lblDocStatus
            // 
            this.lblDocStatus.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDocStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblDocStatus.Location = new System.Drawing.Point(15, 140);
            this.lblDocStatus.Size = new System.Drawing.Size(225, 20);
            this.lblDocStatus.Text = "Not submitted";
            // 
            // lblProposalStatus
            // 
            this.lblProposalStatus.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblProposalStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblProposalStatus.Location = new System.Drawing.Point(15, 75);
            this.lblProposalStatus.Size = new System.Drawing.Size(225, 20);
            this.lblProposalStatus.Text = "Not submitted";
            // 
            // btnSubmitDoc
            // 
            this.btnSubmitDoc.Location = new System.Drawing.Point(15, 100);
            this.btnSubmitDoc.Size = new System.Drawing.Size(225, 35);
            this.btnSubmitDoc.Text = "Upload Final Doc";
            this.btnSubmitDoc.Click += new System.EventHandler(this.btnSubmitDoc_Click);
            // 
            // btnSubmitProposal
            // 
            this.btnSubmitProposal.Location = new System.Drawing.Point(15, 35);
            this.btnSubmitProposal.Size = new System.Drawing.Size(225, 35);
            this.btnSubmitProposal.Text = "Upload Proposal";
            this.btnSubmitProposal.Click += new System.EventHandler(this.btnSubmitProposal_Click);
            // 
            // pnlAdvisorCard
            // 
            this.pnlAdvisorCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAdvisorCard.BackColor = System.Drawing.Color.White;
            this.pnlAdvisorCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAdvisorCard.Controls.Add(this.lblAdvisorEmail);
            this.pnlAdvisorCard.Controls.Add(this.lblAdvisorName);
            this.pnlAdvisorCard.Controls.Add(this.lblAdvisorHeader);
            this.pnlAdvisorCard.Location = new System.Drawing.Point(580, 20);
            this.pnlAdvisorCard.Size = new System.Drawing.Size(255, 175);
            // 
            // lblAdvisorEmail
            // 
            this.lblAdvisorEmail.Location = new System.Drawing.Point(15, 105);
            this.lblAdvisorEmail.Size = new System.Drawing.Size(225, 45);
            this.lblAdvisorEmail.Text = "Email: ...";
            // 
            // lblAdvisorName
            // 
            this.lblAdvisorName.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblAdvisorName.Location = new System.Drawing.Point(15, 60);
            this.lblAdvisorName.Size = new System.Drawing.Size(225, 35);
            this.lblAdvisorName.Text = "Name: Not Assigned";
            // 
            // lblAdvisorHeader
            // 
            this.lblAdvisorHeader.AutoSize = true;
            this.lblAdvisorHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Underline);
            this.lblAdvisorHeader.Location = new System.Drawing.Point(15, 15);
            this.lblAdvisorHeader.Text = "Project Advisor";
            // 
            // dgvGroupMembers
            // 
            this.dgvGroupMembers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGroupMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGroupMembers.BackgroundColor = System.Drawing.Color.White;
            this.dgvGroupMembers.ColumnHeadersHeight = 35;
            this.dgvGroupMembers.Location = new System.Drawing.Point(25, 420);
            this.dgvGroupMembers.Name = "dgvGroupMembers";
            this.dgvGroupMembers.Size = new System.Drawing.Size(810, 170);
            // 
            // lblTeamHeader
            // 
            this.lblTeamHeader.AutoSize = true;
            this.lblTeamHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.lblTeamHeader.Location = new System.Drawing.Point(25, 385);
            this.lblTeamHeader.Text = "Your Group Members";
            // 
            // grpProjectDetails
            // 
            this.grpProjectDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProjectDetails.Controls.Add(this.lblDeadlineDisplay);
            this.grpProjectDetails.Controls.Add(this.lblDeadlineHeader);
            this.grpProjectDetails.Controls.Add(this.txtProjectDesc);
            this.grpProjectDetails.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.grpProjectDetails.Location = new System.Drawing.Point(25, 10);
            this.grpProjectDetails.Size = new System.Drawing.Size(540, 360);
            this.grpProjectDetails.Text = "Project Specifications";
            // 
            // lblDeadlineDisplay
            // 
            this.lblDeadlineDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDeadlineDisplay.AutoSize = true;
            this.lblDeadlineDisplay.Location = new System.Drawing.Point(95, 320);
            this.lblDeadlineDisplay.Text = "N/A";
            // 
            // lblDeadlineHeader
            // 
            this.lblDeadlineHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDeadlineHeader.AutoSize = true;
            this.lblDeadlineHeader.Location = new System.Drawing.Point(20, 320);
            this.lblDeadlineHeader.Text = "Deadline:";
            // 
            // txtProjectDesc
            // 
            this.txtProjectDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProjectDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProjectDesc.Multiline = true;
            this.txtProjectDesc.Name = "txtProjectDesc";
            this.txtProjectDesc.ReadOnly = true;
            this.txtProjectDesc.Size = new System.Drawing.Size(500, 270);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "Form4";
            this.Text = "Student Workspace";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudentDashboard_FormClosed);
            this.Load += new System.EventHandler(this.Form4_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMainContent.ResumeLayout(false);
            this.pnlMainContent.PerformLayout();
            this.grpSubmissions.ResumeLayout(false);
            this.pnlAdvisorCard.ResumeLayout(false);
            this.pnlAdvisorCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupMembers)).EndInit();
            this.grpProjectDetails.ResumeLayout(false);
            this.grpProjectDetails.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblPortalTitle;
        private System.Windows.Forms.Label lblGroupDisplay;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblProjectTitle;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Panel pnlAdvisorCard;
        private System.Windows.Forms.Label lblAdvisorHeader;
        private System.Windows.Forms.Label lblAdvisorName;
        private System.Windows.Forms.Label lblAdvisorEmail;
        private System.Windows.Forms.GroupBox grpProjectDetails;
        private System.Windows.Forms.TextBox txtProjectDesc;
        private System.Windows.Forms.Label lblDeadlineHeader;
        private System.Windows.Forms.Label lblDeadlineDisplay;
        private System.Windows.Forms.Label lblTeamHeader;
        private System.Windows.Forms.DataGridView dgvGroupMembers;
        private System.Windows.Forms.GroupBox grpSubmissions;
        private System.Windows.Forms.Button btnSubmitProposal;
        private System.Windows.Forms.Button btnSubmitDoc;
        private System.Windows.Forms.Label lblProposalStatus;
        private System.Windows.Forms.Label lblDocStatus;
    }
}