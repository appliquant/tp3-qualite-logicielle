using _14E_TP2_A23.Models;
using _14E_TP2_A23.Services;
using _14E_TP2_A23.Services.CustomerManagement;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace _14E_TP2_A23.ViewModels.DashboardViewModels
{
    /// <summary>
    /// View model de UpdateCustomerPage.xaml
    /// </summary>
    public partial class UpdateCustomerPageViewModel : ObservableValidator
    {
        #region Propriétés
        /// <summary>
        /// Service de navigation injecté par le service provider
        /// </summary>
        private readonly IAppNavigationService _appNavigtionService;

        /// <summary>
        /// Service de gestion des clients injecté par le service provider
        /// </summary>
        private readonly ICustomerManagementService _customerManagementService;
        #endregion

        #region Constructeur
        public UpdateCustomerPageViewModel(IAppNavigationService appNavigtionService, ICustomerManagementService customerManagementService)
        {
            _appNavigtionService = appNavigtionService;
            _customerManagementService = customerManagementService;
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Récupérer tous les clients de la base de données
        /// </summary>
        public async Task<ObservableCollection<Customer>?> GetAllCustomers()
        {
            try
            {
                return await _customerManagementService.GetAllCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération des données : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
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
