using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Out_of_Office.DataSources;
using Out_of_Office.RoleForms.DialogueForms;
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

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl.SelectedIndex == 0)
                PLRefreshCircleButton_Click(sender, e);
            else if (TabControl.SelectedIndex == 1)
            {
                var leaveRequests = LeaveRequestVM.FromEntities(CrudService.Get_LeaveRequests());
                leaveRequestsBindingSource = (leaveRequests != null)
                    ? new SortedBindingList<LeaveRequestVM>(leaveRequests)
                    : new SortedBindingList<LeaveRequestVM>(new List<LeaveRequestVM>());
                LeaveRequestsDataGridView.DataSource = leaveRequestsBindingSource;
            }
        }

        #region [Projects List tab]

        private void PLRefreshCircleButton_Click(object sender, EventArgs e)
        {
            var projects = ProjectVM.FromEntities(CrudService.Get_Projects());
            projectsBindingSource = (projects != null)
                ? new SortedBindingList<ProjectVM>(projects)
                : new SortedBindingList<ProjectVM>(new List<ProjectVM>());
            ProjectsDataGridView.DataSource = projectsBindingSource;
        }

        private void ProjectsDataGridView_CelltDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                long id = (long)ProjectsDataGridView[0, e.RowIndex].Value;
                var proj = CrudService.Get_Project(id);
                if (proj is not null)
                {
                    var projVM = ProjectVM.FromEntity(proj);
                    new ProjectsForm(this, projVM).ShowDialog();
                    LRLRefreshCircleButton_Click(sender, e);
                }
                else
                    MessageBox.Show("KAKA");
            }
        }

        #endregion

        #region [Leave Requests List tab]

        private void LRLRefreshCircleButton_Click(object sender, EventArgs e)
        {
            var leaveRequests = LeaveRequestVM.FromEntities(CrudService.Get_LeaveRequests());
            leaveRequestsBindingSource = (leaveRequests != null)
                ? new SortedBindingList<LeaveRequestVM>(leaveRequests)
                : new SortedBindingList<LeaveRequestVM>(new List<LeaveRequestVM>());
            LeaveRequestsDataGridView.DataSource = leaveRequestsBindingSource;
        }

        private void AddNewLRButton_Click(object sender, EventArgs e)
        {
            new LeaveRequestForm(this).ShowDialog();
            LRLRefreshCircleButton_Click(sender, e);
        }

        private void LeaveRequestsDataGridView_CellContentDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                long id = (long)LeaveRequestsDataGridView[0, e.RowIndex].Value;
                var req = CrudService.Get_LeaveRequest(id);
                if (req is not null)
                {
                    var reqVM = LeaveRequestVM.FromEntity(req);
                    new LeaveRequestForm(this, reqVM).ShowDialog();
                    LRLRefreshCircleButton_Click(sender, e);
                }
                else
                    MessageBox.Show("KAKA");
            }
        }

        #endregion

        private void DataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
