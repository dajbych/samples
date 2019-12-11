using System;
using System.Threading.Tasks;

namespace Dajbych {
    static class Step5 {

        // wait synchronously for a result

        public static void Run() {
            var str = DoWork().Result;
            Console.WriteLine(str);
        }

        private static async Task<string> DoWork() {
            var response = await Step3.DoWorkAsync();
            return $"{response} (step 5)";
        }

    }
}