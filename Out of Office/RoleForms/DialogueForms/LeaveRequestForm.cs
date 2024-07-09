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
    public partial class LeaveRequestForm : Form
    {
        private Form owner;
        private LeaveRequestVM? requestVM;
        private List<AbsenceReason> absenceReasons;

        public LeaveRequestForm(Form owner)
        {
            this.owner = owner;
            this.requestVM = null;

            InitializeComponent();
            SetAbsenceReasonList();
            InitializeFormWithoutData();
        }

        public LeaveRequestForm(Form owner, LeaveRequestVM requestVM)
        {
            this.owner = owner;
            this.requestVM = requestVM;

            InitializeComponent();
            SetAbsenceReasonList();
            InitializeFormWithData();
        }

        void SetAbsenceReasonList()
        {
            absenceReasons = CrudService.Get_AbsenceReasons();
            AbsenceReasonComboBox.DataSource = absenceReasons
                .Select(c => c.AbsenceReasonName)
                .ToList();
        }

        void InitializeFormWithData()
        {
            IdLabel.Text = requestVM.Id.ToString();

            IdTextBox.Text = requestVM.Id.ToString();
            EmployeeIdTextBox.Text = requestVM.EmployeeId.ToString();
            EmployeeNameTextBox.Text = requestVM.EmployeeName;
            StatusTextBox.Text = requestVM.Status.ToString();
            AbsenceReasonComboBox.SelectedIndex = (int)requestVM.AbsenceReasonId - 1;
            StartDateTimePicker.Value = requestVM.StartDate;
            EndDateTimePicker.Value = requestVM.EndDate;
            CommentTextBox.Text = requestVM.Comment;
        }

        void InitializeFormWithoutData()
        {
            IdLabel.Text = "*NEW*";

            IdTextBox.Text = "-";
            StatusTextBox.Text = "New";
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            var req = ParseDataFromForm(LeaveStatusEnum.Submitted);

            if (requestVM is null)
                CrudService.Add_LeaveRequest(req); //TODO - баг з додаванням ново запиту до БД
            else
                CrudService.Update_LeaveRequest(req);

            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            var req = ParseDataFromForm(LeaveStatusEnum.Cancelled);

            if (requestVM is null)
                CrudService.Add_LeaveRequest(req);
            else
                CrudService.Update_LeaveRequest(req);

            Close();
        }

        LeaveRequest ParseDataFromForm(LeaveStatusEnum stat)
        {
            long id = 0;
            _ = long.TryParse(IdTextBox.Text, out id);
            var leaveRequest = new LeaveRequest
            {
                LeaveRequestId = id,
                EmployeeId = long.Parse(EmployeeIdTextBox.Text),
                AbsenceReasonId = AbsenceReasonComboBox.SelectedIndex + 1,
                StartDate = StartDateTimePicker.Value,
                EndDate = EndDateTimePicker.Value,
                Comment = string.IsNullOrWhiteSpace(CommentTextBox.Text) ? null : CommentTextBox.Text,
                Status = (long)stat
            };

            return leaveRequest;
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
