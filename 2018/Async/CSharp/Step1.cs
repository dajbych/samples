using System;
using System.Net;
using System.Threading;

namespace Dajbych {
    static class Step1 {

        // parallel programming

        private class MyThreadOutput {
            public string Html { get; set; }
        }

        public static void Run() {
            var result1 = new MyThreadOutput();
            var thread = new Thread(new ParameterizedThreadStart(DoWork));
            thread.Start(result1);
            thread.Join();
            Console.WriteLine($"Downloaded {result1.Html.Length} characters (step 1)");

        }

        private static void DoWork(object result) {
            using (var webClient = new WebClient()) {
                // blocking call
                var html = webClient.DownloadString(Program.url);
                ((MyThreadOutput)result).Html = html;
            }
        }

    }
}