using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Dajbych {
    static class Step8 {

        // async streams

        public static async Task RunAsync() {
            var cts = new CancellationTokenSource();
            var i = 1;
            await foreach (var response in Generator().WithCancellation(cts.Token)) {
                Console.WriteLine($"Downloaded {response.Length} characters (step 8 iteration {i++})");
                if (i > 100) cts.Cancel();
            }
            Console.WriteLine("Done (step 8)");
        }

        private static async IAsyncEnumerable<string> Generator([EnumeratorCancellation] CancellationToken token = default) {
            using var webClient = new WebClient();
            while (!token.IsCancellationRequested) {
                var response = await webClient.DownloadStringTaskAsync(Program.url).ConfigureAwait(false);
                yield return response;
            }
            Console.WriteLine("Producer has ended (step 8)");
        }

    }
}