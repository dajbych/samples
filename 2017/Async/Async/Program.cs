using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dajbych {
    class Program {
        static void Main(string[] args) {
            Console.OutputEncoding = Encoding.UTF8;

            var source = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            foreach (var i in source) {
                Console.WriteLine($"číslo {i} z vlákna {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(500);
            }

            Console.WriteLine("-----------");

            Parallel.ForEach(source, i => {
                Console.WriteLine($"číslo {i} z vlákna {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);
            });

            Console.WriteLine("-----------");

            Func<int, Task> body = async i => {
                Console.WriteLine($"číslo {i} z vlákna {Thread.CurrentThread.ManagedThreadId}");
                await Task.Delay(TimeSpan.FromSeconds(1));
            };
            var tasks = (from i in source select body(i));
            Task.WhenAll(tasks).Wait();

            Console.WriteLine("Hotovo");
            Console.ReadKey();
        }

    }
}