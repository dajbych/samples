using System;
using System.Threading.Tasks;

namespace Dajbych {
    static class Step7 {

        // function injection

        public static async Task RunAsync() {
            Console.Write("Working on ");

            for (var i = 0; i < 10; i++) {
                await DoWork(i, async x => {
                    await Task.Delay(500);
                    Console.Write($"step {x}");
                }, async () => {
                    await Task.Delay(500);
                });
            }

            Console.WriteLine(".");
        }

        private static async Task DoWork(int i, Func<int, Task> methodA, Func<Task> methodB) {
            if (i == 3) {
                await methodA(i);
            } else {
                await methodB();
            }
        }

    }
}