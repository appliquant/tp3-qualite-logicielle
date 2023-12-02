using _14E_TP2_A23.Models;
using _14E_TP2_A23.Services;
using MongoDB.Driver;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace _14E_TP2_A23.Data
{
    /// <summary>
    /// Représente la couche d'accès aux données.
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
        /// Nom de la collection des clients
        /// </summary>
        private static readonly string COLLECTION_CUSTOMERS = "Customers";

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
                throw new Exception($"La collection {COLLECTION_EMPLOYEES} n'existe pas");
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
                throw new Exception($"La collection {COLLECTION_EMPLOYEES} n'existe pas");
            }

            var employee = await collectionEmployee.Find(e => e.Username == username).FirstOrDefaultAsync();

            return employee;
        }

        /// <summary>
        /// Récupérer tous les employés de la base de données
        /// </summary>
        /// <returns>Les employés</returns>
        public async Task<ObservableCollection<Employee>> GetAllEmployeesAsync()
        {
            try
            {
                var collectionEmployees = _database.GetCollection<Employee>(COLLECTION_EMPLOYEES);
                if (collectionEmployees == null)
                {
                    throw new Exception($"La collection {COLLECTION_EMPLOYEES} n'existe pas");
                }

                var employees = await collectionEmployees.Find(e => true).ToListAsync();
                return new ObservableCollection<Employee>(employees);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Mettre à jour un employé
        /// </summary>
        /// <exception cref="Exception">Lève une exception si la collection Employees n'existe pas dans la base de données, si l'employé n'existe pas</exception>
        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                var collectionEmployees = _database.GetCollection<Employee>(COLLECTION_EMPLOYEES);
                if (collectionEmployees == null)
                {
                    throw new Exception($"La collection {COLLECTION_EMPLOYEES} n'existe pas");
                }

                var employeeExists = await collectionEmployees.Find(c => c.Username == employee.Username).FirstOrDefaultAsync();

                if (employeeExists == null)
                {
                    throw new Exception("L'employé n'existe pas");
                }

                var newEmployee = Builders<Employee>.Update
                    .Set(c => c.IsAdmin, employee.IsAdmin);

                var result = await collectionEmployees.UpdateOneAsync(c => c.Username == employee.Username, newEmployee);

                return result.IsAcknowledged && result.ModifiedCount > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Ajouter un client dans la base de données
        /// </summary>
        /// <param name="customer">Le client à ajouter</param>
        /// <returns>True si le client est ajouté</returns>
        /// <exception cref="Exception">Lève une exception si la collection Customers n'existe pas dans la base de données</exception>
        public async Task<bool> AddCustomerAsync(Customer customer)
        {
            try
            {
                var collectionCustomers = _database.GetCollection<Customer>(COLLECTION_CUSTOMERS);
                if (collectionCustomers == null)
                {
                    throw new Exception($"La collection {COLLECTION_CUSTOMERS} n'existe pas");
                }

                await collectionCustomers.InsertOneAsync(customer);

                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Trouver un client par son email
        /// </summary>
        /// <param name="email">Email du client</param>
        /// <returns></returns>
        /// <exception cref="Exception">Lève une exception si la collection Customers n'existe pas dans la base de données, si le client n'existe pas</exception>
        public async Task<Customer?> FindCustomerByEmailAsync(string email)
        {
            try
            {
                var collectionCustomers = _database.GetCollection<Customer>(COLLECTION_CUSTOMERS);
                if (collectionCustomers == null)
                {
                    throw new Exception($"La collection {COLLECTION_CUSTOMERS} n'existe pas");
                }

                var customer = await collectionCustomers.Find(c => c.Email == email).FirstOrDefaultAsync();
                return customer;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Récupérer tous les clients de la base de données
        /// </summary>
        /// <returns>Une liste des clients</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ObservableCollection<Customer>> GetAllCustomersAsync()
        {
            try
            {
                var collectionCustomers = _database.GetCollection<Customer>(COLLECTION_CUSTOMERS);
                if (collectionCustomers == null)
                {
                    throw new Exception($"La collection {COLLECTION_CUSTOMERS} n'existe pas");
                }

                var costumers = await collectionCustomers.Find(c => true).ToListAsync();
                return new ObservableCollection<Customer>(costumers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Mettre à jour un client dans la base de données
        /// </summary>
        /// <param name="customer">Le client à mettre a jour</param>
        /// <returns>True si le client a été modifié</returns>
        /// <exception cref="Exception">Lève une exception si la collection Customers n'existe pas dans la base de données, si le client n'existe pas</exception>
        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                var collectionCustomers = _database.GetCollection<Customer>(COLLECTION_CUSTOMERS);
                if (collectionCustomers == null)
                {
                    throw new Exception($"La collection {COLLECTION_CUSTOMERS} n'existe pas");
                }

                var customerExists = await collectionCustomers.Find(c => c.Email == customer.Email).FirstOrDefaultAsync();
                if (customerExists == null)
                {
                    throw new Exception("Le client n'existe pas");
                }

                var newCustomer = Builders<Customer>.Update
                    .Set(c => c.FullName, customer.FullName)
                    .Set(c => c.Email, customer.Email)
                    .Set(c => c.IsMembershipActive, customer.IsMembershipActive)
                    .Set(c => c.MembershipStartDate, customer.MembershipStartDate);

                var result = await collectionCustomers.UpdateOneAsync(c => c.Email == customer.Email, newCustomer);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }

}