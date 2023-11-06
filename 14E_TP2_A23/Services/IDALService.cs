using _14E_TP2_A23.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14E_TP2_A23.Services
{
    /// <summary>
    /// Représente un service DAL
    /// </summary>
    public interface IDALService
    {
        /// <summary>
        /// Ajouter un employé
        /// </summary>
        Task<bool> AddEmployeeAsync(Employee employee);

        /// <summary>
        /// Trouver un employé par son nom d'utilisateur
        /// </summary>
        Task<Employee?> FindEmployeeByUsernameAsync(string username);

        /// <summary>
        /// Ajouter un client
        /// </summary>
        Task<bool> AddCustomerAsync(Customer customer);

        /// <summary>
        /// Trouver un client par son courriel
        /// </summary>
        Task<Customer?> FindCustomerByEmailAsync(string email);

        /// <summary>
        /// Trouver tous les clients
        /// </summary>
        /// <exception cref="Exception">Si la collection n'existe pas</exception>
        Task<ObservableCollection<Customer>> GetAllCustomersAsync();
    }
}
