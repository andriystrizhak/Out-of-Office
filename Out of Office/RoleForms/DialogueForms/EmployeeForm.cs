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
    public partial class EmployeeForm : Form
    {
        private string defaultPhotoPath = "Resources\\unknown.jpg";

        private Form owner;
        private EmployeeVM? employeeVM = null;
        private List<Subdivision> subdivisions;
        private List<Position> positions;
        private List<Employee> HRManagers;

        public EmployeeForm(Form owner)
        {
            this.owner = owner;

            InitializeComponent();
            SetAll();
            InitializeFormWithoutData();
            FullNameTextBox.TextChanged += Control_DataChanged;
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
            SetAll();
            InitializeFormWithData();
        }

        private void CloseButton_Click(object sender, EventArgs e)
            => Close();

        private void SetAll()
        {
            SetRoleConstraints();
            SetLists();
        }

        #region [Set Lists]

        void SetLists()
        {
            SetSubdivisionsList();
            SetPositionsList();
            SetHRManagersList();
        }

        void SetSubdivisionsList()
        {
            subdivisions = CrudService.Get_Subdivisions();
            SubdivisionComboBox.DataSource = subdivisions
                .Select(pt => pt.SubdivisionName)
                .ToList();
        }

        void SetPositionsList()
        {
            positions = CrudService.Get_Positions();
            PositionComboBox.DataSource = positions
                .Select(e => e.PositionName)
                .ToList();
        }

        void SetHRManagersList()
        {
            HRManagers = CrudService.Get_HRManagers();
            PeoplePartnerComboBox.DataSource = HRManagers
                .Select(e => $"{e.EmployeeId}. {e.FullName}")
                .ToList();
        }

        #endregion

        #region [Initialize Form]

        void InitializeFormWithData()
        {
            IdLabel.Text = employeeVM.Id.ToString();

            IdTextBox.Text = employeeVM.Id.ToString();
            StatusTextBox.Text = employeeVM.Status;
            FullNameTextBox.Text = employeeVM.FullName;
            SubdivisionComboBox.SelectedIndex = (int)employeeVM.SubdivisionId - 1;
            PositionComboBox.SelectedIndex = (int)employeeVM.PositionId - 1;

            var currentHR = HRManagers
                .First(hr => hr.EmployeeId == employeeVM.PeoplePartnerId);
            if (currentHR is null)
                throw new Exception($"HR Manager with Id: {employeeVM.PeoplePartnerId} not found");

            PeoplePartnerComboBox.SelectedIndex = HRManagers.IndexOf(currentHR);
            OOOBalanceNumericUpDown.Value = (decimal)employeeVM.OutOfOfficeBalance;

            PhotoPictureBox.Image = Image.FromFile(employeeVM.PhotoPath ?? defaultPhotoPath);
        }

        void InitializeFormWithoutData()
        {
            IdLabel.Text = "*NEW*";

            IdTextBox.Text = "-";
            StatusTextBox.Text = "New";

            ActivateButton.Enabled = false;
            DeactivateButton.Enabled = false;
        }

        #endregion

        #region [Set Role Constraints]

        private void SetRoleConstraints()
        {
            if (owner is not HRManagerForm)
            {
                foreach (Control control in Controls)
                    if (control != CloseButton)
                        control.Enabled = false;
            }
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
            var empl = ParseDataFromForm(stat);

            long id = -1;
            if (employeeVM is not null)
            {
                empl.EmployeeId = employeeVM.Id;
                CrudService.Update_Employee(empl);
            }
            else
                id = CrudService.Add_Employee(empl);

            return id;
        }

        Employee ParseDataFromForm(StatusEnum stat)
        {
            string? photoPath = (PhotoPictureBox.ImageLocation != defaultPhotoPath) 
                ? PhotoPictureBox.ImageLocation 
                : null;
            long? photoId = (photoPath is not null) 
                ? CrudService.Add_Photo(new Photo { FilePath = photoPath }) 
                : null;

            var empl = new Employee
            {
                FullName = FullNameTextBox.Text,
                SubdivisionId = SubdivisionComboBox.SelectedIndex + 1,
                PositionId = PositionComboBox.SelectedIndex + 1,
                StatusId = (long)stat,
                PeoplePartnerId = HRManagers[PeoplePartnerComboBox.SelectedIndex].EmployeeId,
                OutOfOfficeBalance = (double)OOOBalanceNumericUpDown.Value,
                PhotoId = photoId,
            };

            return empl;
        }

        #endregion

        private void Control_DataChanged(object sender, EventArgs e)
        {
            if (FullNameTextBox.Text == "")
            {
                ActivateButton.Enabled = false;
                DeactivateButton.Enabled = false;
            }
            else
            {
                ActivateButton.Enabled = true;
                DeactivateButton.Enabled = true;
            }
        }

        private void IdTextBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Скасувати введення символу
                e.Handled = true;
            }
        }

        private void PhotoPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
