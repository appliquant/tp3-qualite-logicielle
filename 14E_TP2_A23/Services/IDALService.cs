using _14E_TP2_A23.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
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
        ///// <summary>
        ///// Ouvre une connection à la base de données
        ///// </summary>
        ///// <returns>Un client Mongodb</returns>
        //MongoClient? OpenConnection();

        /// <summary>
        /// Connecter un utilisateur
        /// </summary>
        //Task<bool> Login(string username, string password);

        /// <summary>
        /// Ajouter un employé
        /// </summary>
        Task<bool> AddEmployeeAsync(Employee employee);

        /// <summary>
        /// Trouver un employé par son nom d'utilisateur
        /// </summary>
        Task<Employee?> FindEmployeeByUsernameAsync(string username);
    }
}
