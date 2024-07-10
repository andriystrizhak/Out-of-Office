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

        #region [ TopPanel ]

        private void CloseButton_Click(object sender, EventArgs e)
            => Close();

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
