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
            employees = CrudService.Get_ProjectManager();
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
            ProjectNameTextBox.Text = projectVM.Name;
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

            CreateNewOrUpdateButton.Text = "Update";
            CreateNewOrUpdateButton.Enabled = false;
        }

        void InitializeFormWithoutData()
        {
            IdLabel.Text = "*NEW*";

            IdTextBox.Text = "-";
            StatusTextBox.Text = "New";

            CreateNewOrUpdateButton.Text = "Create new";
            ActivateButton.Enabled = false;
            DeactivateButton.Enabled = false;
            SelectEmplButton.Enabled = false;
        }

        #endregion

        #region [Set Role Constraints]

        private void SetRoleConstraints()
        {
            if (owner is not ProjectManagerForm)
            {
                foreach (Control control in Controls)
                    if (control != CloseButton)
                        control.Enabled = false;
            }
        }

        #endregion

        #region [Create new Project]

        private void CreateNewOrUpdateButton_Click(object sender, EventArgs e)
        {
            if (projectVM is null)
            {
                long id = AddNewProjectFromForm(StatusEnum.Active);

                IdLabel.Text = id.ToString();
                IdTextBox.Text = id.ToString();
            }
            else
            {
                AddOrUpdateWithDataFromForm((StatusEnum)(int)(projectVM.StatusId));
            }

            CreateNewOrUpdateButton.Enabled = false;
            CreateNewOrUpdateButton.Text = "Update";

            ActivateButton.Enabled = true;
            DeactivateButton.Enabled = true;
            SelectEmplButton.Enabled = true;
        }

        /// <summary>
        /// Adds new Project to BD and updates 'requestVM' field
        /// </summary>
        /// <param name="stat">State of created Project</param>
        /// <returns>Id of new Project in DB</returns>
        long AddNewProjectFromForm(StatusEnum stat)
        {
            var proj = ParseDataFromForm(stat);
            long id = CrudService.Add_Project(proj);

            var fullProj = CrudService.Get_Project(id);
            projectVM = ProjectVM.FromEntity(fullProj);

            return id;
        }

        #endregion

        #region [Activate & Deactivate Project]

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
                ProjectName = ProjectNameTextBox.Text,
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

        private void Control_DataChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProjectNameTextBox.Text))
                CreateNewOrUpdateButton.Enabled = false;
            else
                CreateNewOrUpdateButton.Enabled = true;
        }

        private void IdTextBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Скасувати введення символу
                e.Handled = true;
            }
        }

        private void EmployeesButton_Click(object sender, EventArgs e)
        {
            new ProjectEmployeesForm(projectVM.Id).ShowDialog();
        }
    }
}
