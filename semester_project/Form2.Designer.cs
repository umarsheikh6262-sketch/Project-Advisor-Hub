namespace semester_project
{
    partial class Form2
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
            this.pnlLeftBranding = new System.Windows.Forms.Panel();
            this.lblSubTagline = new System.Windows.Forms.Label();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.pnlRightLogin = new System.Windows.Forms.Panel();
            this.tblRightInner = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tblRoot = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeftBranding.SuspendLayout();
            this.pnlRightLogin.SuspendLayout();
            this.tblRightInner.SuspendLayout();
            this.tblRoot.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLeftBranding
            // 
            this.pnlLeftBranding.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.pnlLeftBranding.Controls.Add(this.lblSubTagline);
            this.pnlLeftBranding.Controls.Add(this.lblMainTitle);
            this.pnlLeftBranding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftBranding.Location = new System.Drawing.Point(2, 2);
            this.pnlLeftBranding.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlLeftBranding.Name = "pnlLeftBranding";
            this.pnlLeftBranding.Size = new System.Drawing.Size(296, 484);
            this.pnlLeftBranding.TabIndex = 0;
            // 
            // lblSubTagline
            // 
            this.lblSubTagline.Font = new System.Drawing.Font("Segoe UI Light", 11F);
            this.lblSubTagline.ForeColor = System.Drawing.Color.DarkGray;
            this.lblSubTagline.Location = new System.Drawing.Point(18, 179);
            this.lblSubTagline.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubTagline.Name = "lblSubTagline";
            this.lblSubTagline.Size = new System.Drawing.Size(264, 43);
            this.lblSubTagline.TabIndex = 1;
            this.lblSubTagline.Text = "Streamlining Innovation,\r\nEmpowering Collaboration.";
            this.lblSubTagline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblMainTitle.ForeColor = System.Drawing.Color.White;
            this.lblMainTitle.Location = new System.Drawing.Point(18, 138);
            this.lblMainTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(275, 41);
            this.lblMainTitle.TabIndex = 0;
            this.lblMainTitle.Text = "ProjectAdvisorHub";
            // 
            // pnlRightLogin
            // 
            this.pnlRightLogin.BackColor = System.Drawing.Color.White;
            this.pnlRightLogin.Controls.Add(this.tblRightInner);
            this.pnlRightLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightLogin.Location = new System.Drawing.Point(302, 2);
            this.pnlRightLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlRightLogin.Name = "pnlRightLogin";
            this.pnlRightLogin.Size = new System.Drawing.Size(446, 484);
            this.pnlRightLogin.TabIndex = 1;
            // 
            // tblRightInner
            // 
            this.tblRightInner.ColumnCount = 1;
            this.tblRightInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblRightInner.Controls.Add(this.lblHeaderTitle, 0, 0);
            this.tblRightInner.Controls.Add(this.txtUsername, 0, 1);
            this.tblRightInner.Controls.Add(this.txtPassword, 0, 2);
            this.tblRightInner.Controls.Add(this.chkShowPassword, 0, 3);
            this.tblRightInner.Controls.Add(this.btnLogin, 0, 4);
            this.tblRightInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblRightInner.Location = new System.Drawing.Point(0, 0);
            this.tblRightInner.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tblRightInner.Name = "tblRightInner";
            this.tblRightInner.Padding = new System.Windows.Forms.Padding(45, 16, 45, 16);
            this.tblRightInner.RowCount = 6;
            this.tblRightInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tblRightInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tblRightInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tblRightInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tblRightInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tblRightInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblRightInner.Size = new System.Drawing.Size(446, 484);
            this.tblRightInner.TabIndex = 0;
            this.tblRightInner.Paint += new System.Windows.Forms.PaintEventHandler(this.tblRightInner_Paint);
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.lblHeaderTitle.Location = new System.Drawing.Point(47, 49);
            this.lblHeaderTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(170, 32);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Account Login";
            // 
            // txtUsername
            // 
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUsername.Location = new System.Drawing.Point(47, 116);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(352, 29);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Enter += new System.EventHandler(this.txtUsername_Enter);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPassword.Location = new System.Drawing.Point(47, 165);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(352, 29);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkShowPassword.ForeColor = System.Drawing.Color.DimGray;
            this.chkShowPassword.Location = new System.Drawing.Point(47, 214);
            this.chkShowPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(108, 19);
            this.chkShowPassword.TabIndex = 4;
            this.chkShowPassword.Text = "Show Password";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(39)))), ((int)(((byte)(46)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(47, 238);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(352, 45);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login to Portal";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tblRoot
            // 
            this.tblRoot.ColumnCount = 2;
            this.tblRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tblRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblRoot.Controls.Add(this.pnlLeftBranding, 0, 0);
            this.tblRoot.Controls.Add(this.pnlRightLogin, 1, 0);
            this.tblRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblRoot.Location = new System.Drawing.Point(0, 0);
            this.tblRoot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tblRoot.Name = "tblRoot";
            this.tblRoot.RowCount = 1;
            this.tblRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblRoot.Size = new System.Drawing.Size(750, 488);
            this.tblRoot.TabIndex = 2;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 488);
            this.Controls.Add(this.tblRoot);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(679, 493);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProjectAdvisorHub - Portal Gateway";
            this.pnlLeftBranding.ResumeLayout(false);
            this.pnlLeftBranding.PerformLayout();
            this.pnlRightLogin.ResumeLayout(false);
            this.tblRightInner.ResumeLayout(false);
            this.tblRightInner.PerformLayout();
            this.tblRoot.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeftBranding;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Label lblSubTagline;
        private System.Windows.Forms.Panel pnlRightLogin;
        private System.Windows.Forms.TableLayoutPanel tblRoot;
        private System.Windows.Forms.TableLayoutPanel tblRightInner;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox chkShowPassword;
    }
}