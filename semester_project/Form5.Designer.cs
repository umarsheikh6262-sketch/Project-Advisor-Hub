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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblTotalGroups = new System.Windows.Forms.Label();
            this.lblPortalTitle = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblAdvisorWelcome = new System.Windows.Forms.Label();
            this.lblGridHeader = new System.Windows.Forms.Label();
            this.dgvAssignedGroups = new System.Windows.Forms.DataGridView();
            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignedGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.pnlSidebar.Controls.Add(this.lblTotalGroups);
            this.pnlSidebar.Controls.Add(this.lblPortalTitle);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(240, 600);
            this.pnlSidebar.TabIndex = 0;
            // 
            // lblTotalGroups
            // 
            this.lblTotalGroups.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalGroups.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(239)))), ((int)(((byte)(186)))));
            this.lblTotalGroups.Location = new System.Drawing.Point(20, 110);
            this.lblTotalGroups.Name = "lblTotalGroups";
            this.lblTotalGroups.Size = new System.Drawing.Size(200, 45);
            this.lblTotalGroups.TabIndex = 1;
            this.lblTotalGroups.Text = "Total Active Groups: ...";
            this.lblTotalGroups.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPortalTitle
            // 
            this.lblPortalTitle.AutoSize = true;
            this.lblPortalTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPortalTitle.ForeColor = System.Drawing.Color.White;
            this.lblPortalTitle.Location = new System.Drawing.Point(20, 35);
            this.lblPortalTitle.Name = "lblPortalTitle";
            this.lblPortalTitle.Size = new System.Drawing.Size(155, 30);
            this.lblPortalTitle.TabIndex = 0;
            this.lblPortalTitle.Text = "Advisor Studio";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.lblAdvisorWelcome);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(240, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(710, 85);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblAdvisorWelcome
            // 
            this.lblAdvisorWelcome.AutoSize = true;
            this.lblAdvisorWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAdvisorWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.lblAdvisorWelcome.Location = new System.Drawing.Point(25, 25);
            this.lblAdvisorWelcome.Name = "lblAdvisorWelcome";
            this.lblAdvisorWelcome.Size = new System.Drawing.Size(248, 32);
            this.lblAdvisorWelcome.TabIndex = 0;
            this.lblAdvisorWelcome.Text = "Advisor Management";
            // 
            // lblGridHeader
            // 
            this.lblGridHeader.AutoSize = true;
            this.lblGridHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGridHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            this.lblGridHeader.Location = new System.Drawing.Point(265, 115);
            this.lblGridHeader.Name = "lblGridHeader";
            this.lblGridHeader.Size = new System.Drawing.Size(250, 25);
            this.lblGridHeader.TabIndex = 2;
            this.lblGridHeader.Text = "Your Assigned Project Groups";
            // 
            // dgvAssignedGroups
            // 
            this.dgvAssignedGroups.AllowUserToAddRows = false;
            this.dgvAssignedGroups.AllowUserToDeleteRows = false;
            this.dgvAssignedGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAssignedGroups.BackgroundColor = System.Drawing.Color.White;
            this.dgvAssignedGroups.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(58)))), ((int)(((byte)(71)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAssignedGroups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAssignedGroups.ColumnHeadersHeight = 38;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(239)))), ((int)(((byte)(186)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAssignedGroups.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAssignedGroups.EnableHeadersVisualStyles = false;
            this.dgvAssignedGroups.Location = new System.Drawing.Point(265, 155);
            this.dgvAssignedGroups.Name = "dgvAssignedGroups";
            this.dgvAssignedGroups.ReadOnly = true;
            this.dgvAssignedGroups.RowHeadersVisible = false;
            this.dgvAssignedGroups.RowTemplate.Height = 32;
            this.dgvAssignedGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssignedGroups.Size = new System.Drawing.Size(660, 415);
            this.dgvAssignedGroups.TabIndex = 3;
            // 
            // AdvisorDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.dgvAssignedGroups);
            this.Controls.Add(this.lblGridHeader);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdvisorDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProjectAdvisorHub - Advisor Studio";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdvisorDashboard_FormClosed);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignedGroups)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblPortalTitle;
        private System.Windows.Forms.Label lblTotalGroups;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAdvisorWelcome;
        private System.Windows.Forms.Label lblGridHeader;
        private System.Windows.Forms.DataGridView dgvAssignedGroups;
    }
}