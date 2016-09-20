using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Dajbych.Demo6.Models {
    public class Machine {

        public int Id { get; set; }

        public string Name { get; set; }

        [MaxLength]
        public string Url { get; set; }

        public override string ToString() {
            return Name;
        }
    }
}