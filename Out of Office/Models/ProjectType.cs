using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.Models
{
    public partial class ProjectType
    {
        public ProjectType()
        {
            Projects = new HashSet<Project>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProjectTypeId { get; set; }
        public string ProjectTypeName { get; set; } = null!;

        public virtual ICollection<Project> Projects { get; set; }
    }
}
