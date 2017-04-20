using System;
using System.IO;
using System.Threading.Tasks;

namespace MasterCSharpSkill
{
    class AsyncProgramming
    {
        static void Main(string[] args)
        {
            CallAsyncMethod().Wait();
        }

        private static async Task CallAsyncMethod()
        {
            Task<int> dispale = DisplayInformation();
            //Task.Run(() => DisplayInformation());
            Console.WriteLine("-------------------");
            //await dispale;
            Console.ReadLine();
        }

        private static async Task<int> DisplayInformation()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"My number is : {i}");
                //System.Threading.Thread.Sleep(1000);
                await Task.Delay(1000);

            }
            return 0;

        }

        private static async Task<int> HandleFileAsync()
        {
            Console.WriteLine("HandleFile enter");
            int count = 0;

            // Read in the specified file.
            // ... Use async StreamReader method.
            using (StreamReader reader = new StreamReader("D:\\out.doc"))
            {
                string v = await reader.ReadToEndAsync();

                // ... Process the file data somehow.
                count += v.Length;

                // ... A slow-running computation.
                //     Dummy code.
                for (int i = 0; i < 10000; i++)
                {
                    int x = v.GetHashCode();
                    if (x == 0)
                    {
                        count--;
                    }
                }
            }
            Console.WriteLine("HandleFile exit");
            return count;
        }
    }
}
