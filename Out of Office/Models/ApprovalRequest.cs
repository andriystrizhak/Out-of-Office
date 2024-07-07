﻿using System;
using System.Collections.Generic;

namespace OutOfOffice.Models
{
    public partial class ApprovalRequest
    {
        public long ApprovalRequestId { get; set; }
        public long ApproverId { get; set; }
        public long LeaveRequestId { get; set; }
        public long StatusId { get; set; }
        public string? Comment { get; set; }

        public virtual Employee Approver { get; set; } = null!;
        public virtual LeaveRequest LeaveRequest { get; set; } = null!;
        public virtual LeaveStatus Status { get; set; } = null!;
    }
}