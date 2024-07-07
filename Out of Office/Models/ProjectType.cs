using System;
using System.Collections.Generic;

namespace OutOfOffice.Models
{
    public partial class ProjectType
    {
        public ProjectType()
        {
            Projects = new HashSet<Project>();
        }

        public long ProjectTypeId { get; set; }
        public string ProjectTypeName { get; set; } = null!;

        public virtual ICollection<Project> Projects { get; set; }
    }
}
