using System;
using System.Threading.Tasks;

namespace Dajbych {
    public static class Program {

        public static readonly Uri url = new Uri("http://localhost:52811/");

        public static async Task Main(string[] args) {

            // start WebApp without debugging first

            Step1.Run();
            Step2.Run();
            await Step3.RunAsync();
            await Step4.RunAsync();
            Step5.Run();
            await Step6.RunAsync();
            await Step7.RunAsync();
            await Step8.RunAsync();
        }

    }
}
