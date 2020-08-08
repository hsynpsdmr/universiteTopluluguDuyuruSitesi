using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;

namespace Topluluk_Duyuru.Controllers
{
    public class DuyuruListController:Controller
    {
        public ActionResult List()
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.duyurular_collection =
                Models.MongoHelper.database.GetCollection<Models.Duyuru>("duyurular");
            var filter = Builders<Models.Duyuru>.Filter.Ne("_id", "");
            var result = Models.MongoHelper.duyurular_collection.Find(filter).ToList();

            return View(result);
        }
    }
}