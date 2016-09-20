using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Dajbych.Demo4.Models {
    public class Image {
        
        public int Id { get; set; }
        
        [MaxLength]
        public string Url { get; set; }

        public Aircraft Aircraft { get; set; }

        [NotMapped]
        public Uri Uri {
            get {
                return new Uri(Url);
            }
        }

    }
}