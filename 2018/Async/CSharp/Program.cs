using System;

namespace Dajbych {
    public static class Program {

        public static readonly Uri url = new Uri("http://localhost:55558/");

        public static void Main(string[] args) {

            Step1.Run();
            Step2.Run();
            Step3.RunAsync().Wait();
            Step4.RunAsync().Wait();
            Step5.RunAsync().Wait();
            Step6.Run();
            Step7.RunAsync().Wait();
            Step8.RunAsync().Wait();

            Console.ReadLine();
        }

    }
}