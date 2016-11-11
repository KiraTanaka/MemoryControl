using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryControl
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer();

            using (timer.StartTimer())
            {
                // do things
            }
            
            Console.WriteLine(timer.ElapsedMilliseconds);
        }
    }
}
