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
    public partial class ProjectsForm : Form
    {
        private Form owner;
        private ProjectVM? projectVM = null;
        private List<ProjectType> projectTypes;
        private List<Employee> employees;

        public ProjectsForm(Form owner)
        {
            this.owner = owner;

            InitializeComponent();
            SetProjectTypesList();
            SetEmployeesList();
            InitializeFormWithoutData();
        }

        public ProjectsForm(Form owner, ProjectVM projectVM)
        {
            this.owner = owner;

            if (projectVM is null)
            {
                MessageBox.Show("Цей запис чомусь дорівнює нулю");
                Close();
            }
            this.projectVM = projectVM;

            InitializeComponent();
            SetProjectTypesList();
            SetEmployeesList();
            InitializeFormWithData();
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

            CreateNewOrUpdateButton.Text = "Create new";
            ActivateButton.Enabled = false;
            DeactivateButton.Enabled = false;
        }

        #endregion

        private void CreateNewOrUpdateButton_Click(object sender, EventArgs e)
        {
            if (projectVM is null)
            {
                long id = AddNewPFromForm(StatusEnum.Active);

                IdLabel.Text = id.ToString();
                IdTextBox.Text = id.ToString();
            }
            else
            {
                UpdateLRFromForm((StatusEnum)(int)(projectVM.StatusId));
            }

            CreateNewOrUpdateButton.Enabled = false;
            CreateNewOrUpdateButton.Text = "Update";

            ActivateButton.Enabled = true;
            DeactivateButton.Enabled = true;
        }

        /// <summary>
        /// Adds new Project to BD and updates 'projectVM' field
        /// </summary>
        /// <param name="stat">State of created Project</param>
        /// <returns>Id of new Project in DB</returns>
        long AddNewPFromForm(StatusEnum stat)
        {
            var proj = ParseDataFromForm(stat);
            projectVM = ProjectVM.FromEntity(proj);

            long id = CrudService.Add_LeaveRequest(proj);
            return id;
        }


        private void SubmitButton_Click(object sender, EventArgs e)
        {
            AddOrUpdateWithDataFromForm(StatusEnum.Active);
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            AddOrUpdateWithDataFromForm(StatusEnum.Inactive);
            Close();
        }

        long UpdateLRFromForm(StatusEnum stat)
        {
            long id = long.Parse(IdTextBox.Text);
            var leaveReq = ParseDataFromForm(stat);
            leaveReq.LeaveRequestId = id;

            CrudService.Update_LeaveRequest(leaveReq);
            return id;
        }

        Project ParseDataFromForm(StatusEnum stat)
        {
            var leaveReq = new Project //TODO - improve
            {
                EmployeeId = EmployeeComboBox.SelectedIndex + 1,
                AbsenceReasonId = AbsenceReasonComboBox.SelectedIndex + 1,
                StartDate = StartDateTimePicker.Value,
                EndDate = EndDateTimePicker.Value,
                Comment = string.IsNullOrWhiteSpace(CommentTextBox.Text) ? null : CommentTextBox.Text,
                Status = (long)stat
            };

            return leaveReq;
        }

        void AddOrUpdateWithDataFromForm(StatusEnum stat)
        {
            //TODO - CHANGE
            var leaveReq = new LeaveRequest
            {
                EmployeeId = PMComboBox.SelectedIndex + 1,
                AbsenceReasonId = ProjectTypeComboBox.SelectedIndex + 1,
                StartDate = StartDateTimePicker.Value,
                EndDate = EndDateTimePicker.Value,
                Comment = string.IsNullOrWhiteSpace(CommentTextBox.Text) ? null : CommentTextBox.Text,
                Status = (long)stat
            };

            long id = -1;
            if (long.TryParse(IdTextBox.Text, out id))
            {
                leaveReq.LeaveRequestId = id;
                CrudService.Update_LeaveRequest(leaveReq);
            }
            else
                CrudService.Add_LeaveRequest(leaveReq);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void IdTextBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Скасувати введення символу
                e.Handled = true;
            }
        }
    }
}
