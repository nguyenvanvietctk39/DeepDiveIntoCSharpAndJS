namespace ConsoleApp1
{
    public class Demo2
    {
        public async Task Task1()
        {
            Console.WriteLine("Task1");
            await Task.Delay(1009);
            ShowThreadInformation("Task1");
            Console.WriteLine("Task1 is ready!");
        }

        public async Task Task2()
        {
            Console.WriteLine("Task2");
            await Task.Delay(1000);
            ShowThreadInformation("Task2");
            Console.WriteLine("Task2 is ready!");
        }

        public async Task Task3()
        {
            Console.WriteLine("Task3");
            await Task.Delay(1000);
            ShowThreadInformation("Task3");
            Console.WriteLine("Task3 is ready!");
        }

        public async Task Run()
        {
            var t1 = Task1();
            var t2 = Task2();
            var t3 = Task3();

            await Task.WhenAll(t1, t2, t3);

            Console.WriteLine("Completed!!!");
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