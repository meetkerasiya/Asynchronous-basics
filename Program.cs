using System;
using System.Threading.Tasks;

    // These classes are intentionally empty for the purpose of this example. They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.
    internal class Bhakhri { }
    internal class Tea { }
    internal class Poha { }
    internal class Toast { }

    class Program
    {
        static void Main(string[] args)
        {
            Tea cup = PourTea();
            Console.WriteLine("Tea is ready");

            Poha poha = MakePoha();
            Console.WriteLine("Poha is ready");

            Bhakhri bhakhri = MakeBhakhri(2);
            Console.WriteLine("Bhakhri is ready");

            Toast toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");
            Console.WriteLine("Breakfast is ready!");
        }
    
        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static Bhakhri MakeBhakhri(int total)
        {
            Console.WriteLine($"create flour for {total} bhakhari");
            Task.Delay(3000).Wait();
            for (int bhakhri = 0; bhakhri < total; bhakhri++)
            {
                Task.Delay(3000).Wait();
                Console.WriteLine("Bhakhari-"+bhakhri+" created");
            }
            
            Console.WriteLine("Put Bhakhri on plate");

            return new Bhakhri();
        }

        private static Poha MakePoha()
        {
            Console.WriteLine("Adding water to poha");
            Task.Delay(3000).Wait();
            Console.WriteLine($"Poha vagharvya ");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put Poha on plate");

            return new Poha();
        }

        private static Tea PourTea()
        {
            Console.WriteLine("Pouring coffee");
            return new Tea();
        }
    }
