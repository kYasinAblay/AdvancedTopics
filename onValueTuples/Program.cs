using System;
using System.Collections.Generic;

namespace onValueTuples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var when = (2, 5, 2001).dmy();
            Console.WriteLine(when);

            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<int> { 3, 2, 1 };

            var merged = (list1, list2).merge(); 
        }
    }
}
