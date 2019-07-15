using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!111");
            GetTaskAsync().EmptyTask();
            Console.WriteLine("Hello World!222");
            Console.ReadKey();
        }

        public static async Task<string> GetTaskAsync()
        {
            try
            {
                await Task.Yield();


                Console.WriteLine("Hello World!333");

                //Task.Run(() =>
                //{
                //    throw new Exception("no await");
                //});

                return await Task.Run(() =>
                {
                    //throw new Exception("await");
                    return string.Empty;
                });

                //return Task.Factory.StartNew(() =>
                //{
                //    throw new Exception("Result");
                //    return string.Empty;
                //}).Result;


            }
            catch (Exception ex)
            {
                var exMsg = ex.Message;
                return null;
            }
        }

      
    }

    public static class TaskEmpty
    {
        public static void EmptyTask(this Task<string> ts)
        {

        }
    }
}
