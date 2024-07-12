using Out_of_Office;
using OutOfOffice.RoleForms;

namespace OutOfOffice
{
    public static class Program
    {
        public static UserRole CurrentRole { get; set; } = UserRole.NotSet;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new RoleSelectionForm());
            
            switch(CurrentRole)
            {
                case UserRole.Employee:
                    Application.Run(new EmployeeRoleForm());
                    break;
                case UserRole.HR:
                    Application.Run(new HRManagerForm());
                    break;
                case UserRole.PM:
                    Application.Run(new ProjectManagerForm());
                    break;
            }
        }
    }
}