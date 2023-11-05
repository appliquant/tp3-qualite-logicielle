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

        /// <summary>
        /// Client Mongo
        /// </summary>
        private MongoClient mongoDBClient { get; set; }
        #endregion

        #region Constructeur
        public DAL()
        {
            var connection = OpenConnection();
            if (connection == null)
            {
                MessageBox.Show("Impossible de se connecter à la base de données", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            mongoDBClient = connection;
        }

        #endregion

        #region Méthodes

        /// <summary>
        /// Ouvre une connexion à la base de données
        /// </summary>
        /// <returns></returns>
        public MongoClient? OpenConnection()
        {
            const string dbPassword = "MiDCY3eaRELztkpQ";
            const string dbUser = "tp3_qualite_logicielle";
            const string connectionUri = $"mongodb+srv://{dbUser}:{dbPassword}@cluster0.7iuzeeb.mongodb.net/?retryWrites=true&w=majority";


            try
            {
                var settings = MongoClientSettings.FromConnectionString(connectionUri);
                settings.ServerApi = new ServerApi(ServerApiVersion.V1);

                var client = new MongoClient(settings);

                // Tester connexion sur la db "admin" (db créee par défaut)
                var result = client.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));

                return client;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Impossible de se connecter à la base de données: {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                // Consider what to do in case of failure. Maybe return null or handle it differently.
                // For now, it's returning null.
                return null;
            }
        }


        /// <summary>
        /// Connecter un utilisateur
        /// </summary>
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="password">Mot de passe</param>
        /// <returns></returns>
        public async Task<bool> Login(string username, string password)
        {
            var collectionEmployees = mongoDBClient.GetDatabase(DB_NAME).GetCollection<Employee>(COLLECTION_EMPLOYEES);

            if (collectionEmployees == null)
            {
                throw new Exception("La collection Employees n'existe pas");
            }

            try
            {
                var employee = await collectionEmployees.Find(e => e.Username == username).FirstOrDefaultAsync();
                if (employee == null)
                {
                    throw new Exception("Erreur avec l'identifiant et/ou mot de passe.");
                }

                var passwordHash = BCrypt.Net.BCrypt.HashPassword(password, employee.Salt);
                if (passwordHash != employee.Password)
                {
                    throw new Exception("Erreur avec l'identifiant et/ou mot de passe.");
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<bool> AddEmployee(Employee employee)
        {
            // Récupérer la collection
            var collectionEmployee = mongoDBClient.GetDatabase(DB_NAME).GetCollection<Employee>(COLLECTION_EMPLOYEES);
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

        #endregion
    }
}
