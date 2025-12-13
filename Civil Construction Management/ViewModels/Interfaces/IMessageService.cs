namespace Civil_Construction_Management.ViewModels.Interfaces
{
    /// <summary>
    /// Provides a method for displaying informational or error messages
    /// to the user through the application's UI.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Displays a message to the user.
        /// </summary>
        /// <param name="message">The text message to display.</param>
        public void ShowMessage(string message);
    }
}