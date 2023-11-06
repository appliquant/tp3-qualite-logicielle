using _14E_TP2_A23.Data;
using _14E_TP2_A23.Services;
using _14E_TP2_A23.ViewModels;
using _14E_TP2_A23.Views;
using _14E_TP2_A23.Views.DashboardPages;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Windows;
using System.Windows.Controls;

namespace _14E_TP2_A23
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Référence à l'application courante
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Services de l'application
        /// </summary>
        public IServiceProvider Services { get; private set; }

        public App()
        {
            Services = ConfigureServices();
        }

        /// <summary>
        /// Initialise les services de l'application (injection de dépendances)
        /// Transiant = nouvelle instance à chaque appel
        /// Singleton = une seule instance pour toute l'application
        /// </summary>
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IMongoClient>(provider =>
            {
                const string dbPassword = "MiDCY3eaRELztkpQ";
                const string dbUser = "tp3_qualite_logicielle";
                const string connectionUri = $"mongodb+srv://{dbUser}:{dbPassword}@cluster0.7iuzeeb.mongodb.net/?retryWrites=true&w=majority";

                var settings = MongoClientSettings.FromConnectionString(connectionUri);
                settings.ServerApi = new ServerApi(ServerApiVersion.V1);
                return new MongoClient(settings);
            });


            services.AddSingleton<IDALService, DAL>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IAppNavigationService, AppNavigationService>();

            // Services automatiquement injectés dans le constructeur des ViewModels
            services.AddTransient<MainViewModel>();
            services.AddTransient<DashboardViewModel>();

            return services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow = new MainWindow();
            MainWindow.Show();

            // Setup service de navigation
            var navigationService = Services.GetRequiredService<IAppNavigationService>() as AppNavigationService;
            var mainFrame = MainWindow.FindName("MainFrame") as Frame;

            // Initialize the navigation service with the frame
            if (navigationService != null && mainFrame != null)
            {
                navigationService.Initialize(mainFrame);

                // Enregister les pages et fenêtres (ne pas enregister MainWindow pour eviter duplication)
                navigationService.RegisterPage("DashboardPage", typeof(DashboardPage));
                navigationService.RegisterPage("AddClientPage", typeof(AddClientPage));
            }
        }

    }
}
