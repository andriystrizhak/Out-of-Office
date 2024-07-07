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
        public static string CS { get; set; } = "Data Source=.\\Database\\ListsDB.db";


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
    }
}
