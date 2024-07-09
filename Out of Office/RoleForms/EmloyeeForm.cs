using Out_of_Office.DataSources;
using OutOfOffice.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutOfOffice.RoleForms
{
    public partial class EmployeeForm : Form
    {
        /// <summary>
        /// Розташування <see cref="TopPanel"/> (для переміщення вікна мишкою)
        /// </summary>
        Point lastPoint;

        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            TabControl_SelectedIndexChanged(sender, e);
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

        private void ApplyRoleButton_Click(object sender, EventArgs e)
        {
            var emps = CrudService.Get_Employees();
            label1.Text = emps[0].FullName;
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl.SelectedIndex == 0)
            {
                var projects = ProjectVM.FromEntities(CrudService.Get_Projects());
                ProjectsDataGridView.DataSource = (projects != null) ? projects : new List<ProjectVM>();
            }
            else if (TabControl.SelectedIndex == 1)
            {
                var leaveRequests = LeaveRequestVM.FromEntities(CrudService.Get_LeaveRequests());
                LeaveRequestsDataGridView.DataSource = (leaveRequests != null) ? leaveRequests : new List<LeaveRequestVM>();
            }
        }

        private void ProjectsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
