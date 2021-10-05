using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample01
{
    class HelperMethods
    {
        public static void Print(string output, int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.WriteLine(output);
        }

        public static void Pause(string output)
        {
            Console.WriteLine(output);
            Console.ReadKey();
        }


    }
}
