using System;
using System.Net;
using System.Threading;

namespace Dajbych {
    static class Step2 {

        // asynchronous programming

        public static void Run() {
            var completed = false;
            DoWork(response => {
                Console.WriteLine($"Downloaded {response.Length} characters (step 2)");
                completed = true;
            });
            while (!completed) Thread.Sleep(100);
        }

        private static void DoWork(Action<string> continueWith) {
            var webClient = new WebClient();
            webClient.DownloadStringCompleted += WorkCompleted;
            webClient.DownloadStringAsync(Program.url, continueWith);
        }

        private static void WorkCompleted(object sender, DownloadStringCompletedEventArgs e) {
            var response = e.Result;
            var continueWith = (Action<string>)e.UserState;
            continueWith(response);
            // WebClient is never disposed by GC until
            ((WebClient)sender).DownloadStringCompleted -= WorkCompleted;
        }

    }
}