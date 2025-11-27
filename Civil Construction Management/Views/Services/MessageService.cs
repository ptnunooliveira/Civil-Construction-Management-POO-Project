using Civil_Construction_Management.ViewModels.Interfaces;
using System.Windows;

namespace Civil_Construction_Management.Views.Services
{
    public class MessageService : IMessageService
    {

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
