using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Diagnostics;

namespace Dajbych.Demo6.Models {
    public class DemoDb : DbContext {

        private DemoDb() : base(@"Data Source=.\SQLEXPRESS;Initial Catalog=Demo;Integrated Security=SSPI;") {
            var initializer = new Initializer();
            Database.SetInitializer(initializer);
        }

        public DbSet<Machine> Machines { get; set; }
        

        public static DemoDb Connection {
            get {
                return new DemoDb();
            }
        }
    }

    public class Initializer : DropCreateDatabaseIfModelChanges<DemoDb> {
        protected override void Seed(DemoDb db) {

            var messerschmitt = new Machine { Name = "Škoda 109E", Url = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/fd/380.002-6_%C5%A0koda_109E_1.jpg/800px-380.002-6_%C5%A0koda_109E_1.jpg" };
            var alca = new Machine { Name = "Aero L-159", Url = "http://upload.wikimedia.org/wikipedia/commons/thumb/c/c6/Czech_Air_Force_Aero_L-159A_ALCA_Lofting-2.jpg/800px-Czech_Air_Force_Aero_L-159A_ALCA_Lofting-2.jpg" };
            var tatra = new Machine { Name = "Tatra 810", Url = "http://upload.wikimedia.org/wikipedia/commons/thumb/4/4c/Tatra_T-810_Czech_Army_01.jpg/800px-Tatra_T-810_Czech_Army_01.jpg" };
            var forcity = new Machine { Name = "Škoda 15T", Url = "http://upload.wikimedia.org/wikipedia/commons/thumb/0/05/%C5%A0koda_15T%2C_smy%C4%8Dka_Radlick%C3%A1.jpg/800px-%C5%A0koda_15T%2C_smy%C4%8Dka_Radlick%C3%A1.jpg" };
            var pss = new Machine { Name = "Věra-NG", Url = "http://upload.wikimedia.org/wikipedia/commons/thumb/7/7d/ILA_Berlin_2012_PD_040.JPG/400px-ILA_Berlin_2012_PD_040.JPG" };

            db.Machines.Add(messerschmitt);
            db.Machines.Add(alca);
            db.Machines.Add(tatra);
            db.Machines.Add(forcity);
            db.Machines.Add(pss);

        }
    }
}