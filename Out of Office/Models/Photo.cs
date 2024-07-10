using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OutOfOffice.Models
{
    public partial class Photo
    {
        public Photo()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PhotoId { get; set; }
        public string FilePath { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
