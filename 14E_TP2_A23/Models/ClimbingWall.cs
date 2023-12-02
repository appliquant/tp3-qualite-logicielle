using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace _14E_TP2_A23.Models
{
    /// <summary>
    /// Représente un mur d'escalade
    /// </summary>
    public class ClimbingWall
    {
        #region Propriétés
        /// <summary>
        /// Id du mur. Auto-généré par MongoDB
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// L'emplacement du mur
        /// </summary>
        [BsonElement("location")]
        public string Location { get; set; }

        /// <summary>
        /// Hauteur du mur en mètres
        /// </summary>
        [BsonElement("height")]
        public float Height { get; set; }
        #endregion

        #region Constructeur
        public ClimbingWall()
        {

        }

        public ClimbingWall(string location, int height)
        {
            Location = location;
            Height = height;
        }
        #endregion

    }
}
