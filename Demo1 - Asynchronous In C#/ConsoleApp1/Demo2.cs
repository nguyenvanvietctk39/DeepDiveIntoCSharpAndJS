using System.Diagnostics;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public class Demo2
    {
        public async Task Run()
        {
            Stopwatch a = new Stopwatch();
            a.Start();
            var meal = new Meal();
            Console.WriteLine("Preparing the meal...");

            await meal.EatMealAsync();
            a.Stop();
            ShowThreadInformation("Main");
            Console.WriteLine("Finished the meal. Goodbye! " + a.ElapsedMilliseconds);
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

    public class Meal
    {
        public async Task PrepareRiceAsync()
        {
            ShowThreadInformation("PrepareRiceAsync");
            Console.WriteLine("Cooking rice...");
            await Task.Delay(2000); // Assume cooking rice takes 2 seconds
            
            Console.WriteLine("Rice is ready!");
        }

        public async Task PrepareMeatAsync()
        {
            ShowThreadInformation("PrepareMeatAsync");

            Console.WriteLine("Cooking meat...");
            await Task.Delay(2000); // Assume cooking meat takes 3 seconds
            Console.WriteLine("Meat is ready!");
        }

        public async Task PrepareSoupAsync()
        {
            ShowThreadInformation("PrepareSoupAsync");

            Console.WriteLine("Cooking soup...");
            await Task.Delay(2000); // Assume cooking soup takes 2.5 seconds
            Console.WriteLine("Soup is ready!");
        }

        public async Task GetBowlAsync()
        {
            Console.WriteLine("Getting a bowl...");
            await Task.Delay(2000); // Assume getting a bowl takes 1 second
            Console.WriteLine("Got a bowl!");
        }

        public async Task GetChopsticksAsync()
        {
            Console.WriteLine("Getting chopsticks..." + Thread.CurrentThread.ManagedThreadId);
            
            await Task.Delay(1500); // Assume getting chopsticks takes 1.5 seconds
            var thread = Thread.CurrentThread;
            var msg = $"GetChopsticksAsync thread information\n" +
                      $"   Background: {thread.IsBackground}\n" +
                      $"   Thread Pool: {thread.IsThreadPoolThread}\n" +
                      $"   Thread ID: {thread.ManagedThreadId}\n";
            Console.WriteLine(msg);
            Console.WriteLine("Got chopsticks!" + Thread.CurrentThread.ManagedThreadId);
        }

        public async Task EatMealAsync()
        {
            var t1 = PrepareRiceAsync();
            var t2 = PrepareMeatAsync();
            var t3 = PrepareSoupAsync();
            var t4 = GetBowlAsync();
            var t5 = GetChopsticksAsync();

            await Task.WhenAll(t1, t2, t3, t4, t5);

            //await t1;
            //await t2;
            //await t3;
            //await t4;
            //await t5;

            ShowThreadInformation("EatMealAsync");

            Console.WriteLine("Meal is ready. Let's eat!");
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