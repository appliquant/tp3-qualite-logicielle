using _14E_TP2_A23.Helpers;
using _14E_TP2_A23.ViewModels.DashboardViewModels;
using System.Windows;
using System.Windows.Controls;

namespace _14E_TP2_A23.Views.DashboardSubPages
{
    /// <summary>
    /// Logique d'interaction pour UpdateCustomerPage.xaml
    /// </summary>
    public partial class UpdateCustomerPage : Page
    {
        UpdateCustomerPageViewModel _updateCustomerPageViewModel = ServiceHelper.GetService<UpdateCustomerPageViewModel>();
        public UpdateCustomerPage()
        {
            InitializeComponent();
            DataContext = _updateCustomerPageViewModel;
        }

        /// <summary>
        /// Click bouton retour en arrère
        /// </summary>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            _updateCustomerPageViewModel.GoBackCommand.Execute(null);
        }
    }
}
