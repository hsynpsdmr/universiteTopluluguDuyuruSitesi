using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;


namespace Topluluk_Duyuru.Models
{
    public class Admin
    {
        public ObjectId id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}