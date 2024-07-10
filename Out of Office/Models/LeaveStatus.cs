using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.Models
{
    public partial class LeaveStatus
    {
        public LeaveStatus()
        {
            ApprovalRequests = new HashSet<ApprovalRequest>();
            LeaveRequests = new HashSet<LeaveRequest>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LeaveStatusId { get; set; }
        public string LeaveStatusName { get; set; } = null!;

        public virtual ICollection<ApprovalRequest> ApprovalRequests { get; set; }
        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }
    }

    public enum LeaveStatusEnum
    {
        New = 1,
        Approved,
        Rejected,
        Submitted,
        Cancelled
    }
}
