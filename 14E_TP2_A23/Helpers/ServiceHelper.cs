﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14E_TP2_A23.Helpers
{
    /// <summary>
    /// Classe pour accéder aux services de l'applications.
    /// Services définis dans "App.xaml.cs"
    /// </summary>
    public static class ServiceHelper
    {
        /// <summary>
        /// Retourne un service
        /// </summary>
        /// <typeparam name="TService">Type du service</typeparam>
        /// <returns></returns>
        public static TService GetService<TService>() => App.Current.Services.GetService<TService>();
    }
}
