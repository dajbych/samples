using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using Windows.Data.Json;

namespace App1.ViewModels {
    public class ViewModel {

        public ViewModel() {
            Init();
        }

        public async void Init() {
            using (var ht = new HttpClient()) {
                var json = await ht.GetStringAsync("http://www.airport-data.com/api/ac_thumb.json?m=49D1CD&n=10");
                var obj = JsonObject.Parse(json);
                var images = (from item in obj.GetNamedArray("data") let image = item.GetObject().GetNamedString("image") select new Uri(image)).ToList();
                foreach (var image in images) {
                    Images.Add(image);
                }
            }
        }

        public ObservableCollection<Uri> Images { get; } = new ObservableCollection<Uri>();

    }
}