using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14E_TP2_A23.Services
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Affiche si l'utilisateur est connecté
        /// </summary>
        bool? IsLoggedIn { get; }

        /// <summary>
        /// Connecter un utilisateur
        /// </summary>
        /// <param name="username">Nom d'utilisateur</param>
        /// <param name="password">Mot de passe</param>
        /// <returns>True si connection réussie</returns>
        Task<bool> Login(string username, string password);

        /// <summary>
        /// Déconnecter l'utilisateur
        /// </summary>
        void Logout();
    }
}
