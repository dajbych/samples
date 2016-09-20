using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dajbych.Demo4.Models {
    public class Aircraft {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}