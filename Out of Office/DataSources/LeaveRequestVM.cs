using OutOfOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.DataSources
{
    public class LeaveRequestVM
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string AbsenceReason { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Comment { get; set; }
        public string Status { get; set; } = null!;

        public static LeaveRequestVM FromEntity(LeaveRequest entity)
        {
            return new LeaveRequestVM
            {
                Id = entity.LeaveRequestId,
                EmployeeId = entity.EmployeeId,
                EmployeeName = entity.Employee.FullName,
                AbsenceReason = entity.AbsenceReason.AbsenceReasonName,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Comment = entity.Comment,
                Status = entity.StatusNavigation.LeaveStatusName
            };
        }

        public static List<LeaveRequestVM> FromEntities(List<LeaveRequest> entities)
        {
            return entities.Select(FromEntity).ToList();
        }

    }
}
