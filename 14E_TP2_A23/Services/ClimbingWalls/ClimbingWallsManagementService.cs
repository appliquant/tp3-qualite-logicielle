using _14E_TP2_A23.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14E_TP2_A23.Services.ClimbingWalls
{
    /// <summary>
    /// Service de gestion des murs d'escalade
    /// </summary>
    public partial class ClimbingWallsManagementService : ObservableObject, IClimbingWallsManagementService
    {
        #region Propriétés
        private readonly IDALService _dal;
        #endregion

        #region Constructeur
        public ClimbingWallsManagementService(IDALService dalService)
        {
            _dal = dalService;
        }


        #endregion

        #region Méthodes

        /// <summary>
        /// Réupère tous les murs d'escalades
        /// </summary>
        /// <returns>Une liste des mures d'escalades</returns>
        public async Task<ObservableCollection<ClimbingWall>> GetAllClimbingWalls()
        {
            try
            {
                return await _dal.GetAllClimbingWallsAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Réupère tous les murs d'escalades
        /// </summary>
        /// <returns>Une liste des murs d'esclades</returns>
        public async Task<ObservableCollection<ClimbingRoute>> GetAllClimbingRoutes()
        {
            try
            {
                return await _dal.GetAllClimbingRoutesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
