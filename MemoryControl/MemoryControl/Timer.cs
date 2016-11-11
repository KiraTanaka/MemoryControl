using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MemoryControl
{
    public class Timer: Stopwatch, IDisposable
    {
        public Timer StartTimer()
        {
            Start();
            return this;
        }
        public void Dispose()
        {
            Stop();
        }
    }
}
