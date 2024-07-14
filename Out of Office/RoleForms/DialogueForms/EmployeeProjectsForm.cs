using Guna.UI2.WinForms;
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
    public partial class EmployeeProjectsForm : Form
    {
        public EmployeeProjectsForm()
        {
            InitializeComponent();
            InitializeGridData();
        }

        private void InitializeGridData()
        {



            ProjectsDataGridView.Rows.Add(false, 1, "Project 1");
            ProjectsDataGridView.Rows.Add(true, 2, "Project 2");
            ProjectsDataGridView.Rows.Add(false, 3, "Project 3");
        }

        private void Guna2DataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (ProjectsDataGridView.IsCurrentCellDirty)
            {
                ProjectsDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void Guna2DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0) // CheckBox column index
            {
                bool isChecked = (bool)ProjectsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                string projectName = ProjectsDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                MessageBox.Show($"{projectName} is {(isChecked ? "assigned" : "unassigned")}");
            }
        }

        private void DeactivateButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
