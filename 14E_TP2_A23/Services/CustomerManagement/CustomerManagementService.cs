using _14E_TP2_A23.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Threading.Tasks;

namespace _14E_TP2_A23.Services.CustomerManagement
{
    public partial class CustomerManagementService : ObservableObject, ICustomerManagementService
    {
        #region Propriétés
        #endregion

        #region Constructeur
        #endregion

        #region Méthodes
        public Task<bool> AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
