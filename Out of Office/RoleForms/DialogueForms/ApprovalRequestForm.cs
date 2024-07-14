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
    public partial class ApprovalRequestForm : Form
    {
        private Form owner;
        private ApprovalRequestVM? appRequestVM = null;
        private List<Employee> employees;

        public ApprovalRequestForm(Form owner, ApprovalRequestVM appRequestVM)
        {
            this.owner = owner;

            if (appRequestVM is null)
            {
                MessageBox.Show("Цей запис чомусь дорівнює нулю");
                Close();
            }
            this.appRequestVM = appRequestVM;

            InitializeComponent();
            SetAll();
            InitializeFormWithData();
        }

        private void CloseButton_Click(object sender, EventArgs e)
            => Close();

        private void SetAll()
        {
            SetRoleConstraints();
            SetEmployeeList();
        }

        #region [Set List]

        void SetEmployeeList()
        {
            employees = CrudService.Get_Employees();
            ApproverComboBox.DataSource = employees
                .Select(e => $"{e.EmployeeId}. {e.FullName}")
                .ToList();
        }

        #endregion

        #region [Initialize Form]

        void InitializeFormWithData()
        {
            IdLabel.Text = appRequestVM.Id.ToString();

            IdTextBox.Text = appRequestVM.Id.ToString();
            StatusTextBox.Text = appRequestVM.Status;
            ApproverComboBox.SelectedIndex = (int)appRequestVM.ApproverId - 1;
            CommentTextBox.Text = appRequestVM.Comment;
        }

        #endregion

        #region [Set Role Constraints]

        private void SetRoleConstraints()
        {
            if (owner is not HRManagerForm 
                && owner is not ProjectManagerForm)
            {
                foreach (Control control in Controls)
                    if (control != CloseButton)
                        control.Enabled = false;
            }
        }

        #endregion

        #region [Approve & Reject Project]

        private void ApproveButton_Click(object sender, EventArgs e)
        {
            _ = UpdateWithDataFromForm(LeaveStatusEnum.Approved);

            var leaveReq = CrudService.Get_LeaveRequest(appRequestVM.LeaveRequestId);
            var empl = CrudService.Get_Employee(leaveReq.EmployeeId);
            var daysToSubtract = (leaveReq.EndDate - leaveReq.StartDate).TotalDays;
            empl.OutOfOfficeBalance -= daysToSubtract;

            CrudService.Update_LeaveRequest(leaveReq);

            Close();
        }

        private void RejectButton_Click(object sender, EventArgs e)
        {
            _ = UpdateWithDataFromForm(LeaveStatusEnum.Rejected);
            Close();
        }

        long UpdateWithDataFromForm(LeaveStatusEnum stat)
        {
            var appReq = ParseDataFromForm(stat);
            CrudService.Update_ApprovalRequest(appReq);

            return appReq.ApprovalRequestId;
        }

        ApprovalRequest ParseDataFromForm(LeaveStatusEnum stat)
        {
            var appReq = new ApprovalRequest
            {
                ApprovalRequestId = appRequestVM.Id,
                ApproverId = ApproverComboBox.SelectedIndex + 1,
                LeaveRequestId = appRequestVM.LeaveRequestId,
                StatusId = (long)stat,
                Comment = string.IsNullOrWhiteSpace(CommentTextBox.Text)
                    ? null : CommentTextBox.Text,
            };

            return appReq;
        }

        #endregion

        private void ShowLRDetailsButton_Click(object sender, EventArgs e)
        {
            var req = CrudService.Get_LeaveRequest(appRequestVM.LeaveRequestId);
            if (req is not null)
            {
                var reqVM = LeaveRequestVM.FromEntity(req);
                new LeaveRequestForm(this, reqVM).ShowDialog();
            }
            else
                MessageBox.Show("There's no Leave Request you are looking for(");
        }
    }
}
