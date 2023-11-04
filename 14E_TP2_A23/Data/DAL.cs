using _14E_TP2_A23.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _14E_TP2_A23.Data
{
    public sealed class DAL : IDALService
    {
        //// Initilisation classe en tant que singelton
        //private static readonly Lazy<DAL> lazyClient = new Lazy<DAL>(() => new DAL() );

        ///// <summary>
        ///// Accées à la connection
        ///// </summary>
        //public static DAL Instance => lazyClient.Value;

        /// <summary>
        /// Nom de la base de donnée
        /// </summary>
        public static readonly string DB_NAME = "TP2DB";

        /// <summary>
        /// Client Mongo
        /// </summary>
        //private MongoClient mongoDBClient { get; set;}

        public DAL()
        {
            //mongoDBClient = OpenConnection();
        }

        public MongoClient OpenConnection()
        {
            const string dbPassword = "MiDCY3eaRELztkpQ";
            const string dbUser = "tp3-qualite-logicielle";
            const string connectionUri = $"mongodb+srv://{dbUser}:{dbPassword}@tp2-qualite-logicielle.mjzutxk.mongodb.net/?retryWrites=true&w=majority";

            var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionUri));
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            MongoClient client = null;

            try
            {
                client = new MongoClient(settings);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données " + ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return client;
        }

    }
}
