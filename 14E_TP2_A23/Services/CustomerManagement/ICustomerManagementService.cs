using _14E_TP2_A23.Models;
using System.Threading.Tasks;

namespace _14E_TP2_A23.Services.CustomerManagement
{
    /// <summary>
    /// Interface du service de gestion des clients
    /// </summary>
    public interface ICustomerManagementService
    {
        /// <summary>
        /// Ajoute un client
        /// </summary>
        /// <param name="customer">Client à ajouter</param>
        /// <returns>True si l'ajout est réussi</returns>
        Task<bool> AddCustomer(Customer customer);

        /// <summary>
        /// Modifie un client
        /// </summary>
        /// <param name="customer">Client à modifier</param>
        /// <returns>True si la modification est réussie</returns>
        Task<bool> UpdateCustomer(Customer customer);
    }
}
