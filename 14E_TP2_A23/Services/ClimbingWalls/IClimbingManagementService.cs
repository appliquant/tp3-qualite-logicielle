using _14E_TP2_A23.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14E_TP2_A23.Services.ClimbingWalls
{
    /// <summary>
    /// Interface du service de gestion des murs d'escalade
    /// </summary>
    public interface IClimbingManagementService
    {
        /// <summary>
        /// Réupère tous les murs d'escalade
        /// </summary>
        Task<ObservableCollection<ClimbingWall>> GetAllClimbingWalls();

        /// <summary>
        /// Récupère toutes les voies d'esclades
        /// </summary>
        Task<ObservableCollection<ClimbingRoute>> GetAllClimbingRoutes();

        /// <summary>
        /// Ajouter une voie d'escalade
        /// </summary>
        Task<bool> AddClimbingRoute(ClimbingRoute climbingRoute);
    }
}
