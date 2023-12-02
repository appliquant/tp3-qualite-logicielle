using _14E_TP2_A23.Helpers;
using _14E_TP2_A23.ViewModels.DashboardViewModels;
using System.Windows.Controls;

namespace _14E_TP2_A23.Views.DashboardSubPages
{
    /// <summary>
    /// Logique d'interaction pour ManageClimbingWallsPage.xaml
    /// </summary>
    public partial class ManageClimbingWallsPage : Page
    {
        ManageClimbingWallsViewModel _manageClimbingWallsViewModel = ServiceHelper.GetService<ManageClimbingWallsViewModel>();
        public ManageClimbingWallsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Bouton retour en arrière
        /// <param name="sender"></param>
        private void btnBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _manageClimbingWallsViewModel.GoBackCommand.Execute(null);
        }
    }
}
