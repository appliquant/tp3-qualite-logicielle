using _14E_TP2_A23.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace _14E_TP2_A23.Services.EmployeesManagement
{

    /// <summary>
    /// Interface du service de gestion des employées
    /// </summary>
    public interface IEmployeeManagementService
    {
        /// <summary>
        /// Récupérer tous les employées de la base de données
        /// </summary>
        /// <returns>Les employés</returns>
        Task<ObservableCollection<Employee>> GetAllEmployees();

        /// <summary>
        /// Récupérer un employée par son nom d'utilisateur
        /// </summary>
        /// <param name="username">Nom d'utilisateur de l'employé</param>
        /// <returns>L'employé</returns>
        Task<Employee?> GetEmployeeByUsername(string username);
    }
}
