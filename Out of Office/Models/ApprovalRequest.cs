using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.Models
{
    public partial class ApprovalRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ApprovalRequestId { get; set; }
        public long ApproverId { get; set; }
        public long LeaveRequestId { get; set; }
        public long StatusId { get; set; } = (long)LeaveStatusEnum.New;
        public string? Comment { get; set; }

        public virtual Employee Approver { get; set; } = null!;
        public virtual LeaveRequest LeaveRequest { get; set; } = null!;
        public virtual LeaveStatus Status { get; set; } = null!;
    }
}
