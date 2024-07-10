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
        private ProjectVM? projectVM;
        private List<ProjectType> projectTypes;
        private List<Employee> employees;

        public ProjectsForm(Form owner)
        {
            this.owner = owner;
            this.projectVM = null;

            InitializeComponent();
            SetProjectTypesList();
            SetEmployeesList();
            InitializeFormWithoutData();
        }

        public ProjectsForm(Form owner, ProjectVM requestVM)
        {
            this.owner = owner;
            this.projectVM = requestVM;

            InitializeComponent();
            SetProjectTypesList();
            SetEmployeesList();
            InitializeFormWithData();
        }

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

        void InitializeFormWithData()
        {
            IdLabel.Text = projectVM.Id.ToString();

            IdTextBox.Text = projectVM.Id.ToString();
            PMComboBox.SelectedIndex = (int)projectVM.ProjectManagerId - 1;
            StatusTextBox.Text = projectVM.Status.ToString();
            ProjectTypeComboBox.SelectedIndex = (int)projectVM.ProjectTypeId - 1;
            StartDateTimePicker.Value = projectVM.StartDate;
            // TODO - вирішити це
            //EndDateTimePicker.Value = projectVM.EndDate; 
            CommentTextBox.Text = projectVM.Comment;
        }

        void InitializeFormWithoutData()
        {
            IdLabel.Text = "*NEW*";

            IdTextBox.Text = "-";
            StatusTextBox.Text = "New";
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

        void AddOrUpdateWithDataFromForm(StatusEnum stat)
        {
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
