using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson4
{
    internal class Counter
    {
        public delegate void Count77();
        public event Count77 Ready77;
        public void Count100()
        {
            for (int i = 1; i <= 100; i++)
            {
                //Console.WriteLine(i);
                if (i == 77)
                {
                    Ready77?.Invoke();
                }
            }
        }

    }
}
