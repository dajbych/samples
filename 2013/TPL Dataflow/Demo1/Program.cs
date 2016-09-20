using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Dajbych.Demo.TplDataflow {
    class Program {
        static void Main(string[] args) {

            // sekvenční řešení

            var ab = new ActionBlock<int>(i => {
                Thread.Sleep(1000);
                Console.WriteLine(i);
            });

            for (int i = 0; i < 10; i++) ab.Post(i); // zpracuj data

            Console.WriteLine("done");
            Console.ReadLine();

        }
    }
}