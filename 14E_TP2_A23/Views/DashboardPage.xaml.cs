using _14E_TP2_A23.Helpers;
using _14E_TP2_A23.ViewModels;
using System.Windows.Controls;

namespace _14E_TP2_A23.Views
{
    /// <summary>
    /// Logique d'interaction pour DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        DashboardViewModel _dashBoardViewModel = ServiceHelper.GetService<DashboardViewModel>();

        public DashboardPage()
        {
            InitializeComponent();
            this.DataContext = _dashBoardViewModel;
        }

        /// <summary>
        /// Commande pour afficher la page d'ajout d'un client
        /// </summary>
        private void btnAddCustomer_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _dashBoardViewModel.ShowAddCustomerPageCommand.Execute(null);
        }

        /// <summary>
        /// Commande pour afficher la page de modification d'un client
        /// </summary>
        private void btnUpdateCustomers_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _dashBoardViewModel.ShowUpdateCustomerPageCommand.Execute(null);
        }

        /// <summary>
        /// Commande afficher page modification employé
        /// </summary>
        private void btnUpdateEmployees_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _dashBoardViewModel.ShowUpdateEmployeesPageCommand.Execute(null);
        }
    }
}
