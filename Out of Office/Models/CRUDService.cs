using Microsoft.EntityFrameworkCore;
using Out_of_Office.DataSources;
using Out_of_Office.Models;
using Out_of_Office.Models.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOffice.Models
{
    public static class CrudService
    {
        /// <summary>
        /// Connection String (contains path to .db file)
        /// </summary>
        public static string CS { get; set; } = "Data Source=Database\\ListsDB.db";
        public static IListDbContextFactory dBContextFactory { get; set; } = new SQLiteListDbContextFactory(CS);

        #region [ Employee ]

        public static List<Employee> Get_Employees()
        {
            using var db = dBContextFactory.Create();

            var employee = db.Employees
                .Include(e => e.Subdivision)
                .Include(e => e.Position)
                .Include(e => e.Status)
                .Include(e => e.PeoplePartner)
                .Include(e => e.Photo)
                .ToList();

            return employee;
        }

        public static Employee? Get_Employee(long id)
        {
            using var db = dBContextFactory.Create();

            var employee = db.Employees
                .Include(e => e.Subdivision)
                .Include(e => e.Position)
                .Include(e => e.Status)
                .Include(e => e.PeoplePartner)
                .Include(e => e.Photo)
                .FirstOrDefault(e => e.EmployeeId == id);

            return employee;
        }

        public static List<Employee> Get_HRManagers()
        {
            using var db = dBContextFactory.Create();

            var employee = db.Employees
                .Include(e => e.Subdivision)
                .Include(e => e.Position)
                .Include(e => e.Status)
                .Include(e => e.PeoplePartner)
                .Include(e => e.Photo)
                .Where(e => e.Position.PositionName == "HR Manager")
                .ToList();

            return employee;
        }

        public static long Add_Employee(Employee emp)
        {
            using var db = dBContextFactory.Create();

            var id = db.Employees.Add(emp);
            db.SaveChanges();

            return id.Entity.EmployeeId;
        }

        public static void Update_Employee(Employee emp)
        {
            using var db = dBContextFactory.Create();

            db.Employees.Update(emp);
            db.SaveChanges();
        }

        public static bool Deactivate_Employee(long id)
        {
            using var db = dBContextFactory.Create();

            var emp = db.Employees.Find(id);
            if (emp is not null)
            {
                emp.StatusId = 2;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool Activate_Employee(long id)
        {
            using var db = dBContextFactory.Create();

            var emp = db.Employees.Find(id);
            if (emp is not null)
            {
                emp.StatusId = 1;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool Assign_Employee_ToProject(long empId, long projId)
        {
            using var db = dBContextFactory.Create();

            var emp = db.Employees.Find(empId);
            var proj = db.Projects.Find(projId);
            if (emp is not null && proj is not null)
            {
                db.EmployeeProjects.Add(new EmployeeProject { EmployeeId = empId, ProjectId = projId });
                db.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

        #region [ Project ]

        public static List<Project> Get_Projects()
        {
            using var db = dBContextFactory.Create();

            return db.Projects
                .Include(e => e.ProjectType)
                .Include(e => e.ProjectManager)
                .Include(e => e.Status)
                .ToList();
        }

        public static Project? Get_Project(long id)
        {
            using var db = dBContextFactory.Create();

            return db.Projects
                .Include(e => e.ProjectType)
                .Include(e => e.ProjectManager)
                .Include(e => e.Status)
                .FirstOrDefault(e => e.ProjectId == id);
        }

        public static long Add_Project(Project proj)
        {
            using var db = dBContextFactory.Create();

            var id = db.Projects.Add(proj);
            db.SaveChanges();

            return id.Entity.ProjectId;
        }

        public static void Update_Project(Project proj)
        {
            using var db = dBContextFactory.Create();

            db.Projects.Update(proj);
            db.SaveChanges();
        }

        public static bool Deactivate_Project(long id)
        {
            using var db = dBContextFactory.Create();

            var proj = db.Projects.Find(id);
            if (proj is not null)
            {
                proj.StatusId = 2;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

        #region [ Approval Requests ]

        public static List<ApprovalRequest> Get_ApprovalRequests()
        {
            using var db = dBContextFactory.Create();

            return db.ApprovalRequests
                .Include(e => e.Approver)
                .Include(e => e.LeaveRequest)
                .Include(e => e.Status)
                .ToList();
        }

        public static ApprovalRequest? Get_ApprovalRequest(long id)
        {
            using var db = dBContextFactory.Create();

            return db.ApprovalRequests
                .Include(e => e.Approver)
                .Include(e => e.LeaveRequest)
                .Include(e => e.Status)
                .FirstOrDefault(e => e.ApprovalRequestId == id);
        }

        public static long Add_ApprovalRequest(ApprovalRequest appReq)
        {
            using var db = dBContextFactory.Create();

            var id = db.ApprovalRequests.Add(appReq);
            db.SaveChanges();

            return id.Entity.ApprovalRequestId;
        }

        public static void Update_ApprovalRequest(ApprovalRequest appReq)
        {
            using var db = dBContextFactory.Create();

            db.ApprovalRequests.Update(appReq);
            db.SaveChanges();
        }

        public static void Reject_ApprovalRequest(ApprovalRequest appReq)
        {
            using var db = dBContextFactory.Create();

            appReq.StatusId = (long)LeaveStatusEnum.Rejected;

            db.ApprovalRequests.Update(appReq);
            db.SaveChanges();
        }

        public static bool Remove_ApprovalRequest(long id)
        {
            using var db = dBContextFactory.Create();

            var appReq = db.ApprovalRequests.Find(id);
            if (appReq is null)
                return false;

            db.ApprovalRequests.Remove(appReq);
            db.SaveChanges();

            return true;
        }

        #endregion

        #region [ Leave Requests ]

        public static List<LeaveRequest> Get_LeaveRequests()
        {
            using var db = dBContextFactory.Create();

            return db.LeaveRequests
                .Include(e => e.Employee)
                .Include(e => e.AbsenceReason)
                .Include(e => e.StatusNavigation)
                .ToList();
        }

        public static LeaveRequest? Get_LeaveRequest(long id)
        {
            using var db = dBContextFactory.Create();

            return db.LeaveRequests
                .Include(e => e.Employee)
                .Include(e => e.AbsenceReason)
                .Include(e => e.StatusNavigation)
                .FirstOrDefault(e => e.LeaveRequestId == id);
        }

        public static long Add_LeaveRequest(LeaveRequest req)
        {
            using var db = dBContextFactory.Create();

            var id = db.LeaveRequests.Add(req);
            db.SaveChanges();

            return id.Entity.LeaveRequestId;
        }

        public static void Update_LeaveRequest(LeaveRequest req)
        {
            using var db = dBContextFactory.Create();

            db.LeaveRequests.Update(req);
            db.SaveChanges();
        }

        public static bool Approve_LeaveRequest(long id)
        {
            using var db = dBContextFactory.Create();

            var req = db.LeaveRequests.Find(id);
            if (req is not null)
            {
                req.Status = (int)LeaveStatusEnum.Approved;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool Reject_LeaveRequest(long id)
        {
            using var db = dBContextFactory.Create();

            var req = db.LeaveRequests.Find(id);
            if (req is not null)
            {
                req.Status = (int)LeaveStatusEnum.Rejected;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool Submit_LeaveRequest(long id)
        {
            using var db = dBContextFactory.Create();

            var req = db.LeaveRequests.Find(id);
            if (req is not null)
            {
                req.Status = (int)LeaveStatusEnum.Submitted;
                db.ApprovalRequests
                    .Add(new ApprovalRequest
                    {
                        ApproverId = 1, // Random employee
                        LeaveRequestId = id,
                        StatusId = (int)LeaveStatusEnum.New
                    });

                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool Cancel_LeaveRequest(long id)
        {
            using var db = dBContextFactory.Create();

            var req = db.LeaveRequests.Find(id);
            if (req is not null)
            {
                req.Status = (int)LeaveStatusEnum.Cancelled;
                db.ApprovalRequests
                    .Where(e => e.LeaveRequestId == id)
                    .ForEachAsync(e => e.StatusId = (int)LeaveStatusEnum.Cancelled);

                db.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

        #region [ Employee Project ]

        public static List<EmployeeProject> Get_EmployeesProjects()
        {
            using var db = dBContextFactory.Create();

            var projects = db.EmployeeProjects
                .Include(e => e.Project)
                .ToList();

            return projects;
        }

        public static List<EmployeeProject> Get_EmployeeProjects(long id)
        {
            using var db = dBContextFactory.Create();

            var projects = db.EmployeeProjects
                .Include(e => e.Project)
                .Where(e => e.EmployeeId == id)
                //.Select(e => e.Project)
                .ToList();

            return projects;
        }

        public static List<EmployeeProject> Get_NotEmployeeProjects(long id)
        {
            using var db = dBContextFactory.Create();

            var projects = db.EmployeeProjects
                .Include(e => e.Project)
                .Where(e => e.EmployeeId != id)
                //.Select(e => e.Project)
                .ToList();

            return projects;
        }

        public static void Update_EmployeeProjects(List<EmployeeProject> empProjsVM, long id)
        {
            using var db = dBContextFactory.Create();

            var existingEmployeeProjects = Get_EmployeeProjects(id);
            var existingNotEmployeeProjects = Get_NotEmployeeProjects(id);

            var projectsToAdd = empProjsVM
                .Where(pa => !existingEmployeeProjects
                    .Exists(eep => eep.EmployeeId == pa.EmployeeId 
                        && eep.ProjectId == pa.ProjectId))
                .ToList();
            db.EmployeeProjects.AddRange(projectsToAdd);

            var projectsToDelete = existingNotEmployeeProjects
                .Where(enep => !empProjsVM
                    .Exists(ep => ep.EmployeeId == enep.EmployeeId 
                        && ep.ProjectId == enep.ProjectId))
                .ToList();
            db.EmployeeProjects.RemoveRange(projectsToDelete);

            db.SaveChanges();
        }

        #endregion

        #region [[ other ]]

        #region [ Absence Reason ]

        public static List<AbsenceReason> Get_AbsenceReasons()
        {
            using var db = dBContextFactory.Create();

            return db.AbsenceReasons.ToList();
        }

        public static AbsenceReason? Get_AbsenceReason(long id)
        {
            using var db = dBContextFactory.Create();

            return db.AbsenceReasons.Find(id);
        }

        #endregion

        #region [ Leave Status ]

        public static List<LeaveStatus> Get_LeaveStatuses()
        {
            using var db = dBContextFactory.Create();

            return db.LeaveStatuses.ToList();
        }

        public static LeaveStatus? Get_LeaveStatus(long id)
        {
            using var db = dBContextFactory.Create();

            return db.LeaveStatuses.Find(id);
        }

        #endregion

        #region [ Status ]

        public static List<Status> Get_Statuses()
        {
            using var db = dBContextFactory.Create();

            return db.Statuses.ToList();
        }
        public static Status? Get_Status(long id)
        {
            using var db = dBContextFactory.Create();

            return db.Statuses.Find(id);
        }

        #endregion

        #region [ Position ]

        public static List<Position> Get_Positions()
        {
            using var db = dBContextFactory.Create();

            return db.Positions.ToList();
        }

        public static Position? Get_Position(long id)
        {
            using var db = dBContextFactory.Create();

            return db.Positions.Find(id);
        }

        #endregion

        #region [ Project Type ]

        public static List<ProjectType> Get_ProjectTypes()
        {
            using var db = dBContextFactory.Create();

            return db.ProjectTypes.ToList();
        }

        public static ProjectType? Get_ProjectType(long id)
        {
            using var db = dBContextFactory.Create();

            return db.ProjectTypes.Find(id);
        }

        #endregion

        #region [ Subdivision ]

        public static List<Subdivision> Get_Subdivisions()
        {
            using var db = dBContextFactory.Create();

            return db.Subdivisions.ToList();
        }

        public static Subdivision? Get_Subdivision(long id)
        {
            using var db = dBContextFactory.Create();

            return db.Subdivisions.Find(id);
        }

        #endregion

        #region [ Photo ]

        public static List<Photo> Get_Photos()
        {
            using var db = dBContextFactory.Create();

            return db.Photos.ToList();
        }

        public static Photo? Get_Photo(long id)
        {
            using var db = dBContextFactory.Create();

            return db.Photos.Find(id);
        }

        public static long Add_Photo(Photo photo)
        {
            using var db = dBContextFactory.Create();

            var id = db.Photos.Add(photo);
            db.SaveChanges();

            return id.Entity.PhotoId;
        }

        #endregion

        #endregion
    }
}
