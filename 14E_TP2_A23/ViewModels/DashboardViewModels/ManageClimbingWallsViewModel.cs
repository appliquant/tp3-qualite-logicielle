using _14E_TP2_A23.Models;
using _14E_TP2_A23.Services.ClimbingWalls;
using _14E_TP2_A23.Services.Navigation;
using _14E_TP2_A23.Views.DashboardSubPages.Climbing;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace _14E_TP2_A23.ViewModels.DashboardViewModels
{
    /// <summary>
    /// View model de ManageClimbingWallsPage.xaml
    /// </summary>
    public partial class ManageClimbingWallsViewModel : ObservableValidator
    {
        #region Propriétés
        /// <summary>
        /// Service de navigation injecté par le service provider
        /// </summary>
        private readonly IAppNavigationService _appNavigtionService;

        /// <summary>
        /// Service de gestion des murs d'escalade injecté par le service provider
        /// </summary>
        private readonly IClimbingManagementService _climbingWallManagementService;

        /// <summary>
        /// Mur sélectionné dans le list view
        /// </summary>
        [ObservableProperty]
        private ClimbingWall? _selectedClimbingWall;

        /// <summary>
        /// Voie sélectionnée dans le list view des voies
        /// </summary>
        [ObservableProperty]
        private ClimbingRoute? _selectedClimbingRoute;

        #endregion

        #region Constructeur
        public ManageClimbingWallsViewModel(IAppNavigationService appNavigtionService,
            IClimbingManagementService climbingWallsManagementService)
        {
            _appNavigtionService = appNavigtionService;
            _climbingWallManagementService = climbingWallsManagementService;
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Récupérer tous les murs d'escalade de la base de données
        /// </summary>
        public async Task<ObservableCollection<ClimbingWall>?> GetAllClimbingWalls()
        {
            try
            {
                return await _climbingWallManagementService.GetAllClimbingWalls();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération des murs d'escalades : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        /// <summary>
        /// Récupérer tous les murs d'escalade de la base de données
        /// </summary>
        public async Task<ObservableCollection<ClimbingRoute>?> GetAllClimbingRoutes()
        {
            try
            {
                return await _climbingWallManagementService.GetAllClimbingRoutes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération des murs d'escalades : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        #endregion

        #region Commandes
        /// <summary>
        /// Afficher fenêtre de création d'un mur d'escalade
        /// </summary>
        [RelayCommand]
        public void ShowCreateClimbingWallWindow()
        {
            // afficher la fenêtre de création d'un mur d'escalade
            AddClimbingRouteWindow addClimbingRouteWindow = new AddClimbingRouteWindow();
            var result = addClimbingRouteWindow.ShowDialog();

            if (!result.HasValue || !result.Value) return;
        }

        /// <summary>
        /// Commande retourner à la page précédente
        /// </summary>
        [RelayCommand]
        public void GoBack()
        {
            _appNavigtionService?.GoBack();
        }
        #endregion

        #region Validation
        #endregion
    }
}
