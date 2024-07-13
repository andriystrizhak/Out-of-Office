using Out_of_Office.DataSources;
using OutOfOffice.Models;
using OutOfOffice.RoleForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Out_of_Office.RoleForms.DialogueForms
{
    public partial class ProjectForm : Form
    {
        private Form owner;
        private ProjectVM? projectVM = null;
        private List<ProjectType> projectTypes;
        private List<Employee> employees;

        public ProjectForm(Form owner)
        {
            this.owner = owner;

            InitializeComponent();
            SetAll();
            InitializeFormWithoutData();
        }

        public ProjectForm(Form owner, ProjectVM projectVM)
        {
            this.owner = owner;

            if (projectVM is null)
            {
                MessageBox.Show("Цей запис чомусь дорівнює нулю");
                Close();
            }
            this.projectVM = projectVM;

            InitializeComponent();
            SetAll();
            InitializeFormWithData();
        }

        private void CloseButton_Click(object sender, EventArgs e)
            => Close();

        private void SetAll()
        {
            SetRoleConstraints();
            SetProjectTypesList();
            SetEmployeesList();
        }

        #region [Set Lists]

        void SetProjectTypesList()
        {
            projectTypes = CrudService.Get_ProjectTypes();
            ProjectTypeComboBox.DataSource = projectTypes
                .Select(pt => pt.ProjectTypeName)
                .ToList();
        }

        void SetEmployeesList()
        {
            employees = CrudService.Get_Employees();
            PMComboBox.DataSource = employees
                .Select(e => $"{e.EmployeeId}. {e.FullName}")
                .ToList();
        }

        #endregion

        #region [Initialize Form]

        void InitializeFormWithData()
        {
            IdLabel.Text = projectVM.Id.ToString();

            IdTextBox.Text = projectVM.Id.ToString();
            PMComboBox.SelectedIndex = (int)projectVM.ProjectManagerId - 1;
            StatusTextBox.Text = projectVM.Status.ToString();
            ProjectTypeComboBox.SelectedIndex = (int)projectVM.ProjectTypeId - 1;
            StartDateTimePicker.Value = projectVM.StartDate;

            if (projectVM.EndDate is null)
                EndDateTimePicker.Checked = false;
            else
            {
                EndDateTimePicker.Checked = true;
                EndDateTimePicker.Value = (DateTime)projectVM.EndDate;
            }
            CommentTextBox.Text = projectVM.Comment;
        }

        void InitializeFormWithoutData()
        {
            IdLabel.Text = "*NEW*";

            IdTextBox.Text = "-";
            StatusTextBox.Text = "New";

            //In case of adding necessary to fill textBox(-es)
            //ActivateButton.Enabled = false;
            //DeactivateButton.Enabled = false;
        }

        #endregion

        #region [Set Role Constraints]

        private void SetRoleConstraints()
        {
            if (owner is not ProjectManagerForm)
            {
                foreach (var control in Controls)
                {
                    if (control != CloseButton)
                    {
                        //TODO - fix
                        //control.Enabled = false;
                    }
                }
                ReadOnly_Constraint();
            }
        }

        private void ReadOnly_Constraint()
        {
            ProjectTypeComboBox.Enabled = false;
            PMComboBox.Enabled = false;
            StartDateTimePicker.Enabled = false;
            EndDateTimePicker.Enabled = false;
            CommentTextBox.Enabled = false;

            ActivateButton.Enabled = false;
            CreateNewOrUpdateButton.Enabled = false;
            DeactivateButton.Enabled = false;
        }

        #endregion

        #region [Activata & Deactivate Project]

        private void ActivateButton_Click(object sender, EventArgs e)
        {
            _ = AddOrUpdateWithDataFromForm(StatusEnum.Active);
            Close();
        }

        private void DeactivateButton_Click(object sender, EventArgs e)
        {
            _ = AddOrUpdateWithDataFromForm(StatusEnum.Inactive);
            Close();
        }

        long AddOrUpdateWithDataFromForm(StatusEnum stat)
        {
            var proj = ParseDataFromForm(stat);

            long id = -1;
            if (projectVM is not null)
            {
                proj.ProjectId = projectVM.Id;
                CrudService.Update_Project(proj);
            }
            else
                id = CrudService.Add_Project(proj);

            return id;
        }

        Project ParseDataFromForm(StatusEnum stat)
        {
            DateTime? endDate = (EndDateTimePicker.Checked)
                ? EndDateTimePicker.Value
                : null;

            var proj = new Project
            {
                ProjectTypeId = ProjectTypeComboBox.SelectedIndex + 1,
                StartDate = StartDateTimePicker.Value,
                EndDate = endDate,
                ProjectManagerId = PMComboBox.SelectedIndex + 1,
                Comment = string.IsNullOrWhiteSpace(CommentTextBox.Text) ? null : CommentTextBox.Text,
                StatusId = (long)stat
            };

            return proj;
        }

        #endregion

        private void IdTextBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Скасувати введення символу
                e.Handled = true;
            }
        }

        private void CreateNewOrUpdateButton_Click(object sender, EventArgs e)
        {
            //TODO - add functionality
        }
    }
}
