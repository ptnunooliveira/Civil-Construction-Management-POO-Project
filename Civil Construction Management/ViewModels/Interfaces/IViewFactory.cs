using Civil_Construction_Management.ViewModels.Enums;
using System.Windows;

namespace Civil_Construction_Management.ViewModels.Interfaces
{
    /// <summary>
    /// Provides a factory mechanism for creating application views (Windows)
    /// based on the specified view type. Used for navigation in MVVM.
    /// </summary>
    public interface IViewFactory
    {
        /// <summary>
        /// Creates and returns a Window corresponding to the provided view type.
        /// </summary>
        /// <param name="type">The type of the view to create.</param>
        /// <param name="parameter">An optional parameter passed to the view's ViewModel.</param>
        /// <returns>The created Window instance.</returns>
        Window CreateView(ViewType type, object? parameter = null);
    }
}