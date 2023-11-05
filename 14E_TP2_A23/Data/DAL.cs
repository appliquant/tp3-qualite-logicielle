using _14E_TP2_A23.Models;
using _14E_TP2_A23.Services;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using BCrypt.Net;

namespace _14E_TP2_A23.Data
{
    /// <summary>
    /// Représente la couche d'accès aux données
    /// Utilisation : ServiceHelper.GetService<IDALService>();
    /// </summary>
    public sealed class DAL : IDALService
    {
        #region Propriétés
        /// <summary>
        /// Nom de la base de donnée
        /// </summary>
        private static readonly string DB_NAME = "TP2DB";

        /// <summary>
        /// Nom de la collection des utilisateurs
        /// </summary>
        private static readonly string COLLECTION_EMPLOYEES = "Employees";

        ///// <summary>
        ///// Client Mongo
        ///// </summary>
        private readonly IMongoClient _mongoClient;

        /// <summary>
        /// Base de donnée Mongo
        /// </summary>
        private readonly IMongoDatabase _database;


        #endregion

        #region Constructeur
        public DAL(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
            _database = _mongoClient.GetDatabase(DB_NAME);
        }
        #endregion

        #region Méthodes

        /// <summary>
        /// Ajoute un employé dans la base de donnée
        /// </summary>
        /// <param name="employee">Employé</param>
        /// <returns>True si opération a fonctionné</returns>
        /// <exception cref="Exception">Lève une exception si la collection n'existe pas ou si l'employé existe déjà.</exception>

        public async Task<bool> AddEmployeeAsync(Employee employee)
        {
            // Récupérer la collection
            var collectionEmployee = _database.GetCollection<Employee>(COLLECTION_EMPLOYEES);
            if (collectionEmployee == null)
            {
                throw new Exception("La collection Employees n'existe pas");
            }

            var employeeExists = await collectionEmployee.Find(e => e.Username == employee.Username).FirstOrDefaultAsync();
            if (employeeExists != null)
            {
                throw new Exception("L'employé existe déjà");
            }

            var salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(employee.Password, salt);

            employee.Salt = salt;
            employee.Password = passwordHash;

            await collectionEmployee.InsertOneAsync(employee);
            return true;
        }

        /// <summary>
        /// Trouver un employé par son nom d'utilisateur
        /// </summary>
        /// <param name="username">Nom d'utilisateur</param>
        /// <returns>L'employé</returns>
        /// <exception cref="Exception">Lève une exception si la collection Employees n'existe pas dans la base de données.</exception>
        public async Task<Employee?> FindEmployeeByUsernameAsync(string username)
        {
            var collectionEmployee = _database.GetCollection<Employee>(COLLECTION_EMPLOYEES);
            if (collectionEmployee == null)
            {
                throw new Exception("La collection Employees n'existe pas");
            }

            var employee = await collectionEmployee.Find(e => e.Username == username).FirstOrDefaultAsync();
            if (employee == null)
            {
                throw new Exception("L'employé n'existe pas");
            }

            return employee;
        }

        #endregion
    }

}