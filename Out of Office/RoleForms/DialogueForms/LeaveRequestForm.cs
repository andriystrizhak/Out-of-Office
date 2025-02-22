﻿using Out_of_Office.DataSources;
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
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Out_of_Office.RoleForms.DialogueForms
{
    public partial class LeaveRequestForm : Form
    {
        private Form owner;
        private LeaveRequestVM? requestVM = null;
        private List<AbsenceReason> absenceReasons;
        private List<Employee> employees;


        public LeaveRequestForm(Form owner)
        {
            this.owner = owner;

            InitializeComponent();
            SetAll();
            InitializeFormWithoutData();
        }

        public LeaveRequestForm(Form owner, LeaveRequestVM requestVM)
        {
            this.owner = owner;

            if (requestVM is null)
            {
                MessageBox.Show("Цей запис чомусь дорівнює нулю");
                Close();
            }
            this.requestVM = requestVM;

            InitializeComponent();
            SetAll();
            InitializeFormWithData();
        }

        private void CloseButton_Click(object sender, EventArgs e)
            => Close();

        private void SetAll()
        {
            SetRoleConstraints();
            SetAbsenceReasonList();
            SetEmployeesList();
        }

        #region [Set Lists]

        void SetAbsenceReasonList()
        {
            absenceReasons = CrudService.Get_AbsenceReasons();
            AbsenceReasonComboBox.DataSource = absenceReasons
                .Select(c => c.AbsenceReasonName)
                .ToList();
        }

        void SetEmployeesList()
        {
            employees = CrudService.Get_Employees();
            EmployeeComboBox.DataSource = employees
                .Select(e => $"{e.EmployeeId}. {e.FullName}")
                .ToList();
        }

        #endregion

        #region [Initialize Form]

        void InitializeFormWithData()
        {
            IdLabel.Text = requestVM.Id.ToString();

            IdTextBox.Text = requestVM.Id.ToString();
            EmployeeComboBox.SelectedIndex = (int)requestVM.EmployeeId - 1;
            StatusTextBox.Text = requestVM.Status.ToString();
            AbsenceReasonComboBox.SelectedIndex = (int)requestVM.AbsenceReasonId - 1;
            StartDateTimePicker.Value = requestVM.StartDate;
            EndDateTimePicker.Value = requestVM.EndDate;
            CommentTextBox.Text = requestVM.Comment;

            CreateNewOrUpdateButton.Text = "Update";
            CreateNewOrUpdateButton.Enabled = false;
        }

        void InitializeFormWithoutData()
        {
            IdLabel.Text = "*NEW*";

            IdTextBox.Text = "-";
            StatusTextBox.Text = "New";

            CreateNewOrUpdateButton.Text = "Create new";
            SubmitButton.Enabled = false;
            CancelButton.Enabled = false;
        }

        #endregion

        #region [Set Role Constraints]

        private void SetRoleConstraints()
        {
            if (owner is not EmployeeRoleForm
                || (requestVM is not null
                && (requestVM.StatusId == (long)LeaveStatusEnum.Approved
                || requestVM.StatusId == (long)LeaveStatusEnum.Rejected)))
            {
                foreach (Control control in Controls)
                    if (control != CloseButton)
                        control.Enabled = false;
            }
        }

        #endregion

        #region [Create new LeaveRequest]

        private void CreateNewOrUpdateButton_Click(object sender, EventArgs e)
        {
            if (requestVM is null)
            {
                long id = AddNewLRFromForm(LeaveStatusEnum.New);

                IdLabel.Text = id.ToString();
                IdTextBox.Text = id.ToString();
            }
            else
            {
                UpdateLRFromForm((LeaveStatusEnum)(int)(requestVM.StatusId));
            }

            CreateNewOrUpdateButton.Enabled = false;
            CreateNewOrUpdateButton.Text = "Update";

            SubmitButton.Enabled = true;
            CancelButton.Enabled = true;
        }

        /// <summary>
        /// Adds new LeaveRequest to BD and updates 'requestVM' field
        /// </summary>
        /// <param name="stat">State of created LeaveRequest</param>
        /// <returns>Id of new LeaveRequest in DB</returns>
        long AddNewLRFromForm(LeaveStatusEnum stat)
        {
            var leaveReq = ParseDataFromForm(stat);
            long id = CrudService.Add_LeaveRequest(leaveReq);

            var fullLeaveReq = CrudService.Get_LeaveRequest(id);
            requestVM = LeaveRequestVM.FromEntity(fullLeaveReq);

            return id;
        }

        #endregion

        #region [Update current LeaveRequest]

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            var appReqId = UpdateLRFromForm(LeaveStatusEnum.Submitted);
            var leaveReq = CrudService.Get_LeaveRequest(appReqId);
            CrudService.Add_ApprovalRequest(new ApprovalRequest
            {
                ApproverId = leaveReq.EmployeeId,
                LeaveRequestId = appReqId,
                StatusId = (long)LeaveStatusEnum.New,
            });
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            var appReqId = UpdateLRFromForm(LeaveStatusEnum.Cancelled);
            _ = CrudService.Remove_ApprovalRequest(appReqId);
            Close();
        }

        long UpdateLRFromForm(LeaveStatusEnum stat)
        {
            long id = long.Parse(IdTextBox.Text);
            var leaveReq = ParseDataFromForm(stat);
            leaveReq.LeaveRequestId = id;

            CrudService.Update_LeaveRequest(leaveReq);
            return id;
        }

        #endregion

        LeaveRequest ParseDataFromForm(LeaveStatusEnum stat)
        {
            var leaveReq = new LeaveRequest
            {
                EmployeeId = EmployeeComboBox.SelectedIndex + 1,
                AbsenceReasonId = AbsenceReasonComboBox.SelectedIndex + 1,
                StartDate = StartDateTimePicker.Value,
                EndDate = EndDateTimePicker.Value,
                Comment = string.IsNullOrWhiteSpace(CommentTextBox.Text) 
                    ? null : CommentTextBox.Text,
                Status = (long)stat,
            };

            return leaveReq;
        }

        private void Control_DataChanged(object sender, EventArgs e)
        {
            CreateNewOrUpdateButton.Enabled = true;

            if (EndDateTimePicker.Value < StartDateTimePicker.Value)
            {
                CreateNewOrUpdateButton.Enabled = false;
                SubmitButton.Enabled = false;
                CancelButton.Enabled = false;
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
    }
}
