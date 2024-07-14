using Out_of_Office.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.DataSources
{
    public class EmployeeProjectVM
    {
        public bool IsAssigned { get; set; }
        public long Id { get; set; }
        public string ProjectName { get; set; } = null!;

        public static EmployeeProjectVM FromEntity(EmployeeProject entity, long id)
        {
            return new EmployeeProjectVM
            {
                IsAssigned = entity.EmployeeId == id,
                Id = entity.ProjectId,
                ProjectName = entity.Project.ProjectName
            };
        }

        public static EmployeeProject ToEntity(EmployeeProjectVM vm, long id)
        {
            return new EmployeeProject
            {
                ProjectId = vm.Id
            };
        }
    }
}
