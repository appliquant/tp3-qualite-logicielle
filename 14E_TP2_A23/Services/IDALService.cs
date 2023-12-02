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
        /// Récupérer tous les employés
        /// </summary>
        Task<ObservableCollection<Employee>> GetAllEmployeesAsync();

        /// <summary>
        /// Mettre à jour un employé
        /// </summary>
        /// <exception cref="Exception">Lève une exception si la collection Employees n'existe pas dans la base de données, si l'employé n'existe pas</exception>
        Task<bool> UpdateEmployeeAsync(Employee employee);

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

        /// <summary>
        /// Mettre à jour un client
        /// </summary>
        /// <exception cref="Exception">Lève une exception si la collection Customers n'existe pas dans la base de données, si le client n'existe pas</exception>
        Task<bool> UpdateCustomerAsync(Customer customer);

        /// <summary>
        /// Récupérer tous les murs d'escalade
        /// </summary>
        Task<ObservableCollection<ClimbingWall>> GetAllClimbingWallsAsync();

        /// <summary>
        /// Récupérer toutes les voies d'escalades
        /// </summary>
        Task<ObservableCollection<ClimbingRoute>> GetAllClimbingRoutesAsync();
    }
}
