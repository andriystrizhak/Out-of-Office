using Out_of_Office;
using OutOfOffice.RoleForms;

namespace OutOfOffice
{
    public static class Program
    {
        public static UserRole CurrentRole { get; set; } = UserRole.ToSet;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            while (true)
            {
                if (CurrentRole == UserRole.Exit)
                    break;
                else if (CurrentRole == UserRole.ToSet)
                    Application.Run(new RoleSelectionForm());
                else if (CurrentRole == UserRole.Employee)
                    Application.Run(new EmployeeRoleForm());
                else if (CurrentRole == UserRole.HR)
                    Application.Run(new HRManagerForm());
                else if (CurrentRole == UserRole.PM)
                    Application.Run(new ProjectManagerForm());
            }
        }
    }
}