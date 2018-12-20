using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Dajbych {
    static class Step4 {

        // concurrent collections

        static ConcurrentBag<string> bag = new ConcurrentBag<string>();

        public static async Task RunAsync() {
            var a = DoJobAsync();
            var b = DoJobAsync();
            var c = DoJobAsync();
            await Task.WhenAll(a, b, c);

            while (bag.TryTake(out string html)) {
                Console.WriteLine($"Downloaded {html.Length} characters (step 4)");
            }
        }

        private static async Task DoJobAsync() {
            // continue in any thread
            var html = await Step3.DoWorkAsync().ConfigureAwait(false);
            bag.Add(html);
        }

    }
}
