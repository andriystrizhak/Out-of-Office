using Guna.UI2.WinForms;
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

namespace Out_of_Office.RoleForms.DialogueForms
{
    public partial class ProjectEmployeesForm : Form
    {
        private SortedBindingList<ProjectEmployeeVM> emplProjBindingSource;
        private List<ProjectEmployeeVM> initialPEList;
        private long currentProjId;

        public ProjectEmployeesForm(long id)
        {
            currentProjId = id;

            InitializeComponent();
            InitializeGridData();
        }

        private void InitializeGridData()
        {
            /*
            var projEmpsVM = ProjectEmployeeVM.FromEntities(CrudService.Get_Employees(), currentProjId);
            emplProjBindingSource = (projEmpsVM != null)
                ? new SortedBindingList<ProjectEmployeeVM>(projEmpsVM)
                : new SortedBindingList<ProjectEmployeeVM>(new List<ProjectEmployeeVM>());
            ProjectEmployeesDataGridView.DataSource = emplProjBindingSource;
            */

            //Creating copy of initial data
            initialPEList = ProjectEmployeeVM.FromEntities(CrudService.Get_Employees(), currentProjId);
            var projEmpsVM = ProjectEmployeeVM.FromEntities(CrudService.Get_Employees(), currentProjId);
            ProjectEmployeesDataGridView.DataSource = projEmpsVM;
        }

        private void ProjectsDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (ProjectEmployeesDataGridView.Columns.Contains("Assigned"))
            {
                ProjectEmployeesDataGridView.Columns["Assigned"].ValueType = typeof(bool);
                ProjectEmployeesDataGridView.Columns["Assigned"].Visible = true;
                ProjectEmployeesDataGridView.Columns["Assigned"].ReadOnly = false;
            }

            if (ProjectEmployeesDataGridView.Columns.Contains("EmployeeName"))
            {
                ProjectEmployeesDataGridView.Columns["EmployeeName"].HeaderText = "Employee Name";
                ProjectEmployeesDataGridView.Columns["EmployeeName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void ProjectEmployeesDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (ProjectEmployeesDataGridView.IsCurrentCellDirty)
                ProjectEmployeesDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        /*
        private void ProjectEmployeesDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // CheckBox column index
            {
                bool isChecked = (bool)ProjectEmployeesDataGridView[e.ColumnIndex, e.RowIndex].Value;
                string projectName = ProjectEmployeesDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }
        */

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var emplProjsVM = (List<ProjectEmployeeVM>)ProjectEmployeesDataGridView.DataSource;

            var diffToAdd = ProjectEmployeeVM.Get_DifferenceToAdd(
                        initialPEList, emplProjsVM);
            CrudService.Add_EmployeeProjects(
                ProjectEmployeeVM.ToEntities(
                    diffToAdd, currentProjId));

            var diffToRemove = ProjectEmployeeVM.Get_DifferenceToRemove(
                initialPEList, emplProjsVM);
            CrudService.Remove_EmployeeProjects(
                ProjectEmployeeVM.ToEntities(
                    diffToRemove, currentProjId));
            
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
            => Close();
    }
}
