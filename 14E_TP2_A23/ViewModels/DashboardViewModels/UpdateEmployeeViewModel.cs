using _14E_TP2_A23.Models;
using _14E_TP2_A23.Services.EmployeesManagement;
using _14E_TP2_A23.Services.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace _14E_TP2_A23.ViewModels.DashboardViewModels
{
    /// <summary>
    /// View model de UpdateEmployeePage.xaml
    /// </summary>
    public partial class UpdateEmployeeViewModel : ObservableRecipient
    {
        #region Propriétés
        /// <summary>
        /// Service de navigation injecté par le service provider
        /// </summary>
        private readonly IAppNavigationService _appNavigtionService;

        /// <summary>
        /// Service de gestion des employées injecté par le service provider
        /// </summary>
        private readonly IEmployeeManagementService _employeeManagementService;
        #endregion

        #region Constructeur
        public UpdateEmployeeViewModel(IAppNavigationService appNavigtionService, IEmployeeManagementService employeeManagementService)
        {
            _appNavigtionService = appNavigtionService;
            _employeeManagementService = employeeManagementService;
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Récupérer tous les employées de la base de données
        /// </summary>
        public async Task<ObservableCollection<Employee>> GetAllEmployees()
        {
            try
            {
                return await _employeeManagementService.GetAllEmployees();
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
