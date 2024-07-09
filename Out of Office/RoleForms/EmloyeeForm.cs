using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Out_of_Office.DataSources;
using OutOfOffice.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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

        private SortedBindingList<ProjectVM> projectsBindingSource;
        private SortedBindingList<LeaveRequestVM> leaveRequestsBindingSource;

        public EmployeeForm()
        {
            InitializeComponent();

            ProjectsDataGridView.DataSource = projectsBindingSource;
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
                projectsBindingSource = (projects != null) 
                    ? new SortedBindingList<ProjectVM>(projects) 
                    : new SortedBindingList<ProjectVM>(new List<ProjectVM>());
                ProjectsDataGridView.DataSource = projectsBindingSource;
            }
            else if (TabControl.SelectedIndex == 1)
            {
                var leaveRequests = LeaveRequestVM.FromEntities(CrudService.Get_LeaveRequests());
                leaveRequestsBindingSource = (leaveRequests != null)
                    ? new SortedBindingList<LeaveRequestVM>(leaveRequests)
                    : new SortedBindingList<LeaveRequestVM>(new List<LeaveRequestVM>());
                LeaveRequestsDataGridView.DataSource = leaveRequestsBindingSource;
            }
        }

        private void ProjectsDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ProjectsDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = ProjectsDataGridView.Columns[e.ColumnIndex].DataPropertyName;

            ListSortDirection direction;

            if (ProjectsDataGridView.SortOrder == SortOrder.Ascending || ProjectsDataGridView.SortOrder == SortOrder.None)
                direction = ListSortDirection.Ascending;
            else
                direction = ListSortDirection.Descending;

            // Перевірка наявності властивості в класі ProjectVM
            var property = typeof(ProjectVM).GetProperty(columnName);
            if (property == null)
            {
                MessageBox.Show($"Property '{columnName}' does not exist in 'ProjectVM'.");
                return;
            }

            projectsBindingSource.ApplySort(columnName, direction);
        }
    }
}
