using OutOfOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.DataSources
{
    public class ApprovalRequestVM
    {
        public long Id { get; set; }
        public long ApproverId { get; set; }
        public string ApproverName { get; set; } = null!;
        public long LeaveRequestId { get; set; }
        public long StatusId { get; set; }
        public string Status { get; set; } = null!;
        public string? Comment { get; set; }

        public static ApprovalRequestVM FromEntity(ApprovalRequest entity)
        {
            return new ApprovalRequestVM
            {
                Id = entity.ApprovalRequestId,
                ApproverId = entity.ApproverId,
                ApproverName = entity.Approver.FullName,
                LeaveRequestId = entity.LeaveRequestId,
                StatusId = entity.StatusId,
                Status = entity.Status.LeaveStatusName,
                Comment = entity.Comment
            };
        }

        public static List<ApprovalRequestVM> FromEntities(List<ApprovalRequest> entities)
        {
            return entities.Select(FromEntity).ToList();
        }
    }
}
