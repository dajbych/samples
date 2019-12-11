using System;
using System.Net;
using System.Threading;

namespace Dajbych {
    static class Step1 {

        // parallel programming

        private class MyThreadOutput {
            public string Text { get; set; }
        }

        public static void Run() {
            var response = new MyThreadOutput();
            var thread = new Thread(new ParameterizedThreadStart(DoWork));
            thread.Start(response);
            thread.Join();
            Console.WriteLine($"Downloaded {response.Text.Length} characters (step 1)");
        }

        private static void DoWork(object output) {
            using var webClient = new WebClient();
            // blocking call
            var response = webClient.DownloadString(Program.url);
            ((MyThreadOutput)output).Text = response;
        }

    }
}