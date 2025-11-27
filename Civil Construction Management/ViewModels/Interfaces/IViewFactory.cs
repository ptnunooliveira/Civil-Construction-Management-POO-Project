using Civil_Construction_Management.ViewModels.Enums;
using System.Windows;

namespace Civil_Construction_Management.ViewModels.Interfaces
{
    public interface IViewFactory
    {

        Window CreateView(ViewType type, object? parameter = null);
    }
}
