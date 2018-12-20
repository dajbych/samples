using System;
using System.Threading.Tasks;

namespace Dajbych {
    static class Step6 {

        // wait synchronously for a result

        public static void Run() {
            var str = DoWork().Result;
            Console.WriteLine(str);
        }

        private static async Task<string> DoWork() {
            await Task.Delay(TimeSpan.FromSeconds(1));
            return "Done (step 6)";
        }

    }
}