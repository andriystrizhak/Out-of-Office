using System;
using System.Collections.Generic;

namespace OutOfOffice.Models
{
    public partial class Subdivision
    {
        public Subdivision()
        {
            Employees = new HashSet<Employee>();
        }

        public long SubdivisionId { get; set; }
        public string SubdivisionName { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
