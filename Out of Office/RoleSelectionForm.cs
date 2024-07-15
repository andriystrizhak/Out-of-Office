using Out_of_Office;
using OutOfOffice.RoleForms;

namespace OutOfOffice
{
    public partial class RoleSelectionForm : Form
    {
        /// <summary>
        /// Розташування <see cref="TopPanel"/> (для переміщення вікна мишкою)
        /// </summary>
        Point lastPoint;

        public RoleSelectionForm()
        {
            InitializeComponent();
        }

        #region [ this form ]

        private void MainForm_Shown(object sender, EventArgs e)
        {
            //Thread.Sleep(500);
            //SplashScreenManager.CloseForm();

            FadeInTimer.Start();
        }

        double FadeInOutDelta { get; } = 0.05;

        private void FadeInTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += FadeInOutDelta;
            else
            {
                FadeInTimer.Stop();
            }
        }

        private void FadeOutTimer_AndClose_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
                this.Opacity -= 2 * FadeInOutDelta;
            else
                this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            //var handler = ShowProgressPanel(this);

            DialogResult closeForm = (Program.CurrentRole != UserRole.Exit)
                ? DialogResult.Yes
                : MessageBox.Show(
                "Do you really want to leave?", "Bye?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (closeForm == DialogResult.Yes)
            {
                this.FormClosing -= MainForm_FormClosing;
                FadeOutTimer.Start();
            }
            //handler.Close();
            e.Cancel = true;
        }

        #endregion

        #region [ TopPanel ]

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Program.CurrentRole = UserRole.Exit;
            Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
            => WindowState = FormWindowState.Minimized;

        private void This_MouseDown(object sender, MouseEventArgs e)
            => lastPoint = new Point(e.X, e.Y);
        private void This_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        #endregion

        private void RolesRadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            ApplyRoleButton.Enabled = true;
        }

        private void ApplyRoleButton_Click(object sender, EventArgs e)
        {
            if (EmloyeeButton.Checked)
                Program.CurrentRole = UserRole.Employee;
            else if (HRButton.Checked)
                Program.CurrentRole = UserRole.HR;
            else if (PMButton.Checked)
                Program.CurrentRole = UserRole.PM;

            Close();
        }
    }
}
