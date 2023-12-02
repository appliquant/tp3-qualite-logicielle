using _14E_TP2_A23.Services.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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
        #endregion

        #region Constructeur
        public ManageClimbingWallsViewModel(IAppNavigationService appNavigtionService)
        {
            _appNavigtionService = appNavigtionService;
        }
        #endregion

        #region Commandes
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
