using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dajbych {
    static class Step4 {

        // async Task vs. async void
        // use of cancellation token

        public static async Task RunAsync() {
            var cts = new CancellationTokenSource();
            FireAndForget(cts);
            await DoWork(cts.Token);
            Console.WriteLine("Done");
        }

        private static async Task DoWork(CancellationToken cancellationToken) {
            int i = 1;
            while (!cancellationToken.IsCancellationRequested) {
                Console.WriteLine($"Working (step 4 iteration {i++})");
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        private static async void FireAndForget(CancellationTokenSource cts) {
            await Task.Delay(TimeSpan.FromSeconds(3));
            cts.Cancel();
        }

    }
}