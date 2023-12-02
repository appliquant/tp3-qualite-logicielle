using _14E_TP2_A23.Helpers;
using _14E_TP2_A23.Models;
using _14E_TP2_A23.ViewModels.DashboardViewModels;
using DnsClient.Protocol;
using System.Linq;
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

            FillListViewClimbingWalls();
        }

        /// <summary>
        /// Remplir le list view des murs d'escalade
        /// </summary>
        private async void FillListViewClimbingWalls()
        {
            var climbingWalls = await _manageClimbingWallsViewModel.GetAllClimbingWalls();
            lvClimbingWalls.ItemsSource = climbingWalls;
        }

        /// <summary>
        /// Événnement de sélection d'un mur d'escalade
        /// </summary>
        private void lvClimbingWalls_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvClimbingWalls.SelectedItem is ClimbingWall selectedWall)
            {
                _manageClimbingWallsViewModel.SelectedClimbingRoute = null;
                UpdateListViewClimbingRoutes(selectedWall.Id);
            }
        }


        /// <summary>   
        /// Événnement de sélection d'une voie d'escalade
        /// </summary>
        private void lvClimbingRoutes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvClimbingRoutes.SelectedItem is ClimbingRoute selectedRoute)
            {
                var averageDifficultyRating = selectedRoute.DifficultyRatings.Average();
                selectedRoute.AverageDifficultyRating = averageDifficultyRating;

                // Colorer la difficulté moyenne de la voie si elle est trop différente de la difficulté du mur
                if (averageDifficultyRating - selectedRoute.Difficulty > 2 || selectedRoute.Difficulty - averageDifficultyRating > 2)
                {
                    txtAverageDifficultyRating.Background = System.Windows.Media.Brushes.Red;
                }

                _manageClimbingWallsViewModel.SelectedClimbingRoute = selectedRoute;
            }
        }

        ///<summary>
        /// Mettre à jour la liste des vois d'escalade
        /// </summary>
        private async void UpdateListViewClimbingRoutes(string wallId)
        {
            var climbingRoutes = await _manageClimbingWallsViewModel.GetAllClimbingRoutes();

            if (climbingRoutes == null)
            {
                return;
            }

            foreach (var route in climbingRoutes)
            {
                if (route.WallId == wallId)
                {
                    route.IsAssignedToCurrentAWall = true;
                }

                route.IsAssignedToAWall = route.WallId != null && route.IsAssignedToCurrentAWall == false;

            }


            var climbingRouteAssignedToWall = climbingRoutes?.Where(cr => cr.WallId == wallId).FirstOrDefault();

            lvClimbingRoutes.SelectedItem = climbingRouteAssignedToWall;
            lvClimbingRoutes.ScrollIntoView(climbingRouteAssignedToWall);
            lvClimbingRoutes.ItemsSource = climbingRoutes;

            // Afficher la route assignée au mur
            txtAssignedRouteToWall.Text = climbingRouteAssignedToWall != null ? $"Route assignée au mur : {climbingRouteAssignedToWall?.Name}" : "Aucune route assignée";
            txtAssignedRouteToWall.Foreground = climbingRouteAssignedToWall != null ? System.Windows.Media.Brushes.Green : System.Windows.Media.Brushes.Red;

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
