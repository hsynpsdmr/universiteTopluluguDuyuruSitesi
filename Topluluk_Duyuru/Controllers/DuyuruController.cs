using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;

namespace Topluluk_Duyuru.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        public ActionResult Index()
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.duyurular_collection =
                Models.MongoHelper.database.GetCollection<Models.Duyuru>("duyurular");
            var filter = Builders<Models.Duyuru>.Filter.Ne("_id", "");
            var result = Models.MongoHelper.duyurular_collection.Find(filter).ToList();

            return View(result);
        }

        // GET: Duyuru/Details/5
        public ActionResult Details(string id)
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.duyurular_collection =
                Models.MongoHelper.database.GetCollection<Models.Duyuru>("duyurular");
            var filter = Builders<Models.Duyuru>.Filter.Eq("_id", id);
            var result = Models.MongoHelper.duyurular_collection.Find(filter).FirstOrDefault();
            return View(result);

        }

        // GET: Duyuru/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Duyuru/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Models.MongoHelper.ConnectToMongoService();
                Models.MongoHelper.duyurular_collection = Models.MongoHelper.database.GetCollection<Models.Duyuru>("duyurular");

                Object id = GenerateRandomId(24);

                Models.MongoHelper.duyurular_collection.InsertOneAsync(new Models.Duyuru {
                   
                    _id = id,
                    duyuruKonu=collection["duyuruKonu"],
                    duyuruIcerik=collection["duyuruIcerik"],
                    duyuruSahip=collection["duyuruSahip"],
                    duyuruBaslangic=collection["duyuruBaslangic"],
                    duyuruBitis=collection["duyuruBitis"]
                });
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private static Random random = new Random();
        private object GenerateRandomId(int v)
        {
            string strarray = "abcdefghijklmnoprstuvwxyz123456789";
            return new string(Enumerable.Repeat(strarray, v).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // GET: Duyuru/Edit/5
        public ActionResult Edit(string id)
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.duyurular_collection =
                Models.MongoHelper.database.GetCollection<Models.Duyuru>("duyurular");
            var filter = Builders<Models.Duyuru>.Filter.Eq("_id", id);
            var result = Models.MongoHelper.duyurular_collection.Find(filter).FirstOrDefault();
            return View(result);
        }

        // POST: Duyuru/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                Models.MongoHelper.ConnectToMongoService();
                Models.MongoHelper.duyurular_collection =
                    Models.MongoHelper.database.GetCollection<Models.Duyuru>("duyurular");
                var filter = Builders<Models.Duyuru>.Filter.Eq("_id", id);

                var update = Builders<Models.Duyuru>.Update
                    .Set("duyuruKonu", collection["duyuruKonu"])
                    .Set("duyuruIcerik", collection["duyuruIcerik"])
                    .Set("duyuruSahip", collection["duyuruSahip"])
                    .Set("duyuruBaslangic", collection["duyuruBaslangic"])
                    .Set("duyuruBitis", collection["duyuruBitis"]);
                var result = Models.MongoHelper.duyurular_collection.UpdateOneAsync(filter, update);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Duyuru/Delete/5
        public ActionResult Delete(string id)
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.duyurular_collection =
                Models.MongoHelper.database.GetCollection<Models.Duyuru>("duyurular");
            var filter = Builders<Models.Duyuru>.Filter.Eq("_id", id);
            var result = Models.MongoHelper.duyurular_collection.Find(filter).FirstOrDefault();
            return View(result);
        }

        // POST: Duyuru/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                Models.MongoHelper.ConnectToMongoService();
                Models.MongoHelper.duyurular_collection =
                    Models.MongoHelper.database.GetCollection<Models.Duyuru>("duyurular");
                var filter = Builders<Models.Duyuru>.Filter.Eq("_id", id);

                var result = Models.MongoHelper.duyurular_collection.DeleteOneAsync(filter);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
