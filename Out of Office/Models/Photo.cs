using System;
using System.Collections.Generic;

namespace OutOfOffice.Models
{
    public partial class Photo
    {
        public Photo()
        {
            Employees = new HashSet<Employee>();
        }

        public long PhotoId { get; set; }
        public string FilePath { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
