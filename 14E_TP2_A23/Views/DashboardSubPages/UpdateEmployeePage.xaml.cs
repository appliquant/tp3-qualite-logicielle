using _14E_TP2_A23.Helpers;
using _14E_TP2_A23.ViewModels.DashboardViewModels;
using System.Windows.Controls;

namespace _14E_TP2_A23.Views.DashboardSubPages
{
    /// <summary>
    /// Logique d'interaction pour UpdateEmployeesPage.xaml
    /// </summary>
    public partial class UpdateEmployeesPage : Page
    {
        UpdateEmployeeViewModel _updateEmployeeViewModel = ServiceHelper.GetService<UpdateEmployeeViewModel>();
        public UpdateEmployeesPage()
        {
            InitializeComponent();
            FillDataGrid();
        }

        /// <summary>
        /// Remplir la grille de données
        /// </summary>
        private void FillDataGrid()
        {
            //var employees = _updateEmployeeViewModel.GetEmployees();
            //dgEmployees.ItemsSource = employees;
        }

        /// <summary>
        /// Commande retour en arrière
        /// </summary>
        private void btnBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _updateEmployeeViewModel.GoBackCommand.Execute(null);
        }
    }
}
