using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MiscUtil.Collections.Extensions;

namespace ExtensionMethodPatterns
{//ExtensionMethods.Patterns
    public static class ExtensionMethods
    {
        // name shortening wrapper
        public static StringBuilder al(this StringBuilder sb, string text)
        {
            return sb.AppendLine(text);
        }

        // combined extension method
        // does two or more things in one
        public static StringBuilder AppendFormatLine(
          this StringBuilder sb, string format, params object[] args)
        {
            return sb.AppendFormat(format, args).AppendLine();
        }

        // composite extension method: pairwise operation on elements
        public static ulong Xor(params ulong[] values)
        {
            ulong first = values[0];
            foreach (var x in values.Skip(1))
                first ^= x;
            return first;
        }

        // params extension method
        // improves API usability
        public static void AddRange<T>(this IList<T> list, params T[] objects)
        {
            foreach (T obj in objects)
                list.Add(obj);
        }

        // antistatic extension method
        // moving a static member into an extension
        public static string f(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        // factory extension methods
        public static DateTime June(this int day, int year)
        {
            return new DateTime(year, 6, day);
        }
    }

    public class Demo
    {
        public static void Main(string[] args)
        {
            var items = new List<int>();
            items.AddRange(1, 2, 3);

            var name = "John";
            var greeting = "My name is {0}".f(name);

            var notToday = 10.June(2020);

            var ulongArr = new ulong[] { 1, 2, 3, 4 };
          var result=  ExtensionMethods.Xor(ulongArr);
            Console.WriteLine(result);


        }
    }
}
