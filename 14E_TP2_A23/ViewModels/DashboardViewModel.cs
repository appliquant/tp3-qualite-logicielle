using _14E_TP2_A23.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14E_TP2_A23.ViewModels
{
    /// <summary>
    /// View model de DashboardPage.xaml
    /// </summary>
    public partial class DashboardViewModel : ObservableRecipient
    {
        #region Propriétés
        /// <summary>
        /// Service de navigation injecté par le service provider
        /// </summary>
        private readonly IAppNavigationService? _appNavigtionService;
        #endregion

        #region Constructeur
        public DashboardViewModel(IAppNavigationService appNavigtionService)
        {
            _appNavigtionService = appNavigtionService;
        }

        #endregion

        #region Commandes
        [RelayCommand]
        /// <summary>
        /// Comande afficher la page d'ajout de client
        /// </summary>
        public void ShowAddCustomerPage()
        {
            _appNavigtionService?.NavigateTo("AddCustomerPage");
        }

        [RelayCommand]
        /// <summary>
        /// Commande afficher la page de modification de client
        /// </summary>
        public void ShowUpdateCustomerPage()
        {
            _appNavigtionService?.NavigateTo("UpdateCustomerPage");
        }
        #endregion
    }
}
