using System;
using System.Collections.Generic;

namespace OutOfOffice.Models
{
    public partial class LeaveRequest
    {
        public LeaveRequest()
        {
            ApprovalRequests = new HashSet<ApprovalRequest>();
        }

        public long LeaveRequestId { get; set; }
        public long EmployeeId { get; set; }
        public long AbsenceReasonId { get; set; }
        public byte[] StartDate { get; set; } = null!;
        public byte[] EndDate { get; set; } = null!;
        public string? Comment { get; set; }
        public long Status { get; set; }

        public virtual AbsenceReason AbsenceReason { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
        public virtual LeaveStatus StatusNavigation { get; set; } = null!;
        public virtual ICollection<ApprovalRequest> ApprovalRequests { get; set; }
    }
}
