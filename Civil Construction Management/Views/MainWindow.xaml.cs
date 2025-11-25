using Civil_Construction_Management.ViewModels;
using System.Windows;

namespace Civil_Construction_Management
{

    public partial class MainWindow : Window
    {

        private MainWindowViewModel _mainWindowViewModel;

        public MainWindow()
        {

            InitializeComponent();
                        
            DataContext = _mainWindowViewModel;
                        
        }
    }
}