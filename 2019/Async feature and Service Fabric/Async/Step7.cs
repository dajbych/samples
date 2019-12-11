using System;
using System.Collections.Concurrent;
using System.Net;
using System.Threading.Tasks;

namespace Dajbych {
    static class Step7 {

        // producer-consumer pattern

        const int n = 100;

        public static async Task RunAsync() {
            var bag = new ConcurrentBag<string>();
            await Task.WhenAll(Producer(bag), Consumer(bag));
            Console.WriteLine("Done (step 7)");
        }

        private static async Task Producer(IProducerConsumerCollection<string> collection) {
            using var webClient = new WebClient();
            for (var i = 0; i < n; i++) {
                var response = await webClient.DownloadStringTaskAsync(Program.url).ConfigureAwait(false);
                collection.TryAdd(response);
            }
            Console.WriteLine("Producer has ended. (step 7)");
        }

        private static async Task Consumer(IProducerConsumerCollection<string> collection) {
            var i = 1;
            do {
                if (collection.TryTake(out string response)) {
                    Console.WriteLine($"Downloaded {response.Length} characters (step 7 iteration {i++})");
                } else {
                    await Task.Delay(40);
                }
            } while (i <= n);
        }

    }
}