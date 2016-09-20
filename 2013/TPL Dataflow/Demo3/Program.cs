using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Dajbych.Demo.TplDataflow {
    class Program {
        static void Main(string[] args) {

            // vytváření datového toku mezi bloky

            var execution = new ExecutionDataflowBlockOptions { TaskScheduler = TaskScheduler.Default, MaxDegreeOfParallelism = 8 }; // používej standardní Thread Pool a vracuj nanejvýše v osmí vláknech
            var link = new DataflowLinkOptions { PropagateCompletion = true }; // pokud se dokončí vstupní blok, čekej ještě do ukončení výstupnho bloku

            var ab = new ActionBlock<int>(async i => {
                await Task.Delay(1000);
                Console.WriteLine(i);
            }, execution); 

            var tb = new TransformBlock<int, int>(async i => {
                await Task.Delay(500);
                return i * 2;
            }, execution);

            tb.LinkTo(ab, link); // tb -> ab

            for (int i = 0; i < 10; i++) tb.Post(i); // zpracuj data
            tb.Complete(); // nepříjmej žádná další data do vstupního bloku
            ab.Completion.Wait(); // blokuj toto vlákno do ukončení výstupního bloku

            Console.WriteLine("done");
            Console.ReadLine();

        }
    }
}