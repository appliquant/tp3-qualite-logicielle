using _14E_TP2_A23.Services;

namespace _14E_TP2_A23.ViewModels.DashboardViewModels
{
    /// <summary>
    /// View model de UpdateEmployeePage.xaml
    /// </summary>
    public partial class UpdateEmployeeViewModel
    {
        #region Propriétés
        /// <summary>
        /// Service de navigation injecté par le service provider
        /// </summary>
        private readonly IAppNavigationService _appNavigtionService;
        #endregion

        #region Constructeur
        public UpdateEmployeeViewModel(IAppNavigationService appNavigtionService)
        {
            _appNavigtionService = appNavigtionService;
        }
        #endregion
    }
}
