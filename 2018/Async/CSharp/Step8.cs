using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Dajbych {
    static class Step8 {

        // awaitable / awaiter pattern

        public static async Task RunAsync() {
            var myClass = new MyCalc();
            var count = await myClass.Multiply(3, 3);
            Console.WriteLine(count);
        }

        private class MyCalc {
            public MyAwaitableMethod Multiply(int a, int b) {
                return new MyAwaitableMethod(a, b);
            }
        }

        private class MyAwaitableMethod {

            int a, b;

            public MyAwaitableMethod(int a, int b) {
                this.a = a;
                this.b = b;
            }

            public MyTaskAwaiter GetAwaiter() { // <-- called by runtime
                return new MyTaskAwaiter(a, b);
            }

        }

        private class MyTaskAwaiter : INotifyCompletion {

            int a, b, result;
            Timer timer;
            Action continuation = null;

            public MyTaskAwaiter(int a, int b) {
                this.a = a;
                this.b = b;
                timer = new Timer(Compute, null, 3000, Timeout.Infinite);
            }

            public bool IsCompleted { get; private set; } // <-- called by runtime

            public int GetResult() => result; // <-- called by runtime

            public void OnCompleted(Action continuation) { // <-- called by runtime
                this.continuation = continuation;
            }

            private void Compute(object state) {
                result = a * b;
                IsCompleted = true;
                continuation();
            }

        }

    }
}