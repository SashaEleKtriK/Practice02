using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class TickCounter
    {
        private DateTime end_time;
        private DateTime start_time;
        public TickCounter() { }
        public void Start()
        {
            start_time = DateTime.Now;
            
        }
        public void Stop()
        {
            end_time = DateTime.Now; 
        }
        public TimeSpan GetTime()

        {

            TimeSpan result = end_time - start_time;
            return result;
            
        }
    }
}
