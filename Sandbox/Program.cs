using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ninject;
using Ninject.Selection;

namespace Sandbox
{
   
    class Program
    {
        static ReaderWriterLockSlim locker = new ReaderWriterLockSlim();
        static List<int> list = new List<int>() { 1, 2, 3 };
        static readonly SemaphoreSlim _lockerSlim = new SemaphoreSlim(1, 1);

        static void Main(string[] args)
        {

            Task.Run(() => Read());
            Task.Run(() => Write());

            Thread.Sleep(100000);
        }

        static async Task Read()
        {
            Console.WriteLine("Try lock on read");
            await _lockerSlim.WaitAsync();
            Console.WriteLine("Lock on read");
            try
            {               
                foreach(var item in list)
                {
                    Console.Write(item + ", ");
                }
                Console.WriteLine();
            }
            finally
            {
                Console.WriteLine("Close lock on read");
                _lockerSlim.Release();
            }
        }

        static async Task Write()
        {
            Console.WriteLine("Try lock on write");
            await _lockerSlim.WaitAsync();
            Console.WriteLine("Lock on write");

            try
            {
                list.Add(4);
                list.Add(5);
                list.Add(6);
                list.Add(7);
                list.Add(8);
                Thread.Sleep(2000);
            }
            finally
            {
                Console.WriteLine("Close lock on write");
                _lockerSlim.Release();
            }
        }

    }
}