using Out_of_Office.Models;
using System;
using System.Collections.Generic;

namespace OutOfOffice.Models
{
    public partial class Project
    {
        public Project()
        {
            EmployeeProjects = new HashSet<EmployeeProject>();
        }

        public long ProjectId { get; set; }
        public long ProjectTypeId { get; set; }
        public byte[] StartDate { get; set; } = null!;
        public byte[]? EndDate { get; set; }
        public long ProjectManagerId { get; set; }
        public string? Comment { get; set; }
        public long StatusId { get; set; } = 1;

        public virtual Employee ProjectManager { get; set; } = null!;
        public virtual ProjectType ProjectType { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
