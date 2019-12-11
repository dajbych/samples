using System;
using System.Net;
using System.Threading.Tasks;

namespace Dajbych {
    static class Step3 {

        // async / await

        public static async Task RunAsync() {
            var response = await DoWorkAsync();
            Console.WriteLine($"Downloaded {response.Length} characters (step 3)");
        }

        internal static async Task<string> DoWorkAsync() {
            using var webClient = new WebClient();
            return await webClient.DownloadStringTaskAsync(Program.url);
        }

    }
}