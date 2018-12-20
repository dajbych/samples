using System;
using System.Net;
using System.Threading.Tasks;

namespace Dajbych {
    static class Step3 {

        // async / await

        public static async Task RunAsync() {
            var html2 = await DoWorkAsync();
            Console.WriteLine($"Downloaded {html2.Length} characters (step 3)");
        }

        internal static async Task<string> DoWorkAsync() {
            using (var webClient = new WebClient()) {
                return await webClient.DownloadStringTaskAsync(Program.url);
            }
        }

    }
}