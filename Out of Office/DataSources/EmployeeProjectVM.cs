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

        public static List<EmployeeProjectVM> FromEntities(List<EmployeeProject> entities, long id)
        {
            return entities.Select(e => FromEntity(e, id)).ToList();
        }

        public static EmployeeProject ToEntity(EmployeeProjectVM vm, long id)
        {
            return new EmployeeProject
            {
                EmployeeId = id,
                ProjectId = vm.Id
            };
        }

        public static List<EmployeeProject> ToEntities(List<EmployeeProjectVM> vms, long id)
        {
            return vms.Where(vm => vm.IsAssigned).Select(vm => ToEntity(vm, id)).ToList();
        }
    }
}
