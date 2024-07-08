using OutOfOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.Models
{
    public class EmployeeProject
    {
        public long EmployeeId { get; set; }
        public long ProjectId { get; set; }

        public Employee Employee { get; set; } = null!;
        public Project Project { get; set; } = null!;
    }
}
