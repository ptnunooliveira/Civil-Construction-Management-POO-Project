using Civil_Construction_Management.ViewModels.Interfaces;
using System.Windows;

namespace Civil_Construction_Management.Views.Services
{
    /// <summary>
    /// Service implementation responsible for displaying user messages
    /// through standard WPF message boxes.
    /// </summary>
    public class MessageService : IMessageService
    {
        /// <summary>
        /// Displays a simple message dialog to the user.
        /// </summary>
        /// <param name="message">The text to be shown inside the message box.</param>
        public void ShowMessage(string message)
        {
            // Using a standard WPF MessageBox to display feedback to the user.
            MessageBox.Show(message);
        }
    }
}
