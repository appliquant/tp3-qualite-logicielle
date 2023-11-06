using _14E_TP2_A23.Helpers;
using _14E_TP2_A23.ViewModels.DashboardViewModels;
using System.Windows.Controls;

namespace _14E_TP2_A23.Views.DashboardPages
{
    /// <summary>
    /// Logique d'interaction pour AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        AddClientPageViewModel _addClientPageViewModel = ServiceHelper.GetService<AddClientPageViewModel>();
        public AddClientPage()
        {
            InitializeComponent();
            this.DataContext = _addClientPageViewModel;
        }

        /// <summary>
        /// Bouton retour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _addClientPageViewModel.GoBackCommand.Execute(null);
        }
    }
}
