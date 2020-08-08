using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Topluluk_Duyuru.Models
{
    public class Duyuru
    {
        public Object _id { get; set; }
        public string duyuruKonu { get; set; }
        public string duyuruIcerik { get; set; }
        public string duyuruSahip { get; set; }
        public string duyuruBaslangic { get; set; }
        public string duyuruBitis { get; set; }
    }
}