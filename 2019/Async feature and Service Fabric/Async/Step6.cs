using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Dajbych {
    static class Step6 {

        // concurrent collections

        static readonly ConcurrentBag<string> bag = new ConcurrentBag<string>();

        public static async Task RunAsync() {
            var a = DoJobAsync();
            var b = DoJobAsync();
            var c = DoJobAsync();
            await Task.WhenAll(a, b, c);

            while (bag.TryTake(out string response)) {
                Console.WriteLine($"Downloaded {response.Length} characters (step 6)");
            }
        }

        private static async Task DoJobAsync() {
            // continue in any thread
            var response = await Step3.DoWorkAsync().ConfigureAwait(false);
            bag.Add(response);
        }

    }
}
