using _14E_TP2_A23.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14E_TP2_A23.Services
{
    [INotifyPropertyChanged]
    public partial class AuthenticationService : IAuthenticationService
    {
        #region Propriétés
        private readonly IDALService? _dal;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsLoggedIn))]
        private Employee? _currentEmployee;

        /// <summary>
        /// Affiche si l'utilisateur est connecté
        /// </summary>
        public bool? IsLoggedIn => _currentEmployee != null;
        #endregion

        #region Constructeur
        public AuthenticationService(IDALService dalService)
        {
            _dal = dalService;
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Tente de connecter un utilisateur avec les identifiants fournis.
        /// </summary>
        /// <param name="username">Nom d'utilisateur.</param>
        /// <param name="password">Mot de passe.</param>
        /// <returns>True si la connexion est réussie, sinon une exception est levée.</returns>
        /// <exception cref="Exception">Levée si le DAL est non défini, si l'identifiant est incorrect, ou si le mot de passe ne correspond pas.</exception>
        async Task<bool> IAuthenticationService.Login(string username, string password)
        {
            if (_dal == null)
            {
                throw new Exception("DAL non definit");
            }

            var employee = await _dal.FindEmployeeByUsernameAsync(username);
            if (employee == null)
            {
                throw new Exception("Identifiant et/ou mot de passe incorrect.");
            }

            if (!BCrypt.Net.BCrypt.Verify(password, employee.Password))
            {
                throw new Exception("Nom d'utilisateur et/ou mot de passe incorrect");
            }

            CurrentEmployee = employee;

            return true;


        }

        /// <summary>
        /// Déconnecte l'utilisateur courant et efface toutes ses données de session.
        /// </summary>
        void IAuthenticationService.Logout()
        {
            CurrentEmployee = null;
        }
        #endregion
    }
}
