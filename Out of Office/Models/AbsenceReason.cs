using System;
using System.Collections.Generic;

namespace OutOfOffice.Models
{
    public partial class AbsenceReason
    {
        public AbsenceReason()
        {
            LeaveRequests = new HashSet<LeaveRequest>();
        }

        public long AbsenceReasonId { get; set; }
        public string AbsenceReasonName { get; set; } = null!;

        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }
    }
}
