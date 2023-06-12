using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();

            //Demo 2 task when all
            var demo2 = new Demo2();
            await demo2.Run();

            ////Demo 1
            //ShowThreadInformation("Main");

            //var coffeeTask = await TakeCoffeeAsync();

            //for (var i = 0; i < 5; i++)
            //{
            //    Console.WriteLine("Do something " + i);
            //    Thread.Sleep(1000);
            //}

            //var coffee = coffeeTask;
            //Console.WriteLine(coffee);

            sw.Stop();
            Console.WriteLine("ElapsedMilliseconds: " + sw.ElapsedMilliseconds);

            Console.ReadKey();
        }

        public static async Task<string> TakeCoffeeAsync()
        {
            Console.WriteLine("Making coffee...");
            await Task.Delay(0);



            Console.WriteLine("Coffee is ready!");
            ShowThreadInformation("TakeCoffeeAsync");
            return "Here's your coffee.";
        }

        private static void ShowThreadInformation(string name)
        {
            var thread = Thread.CurrentThread;
            var msg = $"{name} thread information\n" +
                      $"   Background: {thread.IsBackground}\n" +
                      $"   Thread Pool: {thread.IsThreadPoolThread}\n" +
                      $"   Thread ID: {thread.ManagedThreadId}\n";
            Console.WriteLine(msg);
        }
    }
}