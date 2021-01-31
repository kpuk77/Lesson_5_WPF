using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add(Enumerable.Range(1, 5).Select(s=> "asd").ToString());
        }
    }
}
