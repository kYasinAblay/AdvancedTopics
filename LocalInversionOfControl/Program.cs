using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalInversionOfControl
{
    public static class ExtensionMethods
    {
        public static T AddTo<T>(this T self, ICollection<T> collection)
        {
            collection.Add(self);
            return self;
        }

        public static bool HasSome<TSubject, T>(this TSubject subject,
          Func<TSubject, IEnumerable<T>> propertyToCheck)
        {
            return propertyToCheck(subject).Any();
        }
        public static bool HasNo<TSubject, T>(this TSubject subject,
          Func<TSubject, IEnumerable<T>> propertyToCheck)
        {
            return !HasSome(subject, propertyToCheck);
        }

        public static bool IsOneOf<T>(this T self, params T[] options)
        {
            return options.Contains(self);
        }
    }

    public class MyClass
    {
        public List<int> Values;
    }

    class LocalInversionOfControl
    {
        static void Main_(string[] args)
        {
            // typical container
            var list = new List<int>();
            list.Add(123);
            list.AddRange(new[] { 1, 2, 3 });

            // inverted
            var list2 = new List<int>();
            2.AddTo(list).AddTo(list2);

            var myclass = new MyClass();
            if (myclass.Values.Count == 0) { }
            if (!myclass.Values.Any()) { }

            if (myclass.HasSome(x => x.Values)) { }
            if (myclass.HasNo(x => x.Values)) { }

            string op = "OR";

            if (op == "AND" || op == "OR" || op == "XOR") { }
            if (op.IsOneOf("AND", "OR", "XOR")) { }
        }
    }
}
