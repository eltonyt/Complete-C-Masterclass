using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*            Console.WriteLine("Hello 1");
                        Thread.Sleep(1000);
                        Console.WriteLine("Hello 2");
                        Console.WriteLine("Hello 3");
                        Console.WriteLine("Hello 4");
                        Console.WriteLine("Hello 5");

                        new Thread(() =>
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("Thread 1");
                        }).Start();
                        new Thread(() =>
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("Thread 2");
                        }).Start();
                        new Thread(() =>
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("Thread 3");
                        }).Start();
                        new Thread(() =>
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("Thread 4");
                        }).Start();
                        new Thread(() =>
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("Thread 5");
                        }).Start();
                        Console.ReadLine();*/

            /*Enumerable.Range(0, 1000).ToList().ForEach(x =>
            {
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} started");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} ended");
                });
            });
            Console.ReadLine();*/
        }
    }
}
