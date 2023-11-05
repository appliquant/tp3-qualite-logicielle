using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _14E_TP2_A23.Services
{
    /// <summary>
    /// Définit un service de navigation entre les pages
    /// </summary>
    public interface IAppNavigationService
    {
        /// <summary>
        /// Initialise le service de navigation avec le contrôle de cadre principal.
        /// </summary>
        /// <param name="frame">Le contrôle de cadre utilisé pour la navigation.</param>
        void Initialize(Frame frame);

        /// <summary>
        /// Enregistre un type de page avec une clé unique à des fins de navigation.
        /// </summary>
        /// <param name="key">La clé associée au type de page.</param>
        /// <param name="pageType">Le type de la page à enregistrer.</param>
        void RegisterPage(string key, Type pageType);

        /// <summary>
        /// Enregistre un type de fenêtre avec une clé unique à des fins de navigation.
        /// </summary>
        /// <param name="key">La clé associée a la fenêtre.</param>
        /// <param name="pageType">Le type de la fenêtre à enregistrer.</param>
        void RegisterWindow(string key, Func<Window> windowFactory);

        /// <summary>
        /// Navigue vers la page spécifiée
        /// </summary>
        /// <param name="pageKey">Le nom de la page vers ou naviguer</param>
        void NavigateTo(string pageKey);

        /// <summary>
        /// Ouvre une fenêtre
        /// </summary>
        /// <param name="windowKey">Le nom de la fenêtre vers ou naviguer</param>
        void OpenWindow(string windowKey);

        /// <summary>
        /// Retourne à la page précédente
        /// </summary>
        void GoBack();
    }
}
