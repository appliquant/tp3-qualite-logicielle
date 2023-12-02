using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace _14E_TP2_A23.Models
{
    /// <summary>
    /// Représente une évaluation de la difficulté d'une voie d'escalade
    /// </summary>
    public class ClimbingRouteEvaluation
    {
        #region Propriétés
        /// <summary>
        /// Id de l'évaluation. Auto-généré par MongoDB
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Note de l'évaluation
        /// </summary>
        [BsonElement("rating")]
        public int Rating { get; set; }
        #endregion

        #region Constructeur
        public ClimbingRouteEvaluation()
        {

        }

        public ClimbingRouteEvaluation(int rating)
        {
            Rating = rating;
        }

        #endregion
    }
}
