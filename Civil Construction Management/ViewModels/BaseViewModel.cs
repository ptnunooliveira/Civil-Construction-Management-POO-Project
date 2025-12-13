using System.ComponentModel;

namespace Civil_Construction_Management.ViewModels
{
    /// <summary>
    /// Serves as the base class for all ViewModel classes in the application.
    /// Implements <see cref="INotifyPropertyChanged"/> to allow automatic UI updates
    /// when property values change.
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes. Used by WPF binding to update the user interface.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event for the specified property.
        /// Call this method inside property setters to notify the UI of changes.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}