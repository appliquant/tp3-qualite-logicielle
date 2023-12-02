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
            DataContext = _manageClimbingWallsViewModel;

            FillListView();
        }

        /// <summary>
        /// Remplir le list view
        /// </summary>
        private async void FillListView()
        {
            var climbingWalls = await _manageClimbingWallsViewModel.GetAllClimbingWalls();
            lvClimbingWalls.ItemsSource = climbingWalls;
            lvClimbingWalls.SelectedIndex = 0;

        }

        /// <summary>
        /// Bouton retour en arrière
        /// </summary>
        private void btnBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _manageClimbingWallsViewModel.GoBackCommand.Execute(null);
        }


    }
}
