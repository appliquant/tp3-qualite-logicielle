using _14E_TP2_A23.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14E_TP2_A23.ViewModels
{
    public partial class MainViewModel : ObservableValidator
    {
        #region Propriétés
        [ObservableProperty]
        [NotifyDataErrorInfo]
        [MinLength(3, ErrorMessage = "Le nom d'utilisateur doit contenir au moins 1 caractères")]
        private string? _username;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [MinLength(3, ErrorMessage = "Le mot de passe doit contenir au moins 1 caractères")]
        private string? _password;

        #endregion

        #region Constructeur
        public MainViewModel(IDALService dal)
        {

        }

        #endregion

        #region Commandes
        [RelayCommand]
        public void Login()
        {
            // Validation des données
            ValidateAllProperties();

            if (HasErrors)
            {
                return;
            }

            // Connexion
            //if (DAL.Login(Username, Password))
            //{
            //    // Affichage de la fenêtre principale
            //    MainWindow mainWindow = new MainWindow();
            //    mainWindow.Show();

            //    // Fermeture de la fenêtre de connexion
            //    App.Current.MainWindow.Close();
            //}

        }
        #endregion
    }
}
