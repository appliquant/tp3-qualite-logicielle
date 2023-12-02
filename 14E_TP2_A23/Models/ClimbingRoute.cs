using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Drawing;
using System.Collections.Generic;

namespace _14E_TP2_A23.Models
{
    /// <summary>
    /// Représente une voie d'escalade
    /// </summary>
    public class ClimbingRoute
    {
        #region Propriétés
        /// <summary>
        /// Id de la voie. Auto-généré par MongoDB
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Mur auquel la voie est associée
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("wallId")]
        public string? WallId { get; set; }


        /// <summary>
        /// Difficulté de la voie
        /// </summary>
        [BsonElement("difficulty")]
        public float Difficulty { get; set; }

        /// <summary>
        /// Couleur des prises de la voie
        /// </summary>
        [BsonElement("holdsColor")]
        public Color HoldsColor { get; set; }

        /// <summary>
        /// Liste des évaluations de la difficulté de la voie
        /// </summary>
        [BsonElement("ratings")]
        public List<ClimbingRouteEvaluation> Ratings { get; set; }
        #endregion

        #region Constructeur
        public ClimbingRoute()
        {
            Ratings = new List<ClimbingRouteEvaluation>();
        }

        public ClimbingRoute(float difficulty, Color holdsColor)
        {
            Difficulty = difficulty;
            HoldsColor = holdsColor;
            Ratings = new List<ClimbingRouteEvaluation>();
        }

        public ClimbingRoute(float difficulty, Color holdsColor, List<ClimbingRouteEvaluation> ratings)
        {
            Difficulty = difficulty;
            HoldsColor = holdsColor;
            Ratings = ratings;
        }

        #endregion

    }
}
