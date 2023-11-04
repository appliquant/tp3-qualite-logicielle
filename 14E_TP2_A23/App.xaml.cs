using _14E_TP2_A23.Data;
using _14E_TP2_A23.Services;
using _14E_TP2_A23.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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
        public IServiceProvider Services { get; }

        public App()
        {
            Services = ConfigureServices();
        }

        /// <summary>
        /// Initialise les services de l'application
        /// Transiant = nouvelle instance à chaque appel
        /// Singleton = une seule instance pour toute l'application
        /// </summary>
        public static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IDALService, DAL>();
            services.AddTransient<MainViewModel>();

            // MainViewModel et passer en paramètre le service IDALService
            //_ = services.AddTransient(provider => new MainViewModel(provider.GetService<IDALService>()));

            return services.BuildServiceProvider();
        }
    }
}
