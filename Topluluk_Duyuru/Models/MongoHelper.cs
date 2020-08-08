using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace Topluluk_Duyuru.Models
{
    public class MongoHelper
    {
        public static IMongoClient client { get; set; }
        public static IMongoDatabase database { get; set; }
        public static string MongoConnection = "mongodb+srv://duyuru_admin:hsynpsdmr@duyuru-rvsc9.gcp.mongodb.net/test?retryWrites=true&w=majority";
        public static string MongoDatabase = "universite_topluluk";

        public static IMongoCollection<Models.Duyuru>duyurular_collection { get; set; }
        public static IMongoCollection<Models.Admin>admin_collection { get; set; }

        internal static void ConnectToMongoService()
        {
            try
            {
                client = new MongoClient(MongoConnection);
                database = client.GetDatabase(MongoDatabase);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}