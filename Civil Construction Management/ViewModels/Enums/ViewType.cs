namespace Civil_Construction_Management.ViewModels.Enums
{
    /// <summary>
    /// Represents the different views or screens within the application.
    /// Used to control navigation in the MVVM architecture.
    /// </summary>
    public enum ViewType
    {
        /// <summary>
        /// The login view where users authenticate into the system.
        /// </summary>
        Login,

        /// <summary>
        /// The main dashboard of the application.
        /// </summary>
        Main,

        /// <summary>
        /// The view for creating a new user account.
        /// </summary>
        CreateAccount,

        /// <summary>
        /// The view for adding a new employee.
        /// </summary>
        AddEmployee,

        /// <summary>
        /// The view for creating a new construction project.
        /// </summary>
        AddProject,

        /// <summary>
        /// The view for adding a material to a project.
        /// </summary>
        AddMaterial,

        /// <summary>
        /// The view for assigning a service to a project.
        /// </summary>
        AddService,

        /// <summary>
        /// The view for selecting an employee to assign to a project).
        /// </summary>
        SelectEmployee
    }
}
