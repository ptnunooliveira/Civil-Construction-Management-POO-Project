using Civil_Construction_Management.Models.Repositories;
using Civil_Construction_Management.Models.Repositories.Interfaces;
using Civil_Construction_Management.ViewModel;
using Civil_Construction_Management.ViewModel.Interfaces;
using Civil_Construction_Management.ViewModel.Services;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Civil_Construction_Management
{

    public partial class MainWindow : Window
    {

        private OrganizationViewModel _organization;
        public MainWindow()
        {

            InitializeComponent();
            DataContext = _organization;
        }
    }
}