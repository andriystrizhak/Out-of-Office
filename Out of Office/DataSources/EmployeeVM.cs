using OutOfOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Out_of_Office.DataSources
{
    public class EmployeeVM
    {
        public long Id { get; set; }
        public string FullName { get; set; } = null!;
        public long SubdivisionId { get; set; }
        public string Subdivision { get; set; } = null!;
        public long PositionId { get; set; }
        public string Position { get; set; } = null!;
        public long StatusId { get; set; }
        public string Status { get; set; } = null!;
        public long PeoplePartnerId { get; set; }
        public string PeoplePartnerName { get; set;} = null!;
        public double OutOfOfficeBalance { get; set; }
        public long? PhotoId { get; set; }
        public string? PhotoPath { get; set;}

        public static EmployeeVM FromEntity(Employee entity)
        {
            return new EmployeeVM
            {
                Id = entity.EmployeeId,
                FullName = entity.FullName,
                SubdivisionId = entity.SubdivisionId,
                Subdivision = entity.Subdivision.SubdivisionName,
                PositionId = entity.PositionId,
                Position = entity.Position.PositionName,
                StatusId = entity.StatusId,
                Status = entity.Status.StatusName,
                PeoplePartnerId = entity.PeoplePartnerId,
                PeoplePartnerName = entity.PeoplePartner.FullName,
                OutOfOfficeBalance = entity.OutOfOfficeBalance,
                PhotoId = entity.PhotoId,
                PhotoPath = (entity.Photo is not null) ? entity.Photo.FilePath : null
            };
        }

        public static List<EmployeeVM> FromEntities(List<Employee> entities)
        {
            return entities.Select(FromEntity).ToList();
        }
    }
}
