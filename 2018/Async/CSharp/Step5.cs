using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dajbych {
    static class Step5 {

        // use of cancellation token

        public static async Task RunAsync() {
            var cts = new CancellationTokenSource();
            FireAndForget(cts);
            await DoWork(cts.Token);
            Console.WriteLine("Done");
        }

        private static async Task DoWork(CancellationToken cancellationToken) {
            while (!cancellationToken.IsCancellationRequested) {
                Console.WriteLine($"Working (step 5)");
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        private static async void FireAndForget(CancellationTokenSource cts) {
            await Task.Delay(TimeSpan.FromSeconds(3));
            cts.Cancel();
        }

    }
}