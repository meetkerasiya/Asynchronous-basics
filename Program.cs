using System;
using System.Diagnostics;
using System.Threading.Tasks;
namespace Asynchronousbasics
{
    // These classes are intentionally empty for the purpose of this example. They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.
    internal class Bhakhri { }
    internal class Tea { }
    internal class Poha { }
    internal class Toast { }

    class Nasto
    {
        static async Task Main(string[] args)
        {
            var watch = Stopwatch.StartNew(); //starts timer
            Tea cup = PourTea();
            Console.WriteLine("Tea is ready");

            Task<Poha> pohaTask = MakePohaAsync();
            Task<Bhakhri> bhakhriTask = MakeBhakhriAsync(2);
            Task<Toast> toastTask = ToastWithButterAndJamAsync(2);

            var nastoTask = new List<Task> { pohaTask, bhakhriTask, toastTask };
            while (nastoTask.Count > 0)
            {
                Task completedTask=await Task.WhenAny(nastoTask);
                if(completedTask==pohaTask)
                {
                    Console.WriteLine("Poha is ready");

                }
                else if(completedTask==bhakhriTask)
                {
                    Console.WriteLine("Bhakhri is ready");
                }
                else if(completedTask==toastTask)
                {
                    Console.WriteLine("toast is ready");
                }
                await completedTask;
                nastoTask.Remove(completedTask);
            }
            Console.WriteLine("Breakfast is ready!");
            watch.Stop();
            Console.WriteLine("Time took to make breakfast: " + watch.Elapsed);
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        static async Task<Toast> ToastWithButterAndJamAsync(int number)
        {
            var toast = await MakeToastAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);
            return toast;
        }
        private static async Task<Toast> MakeToastAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            //Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bhakhri> MakeBhakhriAsync(int total)
        {
            Console.WriteLine($"create flour for {total} bhakhari");
            //Task.Delay(3000).Wait();
            await Task.Delay(3000);
            for (int bhakhri = 1; bhakhri <= total; bhakhri++)
            {
                Task.Delay(3000).Wait();
                Console.WriteLine("Bhakhari-" + bhakhri + " created");
            }

            Console.WriteLine("Put Bhakhri on plate");

            return new Bhakhri();
        }

        private static async Task<Poha> MakePohaAsync()
        {
            Console.WriteLine("Adding water to poha");
            //Task.Delay(3000).Wait();
            await Task.Delay(3000);

            Console.WriteLine($"Poha vagharvya ");
            await Task.Delay(3000);
            Console.WriteLine("Put Poha on plate");

            return new Poha();
        }

        private static Tea PourTea()
        {
            Console.WriteLine("Pouring coffee");
            return new Tea();
        }
    }
}