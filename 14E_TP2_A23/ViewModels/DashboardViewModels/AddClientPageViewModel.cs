using _14E_TP2_A23.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _14E_TP2_A23.ViewModels.DashboardViewModels
{
    /// <summary>
    /// View model de AddClientPage.xaml
    /// </summary>
    public partial class AddClientPageViewModel : ObservableRecipient
    {
        #region Propriétés
        /// <summary>
        /// Service de navigation injecté par le service provider
        /// </summary>
        private readonly IAppNavigationService _appNavigtionService;
        #endregion

        #region Constructeur
        public AddClientPageViewModel(IAppNavigationService appNavigtionService)
        {
            _appNavigtionService = appNavigtionService;
        }

        #endregion

        #region Commandes
        [RelayCommand]
        /// <summary>
        /// Commande retourner à la page précédente
        /// </summary>
        public void GoBack()
        {
            _appNavigtionService.GoBack();
        }
        #endregion
    }
}
