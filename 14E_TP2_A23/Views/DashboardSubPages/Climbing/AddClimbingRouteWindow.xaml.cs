using _14E_TP2_A23.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Media;

namespace _14E_TP2_A23.Views.DashboardSubPages.Climbing
{
    /// <summary>
    /// Logique d'interaction pour AddClimbingRouteWindow.xaml
    /// </summary>
    public partial class AddClimbingRouteWindow : Window
    {
        /// <summary>
        /// Voie d'escalade à ajouter
        /// </summary>
        public ClimbingRoute? ClimbingRoute { get; set; }

        public AddClimbingRouteWindow()
        {
            InitializeComponent();
            cbHoldsColor.ItemsSource = _GetColors();
        }

        /// <summary>
        /// Retourne une liste de couleurs
        /// </summary>
        private List<string> _GetColors()
        {
            return new List<string>
            {
                "Rouge",
                "Bleu",
                "Vert",
                "Jaune",
                "Noir",
                "Blanc",
                "Orange",
                "Rose",
                "Violet",
                "Marron",
                "Gris",
                "Beige",
                "Autre"
            };
        }

        /// <summary>
        /// Événement ajout d'une voie d'escalade
        /// </summary>
        private void btnAddClimbingRoute_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Événement annulation de l'ajout d'une voie d'escalade
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }


    }
}
