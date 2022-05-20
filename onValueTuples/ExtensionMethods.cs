using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onValueTuples
{ //Extension methods on value tuples
    // 2 5 2001
    //new DateTime(2001,5,2);
    //var when = (2, 5, 2001).dmy();
    public static class ExtensionMethods
    {
        public static DateTime dmy(this (int day, int month, int year) when)
        {
            return new(when.year, when.month, when.day);
        }

        public static List<T> merge<T>(this (IList<T> first, IList<T> second) lists)
        {
            var result = new List<T>();
            result.AddRange(lists.first);
            result.AddRange(lists.second);
            return result;
        }
    }
}
