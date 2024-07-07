using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutOfOffice.Models
{
    public static class CRUDService
    {
        /// <summary>
        /// Connection String (contains path to .db file)
        /// </summary>
        public static string CS { get; set; } = "Data Source=Database\\ListsDB.db";

        #region [ Employee ]

        public static List<Employee> Get_Employees()
        {
            using ListsDBContext db = new();

            return db.Employees.ToList();
        }

        public static Employee? Get_Employee(long id)
        {
            using ListsDBContext db = new();

            return db.Employees.Find(id);
        }

        public static long Add_Employee(Employee emp)
        {
            using ListsDBContext db = new();

            var id = db.Employees.Add(emp);
            db.SaveChanges();

            return id.Entity.EmployeeId;
        }

        public static void Update_Employee(Employee emp)
        {
            using ListsDBContext db = new();

            db.Employees.Update(emp);
            db.SaveChanges();
        }

        public static bool Deactivate_Employee(long id)
        {
            using ListsDBContext db = new();

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
            using ListsDBContext db = new();

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
            using ListsDBContext db = new();

            var emp = db.Employees.Find(empId);
            var proj = db.Projects.Find(projId);
            if (emp is not null && proj is not null)
            {
                //TODO - add 'ProjectID' column
                //emp.Projects = projId;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

        #region [ Position ]

        public static List<Project> Get_Projects()
        {
            using ListsDBContext db = new();

            return db.Projects.ToList();
        }

        public static Project? Get_Project(long id)
        {
            using ListsDBContext db = new();

            return db.Projects.Find(id);
        }

        #endregion

        #region [ Approval Requests ]

        public static List<ApprovalRequest> Get_ApprovalRequests()
        {
            using ListsDBContext db = new();

            return db.ApprovalRequests.ToList();
        }

        public static ApprovalRequest? Get_ApprovalRequest(long id)
        {
            using ListsDBContext db = new();

            return db.ApprovalRequests.Find(id);
        }

        public static bool Approve_ApprovalRequest(long id)
        {
            using ListsDBContext db = new();

            var req = db.ApprovalRequests.Find(id);
            if (req is not null)
            {
                req.StatusId = 2;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool Reject_ApprovalRequest(long id)
        {
            using ListsDBContext db = new();

            var req = db.ApprovalRequests.Find(id);
            if (req is not null)
            {
                req.StatusId = 3;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

        #region [ Leave Requests ]

        public static List<LeaveRequest> Get_LeaveRequests()
        {
            using ListsDBContext db = new();

            return db.LeaveRequests.ToList();
        }

        public static LeaveRequest? Get_LeaveRequest(long id)
        {
            using ListsDBContext db = new();

            return db.LeaveRequests.Find(id);
        }

        public static bool Approve_LeaveRequest(long id)
        {
            using ListsDBContext db = new();

            var req = db.LeaveRequests.Find(id);
            if (req is not null)
            {
                req.Status = 2;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool Reject_LeaveRequest(long id)
        {
            using ListsDBContext db = new();

            var req = db.LeaveRequests.Find(id);
            if (req is not null)
            {
                req.Status = 3;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

    }
}
