using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutOfOffice.Models;

namespace Out_of_Office.DataSources
{
    public class ProjectVM
    {
        public long Id { get; set; }
        public long ProjectTypeId { get; set; }
        public string ProjectType { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long ProjectManagerId { get; set; }
        public string ProjectManagerName { get; set; } = null!;
        public string? Comment { get; set; }
        public long StatusId { get; set; }
        public string Status { get; set; } = null!;

        public static ProjectVM FromEntity(Project entity)
        {
            return new ProjectVM
            {
                Id = entity.ProjectId,
                ProjectTypeId = entity.ProjectTypeId,
                ProjectType = entity.ProjectType.ProjectTypeName,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                ProjectManagerId = entity.ProjectManagerId,
                ProjectManagerName = entity.ProjectManager.FullName,
                Comment = entity.Comment,
                StatusId = entity.StatusId,
                Status = entity.Status.StatusName
            };
        }

        public static List<ProjectVM> FromEntities(List<Project> entities)
        {
            return entities.Select(FromEntity).ToList();
        }
    }
}
