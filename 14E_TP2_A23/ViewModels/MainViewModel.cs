using _14E_TP2_A23.Models;
using _14E_TP2_A23.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Windows;

namespace _14E_TP2_A23.ViewModels
{
    public partial class MainViewModel : ObservableValidator
    {
        #region Propriétés
        private const int _UsernameMinLength = 1;
        private const int _UsernameMaxLength = 20;

        private const int _PasswordMinLength = 1;
        private const int _PasswordMaxLength = 20;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [MinLength(_UsernameMinLength, ErrorMessage = "Le nom d'utilisateur doit contenir au moins 1 caractères")]
        [MaxLength(_UsernameMaxLength, ErrorMessage = "Le nom d'utilisateur doit contenir au plus 20 caractères")]
        private string? _username;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [MinLength(_PasswordMinLength, ErrorMessage = "Le mot de passe doit contenir au moins 1 caractères")]
        [MaxLength(_PasswordMaxLength, ErrorMessage = "Le mot de passe doit contenir au plus 20 caractères")]
        private string? _password;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsLoggedIn))]
        private Employee? _employee;

        /// <summary>
        /// Affiche si l'utilisateur est connecté
        /// </summary>
        public bool? IsLoggedIn => _employee != null;

        /// <summary>
        /// Service d'authentification injecté par le service provider
        /// </summary>
        private readonly IAuthenticationService? _authenticationService;


        #endregion

        #region Constructeur
        public MainViewModel(IAuthenticationService authenticationService)
        {
            // authenticationService automatiquement injecté par le service provider dans App.xaml.cs
            _authenticationService = authenticationService;
        }

        #endregion

        #region Commandes
        [RelayCommand]
        public async Task Login()
        {
            if (!IsLoginFormValid())
            {
                MessageBox.Show("Formulaire invalide");
                return;
            }

            try
            {
                MessageBox.Show($"Login en cours {_authenticationService.IsLoggedIn}");
                var result = await _authenticationService.Login(Username, Password);
                MessageBox.Show($"Login réussi {result} {_authenticationService.IsLoggedIn}");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}");
                return;
            }

        }
        #endregion

        #region Méthodes de validations
        /// <summary>
        /// Valider si username et password sont remplis
        /// </summary>
        private bool IsLoginFormValid()
        {

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                return false;
            }

            // Méthode de validation de ObservableValidator
            ValidateAllProperties();

            // Validation ObservableValidator
            if (HasErrors)
            {
                return false;
            }

            if (Username.Length < _UsernameMinLength || Username.Length > _UsernameMaxLength)
            {
                return false;
            }

            if (Password.Length < _PasswordMinLength || Password.Length > _PasswordMaxLength)
            {
                return false;
            }


            return true;
        }

        #endregion

    }
}
