using System;
using System.Collections.Generic;

namespace OutOfOffice.Models
{
    public partial class Status
    {
        public Status()
        {
            Employees = new HashSet<Employee>();
            Projects = new HashSet<Project>();
        }

        public long StatusId { get; set; } = (long)StatusEnum.Active;
        public string StatusName { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }

    public enum StatusEnum
    {
        Active = 1,
        Inactive
    }
}
