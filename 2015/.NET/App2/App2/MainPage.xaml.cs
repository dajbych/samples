using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App2 {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {

        public MainPage() {
            this.InitializeComponent();
        }


        private async void Button_Click(object sender, RoutedEventArgs e) {
            var aaa = Download("http://fel.cvut.cz");
            var bbb = Download("http://fel.cvut.cz");

            aaa.Start();
            bbb.Start();

            await Task.WaitAll(aaa, bbb);
        }

        private async Task<string> Download(string url) {
            using (var hc = new HttpClient()) {
                return await hc.GetStringAsync(url);
            }
        }

    }
}