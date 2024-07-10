using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.Models
{
    public partial class AbsenceReason
    {
        public AbsenceReason()
        {
            LeaveRequests = new HashSet<LeaveRequest>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AbsenceReasonId { get; set; }
        public string AbsenceReasonName { get; set; } = null!;

        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }
    }
}
