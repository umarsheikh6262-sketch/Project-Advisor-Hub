using System;
using System.Drawing;
using System.Windows.Forms;

namespace semester_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartFadeInEffect();
        }

        private void StartFadeInEffect()
        {
            this.Opacity = 0;
            Timer fadeTimer = new Timer { Interval = 25 };
            fadeTimer.Tick += (s, ev) =>
            {
                if (this.Opacity < 1)
                {
                    this.Opacity += 0.05;
                }
                else
                {
                    fadeTimer.Stop();
                    fadeTimer.Dispose();
                }
            };
            fadeTimer.Start();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Open login screen
            Form2 loginForm = new Form2();
            this.Hide();
            loginForm.Show();

            // Ensure app exits when the next form is closed
            loginForm.FormClosed += (s, args) => Application.Exit();
        }

        private void btnStart_MouseEnter(object sender, EventArgs e)
        {
            btnStart.BackColor = Color.FromArgb(65, 90, 210);
            Cursor = Cursors.Hand;
        }

        private void btnStart_MouseLeave(object sender, EventArgs e)
        {
            btnStart.BackColor = Color.FromArgb(85, 110, 230);
            Cursor = Cursors.Default;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
