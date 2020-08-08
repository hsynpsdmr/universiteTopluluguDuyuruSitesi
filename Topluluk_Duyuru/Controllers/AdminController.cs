using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Topluluk_Duyuru.Models;

namespace Topluluk_Duyuru.Controllers
{
    public class AdminController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            Models.MongoHelper.ConnectToMongoService();
            Models.MongoHelper.admin_collection = Models.MongoHelper.database.GetCollection<Models.Admin>("admin");
            var user = Builders<Models.Admin>.Filter.Eq("username", admin.username);
            var pass = Builders<Models.Admin>.Filter.Eq("password", admin.password);

            if (user != null && pass != null)
            {
                FormsAuthentication.SetAuthCookie(admin.username, false);
                return RedirectToAction("Create", "Duyuru");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz Kullanıcı Adı veya Şifre";
                return View();
            }

        }
    }
}