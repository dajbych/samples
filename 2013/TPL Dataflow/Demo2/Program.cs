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

            // paralelní řešení

            var ab = new ActionBlock<int>(async i => {
                await Task.Delay(1000);
                Console.WriteLine(i);
            }, new ExecutionDataflowBlockOptions { TaskScheduler = TaskScheduler.Default, MaxDegreeOfParallelism = 8 }); // používej standardní Thread Pool a vracuj nanejvýše v osmí vláknech

            for (int i = 0; i < 10; i++) ab.Post(i); // zpracuj data
            ab.Complete(); // nepříjmej žádná další data
            ab.Completion.Wait(); // blokuj toto vlákno do ukončení všech pomocných vláken z thread poolu

            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}