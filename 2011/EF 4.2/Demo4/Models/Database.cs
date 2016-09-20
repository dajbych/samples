using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Diagnostics;

namespace Dajbych.Demo4.Models {
    public class DemoDb : DbContext {

        private DemoDb() : base(@"Data Source=.\SQLEXPRESS;Initial Catalog=Demo;Integrated Security=SSPI;") {
            var initializer = new Initializer();
            Database.SetInitializer(initializer);
        }

        public DbSet<Image> Images { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }

        public static DemoDb Connection {
            get {
                return new DemoDb();
            }
        }
    }

    public class Initializer : DropCreateDatabaseIfModelChanges<DemoDb> {
        protected override void Seed(DemoDb db) {

            var b737 = new Aircraft { Manufacturer = "Boeing", Type = "737", Name = "Bulík", Images = new List<Image>() };
            var b747 = new Aircraft { Manufacturer = "Boeing", Type = "747", Name = "Jumbo Jet", Images = new List<Image>() };
            var b787 = new Aircraft { Manufacturer = "Boeing", Type = "787", Name = "Dreamliner", Images = new List<Image>() };
            var a320 = new Aircraft { Manufacturer = "Airbus", Type = "320", Images = new List<Image>() };
            var a380 = new Aircraft { Manufacturer = "Airbus", Type = "380", Name = "Lady Bee", Images = new List<Image>() };
            var a350 = new Aircraft { Manufacturer = "Airbus", Type = "350", Images = new List<Image>() };

            db.Aircrafts.Add(b737);
            db.Aircrafts.Add(b747);
            db.Aircrafts.Add(b787);
            db.Aircrafts.Add(a320);
            db.Aircrafts.Add(a350);
            db.Aircrafts.Add(a380);


            b737.Images.Add(new Image { Url = "http://czechspotters.net/photo/GZGJM39OMKB9CN9P.jpg" });
            b737.Images.Add(new Image { Url = "http://czechspotters.net/photo/9CZQ3WEPJ1URLJKA.jpg" });
            b737.Images.Add(new Image { Url = "http://czechspotters.net/photo/UORK5GN8XJ68ONXY.jpg" });
            b737.Images.Add(new Image { Url = "http://czechspotters.net/photo/WHXDR56YKPHQCPNR.jpg" });
            a320.Images.Add(new Image { Url = "http://czechspotters.net/photo/NZJUR1LMVH71NJRN.jpg" });
            a320.Images.Add(new Image { Url = "http://czechspotters.net/photo/V8SZ9MUPJVPAK4A7.jpg" });
            a320.Images.Add(new Image { Url = "http://czechspotters.net/photo/9B74O8CHUXRRSBOJ.jpg" });
            b787.Images.Add(new Image { Url = "http://cdn-www.airliners.net/aviation-photos/photos/7/0/1/1892107.jpg" });
            b787.Images.Add(new Image { Url = "http://cdn-www.airliners.net/aviation-photos/photos/0/3/5/1630530.jpg" });
            b747.Images.Add(new Image { Url = "http://czechspotters.net/photo/6FN4GRLG2M1CNUZZ.jpg" });
            b747.Images.Add(new Image { Url = "http://czechspotters.net/photo/6WFY2TT4GMWD392E.jpg" });
            b747.Images.Add(new Image { Url = "http://czechspotters.net/photo/FVBMJ7EOW1TYLJBA.jpg" });
            a350.Images.Add(new Image { Url = "http://www.thierry3d.com/wp-content/gallery/gallerybook/A350-1000_Airbus_10.jpg" });
            a350.Images.Add(new Image { Url = "http://www.wired.com/images_blogs/autopia/2011/12/80bf161c501.jpg" });
            a380.Images.Add(new Image { Url = "http://czechspotters.net/photo/LPRF66KACE451T1U.jpg" });
            a380.Images.Add(new Image { Url = "http://czechspotters.net/photo/L9XDN7Q43LTHJIOP.jpg" });
            a380.Images.Add(new Image { Url = "http://czechspotters.net/photo/E62SB49F1SJN1X2N.jpg" });
        }
    }
}