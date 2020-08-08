using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Topluluk_Duyuru.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Test()
        {
            //Veri tabanına duyuru kaydetme kontrolü
            List<Models.Duyuru> duyurular = new List<Models.Duyuru>();

            Models.Duyuru duyuru1 = new Models.Duyuru();
            duyuru1._id = GenerateRandomId(24);
            duyuru1.duyuruKonu = "Bisiklet Turu";
            duyuru1.duyuruIcerik = "10.05.2020 Tarihinde Orduzuda bisiklet turu yapılacaktır katılmak " +
                "isteyenler bizimle iletişime geçip sayı bildirmeleri gerekmektedir.";
            duyuru1.duyuruSahip = "Bisiklet Topluluğu";
            duyuru1.duyuruBaslangic = "05.05.2020";
            duyuru1.duyuruBitis = "10.05.2020";
            duyurular.Add(duyuru1);

            Models.Duyuru duyuru2 = new Models.Duyuru();
            duyuru2._id = GenerateRandomId(24);
            duyuru2.duyuruKonu = "Fotoğrafçılık Eğitimi";
            duyuru2.duyuruIcerik = "Bu hafta cuma günü üniversite içinde fotoğraf çekimleri yapacağız ve " +
                "sizlere nasıl daha iyi fotoğraf çekilir onu öğreteceğiz. Fotoğraf makinası olan arkadaşlar " +
                "kendi makinalarını getirirlerse daha iyi olur.";
            duyuru2.duyuruSahip = "Fotoğrafçılık Topluluğu";
            duyuru2.duyuruBaslangic = "05.05.2020";
            duyuru2.duyuruBitis = "08.05.2020";

            duyurular.Add(duyuru2);


            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.duyurular_collection = Models.MongoHelper.database.GetCollection<Models.Duyuru>("duyurular");

            Models.MongoHelper.duyurular_collection.InsertManyAsync(duyurular);



            //Veri tabanındaki verileri listeleme kontrolü
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.duyurular_collection =
                Models.MongoHelper.database.GetCollection<Models.Duyuru>("duyurular");
            var filter = Builders<Models.Duyuru>.Filter.Ne("_id", "");
            var result = Models.MongoHelper.duyurular_collection.Find(filter).ToList();

            return View(result);

        }
        private static Random random = new Random();
        private object GenerateRandomId(int v)
        {
            string strarray = "abcdefghijklmnoprstuvwxyz123456789";
            return new string(Enumerable.Repeat(strarray, v).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public ActionResult Test2()
        {
            try
            {
                Models.MongoHelper.ConnectToMongoService();
                Models.MongoHelper.duyurular_collection =
                    Models.MongoHelper.database.GetCollection<Models.Duyuru>("duyurular");
                var filter = Builders<Models.Duyuru>.Filter.Eq("_id", "3s8ifkxsla676kc774bb8dc2");

                var result = Models.MongoHelper.duyurular_collection.DeleteOneAsync(filter);

                var filter2 = Builders<Models.Duyuru>.Filter.Ne("_id", "");
                var result2 = Models.MongoHelper.duyurular_collection.Find(filter2).ToList();

                return View(result2);
            }
            catch
            {
                return View();
            }
        }

    }
    
}
