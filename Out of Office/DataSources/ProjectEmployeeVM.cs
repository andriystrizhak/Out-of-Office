using Out_of_Office.Models;
using OutOfOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.DataSources
{
    public class ProjectEmployeeVM
    {
        public bool Assigned { get; set; }
        public long Id { get; set; }
        public string EmployeeName { get; set; } = null!;

        public static ProjectEmployeeVM FromEntity(Employee entity, long projId)
        {
            return new ProjectEmployeeVM
            {
                Assigned = CrudService.Is_EmployeeAssignedToProject(entity.EmployeeId, projId),
                Id = entity.EmployeeId,
                EmployeeName = entity.FullName
            };
        }

        public static List<ProjectEmployeeVM> FromEntities(List<Employee> entities, long projId)
        {
            return entities
                .Select(e => FromEntity(e, projId))
                .ToList();
        }

        public static List<ProjectEmployeeVM> Get_DifferenceToAdd(List<ProjectEmployeeVM> initial, List<ProjectEmployeeVM> changed)
        {
            var toAdd = new List<ProjectEmployeeVM>();

            for (int i = 0; i < changed.Count; i++)
            {
                if (changed[i].Assigned && initial[i].Assigned != changed[i].Assigned)
                    toAdd.Add(changed[i]);
            }

            return toAdd;
        }

        public static List<ProjectEmployeeVM> Get_DifferenceToRemove(List<ProjectEmployeeVM> initial, List<ProjectEmployeeVM> changed)
        {

            var toRemove = new List<ProjectEmployeeVM>();

            for (int i = 0; i < changed.Count; i++)
            {
                if (!changed[i].Assigned && initial[i].Assigned != changed[i].Assigned)
                    toRemove.Add(changed[i]);
            }

            return toRemove;
        }

        public static EmployeeProject ToEntity(ProjectEmployeeVM vm, long projId)
        {
            return new EmployeeProject
            {
                EmployeeId = vm.Id,
                ProjectId = projId
            };
        }

        public static List<EmployeeProject> ToEntities(List<ProjectEmployeeVM> vms, long projId)
        {
            return vms
                //.Where(vm => vm.Assigned)
                .Select(vm => ToEntity(vm, projId))
                .ToList();
        }
    }
}
