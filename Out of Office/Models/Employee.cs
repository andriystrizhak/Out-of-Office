using Out_of_Office.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.Models
{
    public partial class Employee
    {
        public Employee()
        {
            ApprovalRequests = new HashSet<ApprovalRequest>();
            InversePeoplePartner = new HashSet<Employee>();
            LeaveRequests = new HashSet<LeaveRequest>();
            Projects = new HashSet<Project>();
            EmployeeProjects = new HashSet<EmployeeProject>();  
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EmployeeId { get; set; }
        public string FullName { get; set; } = null!;
        public long SubdivisionId { get; set; }
        public long PositionId { get; set; }
        public long StatusId { get; set; }
        public long PeoplePartnerId { get; set; }
        public double OutOfOfficeBalance { get; set; }
        public long? PhotoId { get; set; }

        public virtual Employee PeoplePartner { get; set; } = null!;
        public virtual Photo? Photo { get; set; }
        public virtual Position Position { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual Subdivision Subdivision { get; set; } = null!;
        public virtual ICollection<ApprovalRequest> ApprovalRequests { get; set; }
        public virtual ICollection<Employee> InversePeoplePartner { get; set; }
        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
