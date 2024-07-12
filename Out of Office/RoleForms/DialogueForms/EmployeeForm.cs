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
    public partial class EmployeeForm : Form
    {
        private Form owner;
        private EmployeeVM? employeeVM = null;
        private List<Subdivision> subdivisions;
        private List<Position> positions;
        private List<Employee> HRManagers;

        public EmployeeForm(Form owner)
        {
            this.owner = owner;

            InitializeComponent();
            SetSubdivisionsList();
            SetHRManagersList();
            InitializeFormWithoutData();
        }

        public EmployeeForm(Form owner, EmployeeVM employeeVM)
        {
            this.owner = owner;

            if (employeeVM is null)
            {
                MessageBox.Show("Цей запис чомусь дорівнює нулю");
                Close();
            }
            this.employeeVM = employeeVM;

            InitializeComponent();
            SetSubdivisionsList();
            SetHRManagersList();
            InitializeFormWithData();
        }


        #region [Set Lists]

        void SetSubdivisionsList()
        {
            subdivisions = CrudService.Get_Subdivisions();
            ProjectTypeComboBox.DataSource = subdivisions
                .Select(pt => pt.SubdivisionName)
                .ToList();
        }

        void SetPositionsList()
        {
            positions = CrudService.Get_Positions();
            PMComboBox.DataSource = positions
                .Select(e => e.PositionName)
                .ToList();
        }

        void SetHRManagersList()
        {
            HRManagers = CrudService.Get_HRManagers();
            PMComboBox.DataSource = HRManagers
                .Select(e => $"{e.EmployeeId}. {e.FullName}")
                .ToList();
        }

        #endregion

        #region [Initialize Form]

        void InitializeFormWithData()
        {
            IdLabel.Text = employeeVM.Id.ToString();

            IdTextBox.Text = employeeVM.Id.ToString();
            PMComboBox.SelectedIndex = (int)employeeVM.ProjectManagerId - 1;
            StatusTextBox.Text = employeeVM.Status.ToString();
            ProjectTypeComboBox.SelectedIndex = (int)employeeVM.ProjectTypeId - 1;
            StartDateTimePicker.Value = employeeVM.StartDate;

            if (employeeVM.EndDate is null)
                EndDateTimePicker.Checked = false;
            else
            {
                EndDateTimePicker.Checked = true;
                EndDateTimePicker.Value = (DateTime)employeeVM.EndDate;
            }
            CommentTextBox.Text = employeeVM.Comment;
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
            if (employeeVM is not null)
            {
                proj.ProjectId = employeeVM.Id;
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

        private void CloseButton_Click(object sender, EventArgs e)
            => Close();

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
