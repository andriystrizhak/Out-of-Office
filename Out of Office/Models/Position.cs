using System;
using System.Collections.Generic;

namespace OutOfOffice.Models
{
    public partial class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }

        public long PositionId { get; set; }
        public string PositionName { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
