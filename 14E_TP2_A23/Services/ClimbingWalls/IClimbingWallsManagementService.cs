﻿using _14E_TP2_A23.Models;
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
    public interface IClimbingWallsManagementService
    {
        /// <summary>
        /// Réupère tous les murs d'escalade
        /// </summary>
        Task<ObservableCollection<ClimbingWall>> GetAllClimbingWalls();
    }
}
