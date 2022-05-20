using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Threading;

namespace ExtensionMethod
{//General
    public class Foo
    {
        public string Name => "Foo";
    }

    public class FooDerived : Foo
    {
        public string Name => "FooDerived";
    }

    public class Person
    {
        public string Name;
        public int Age;

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, " +
                   $"{nameof(Age)}: {Age}";
        }
    }

    public static class ExtensionMethods
    {//    ↑↑↑↑↑↑ must be static

        // extension on your own type
        public static int Measure(this Foo foo)
        { //   ↑↑↑↑↑↑  
            return foo.Name.Length;
        }

        // extension method on an existing type (incl. primitive type)
        public static string ToBinary(this int n)
        {
            return Convert.ToString(n, 2);
        }

        // extension on an interface
        public static void Save(this ISerializable serializable)
        {
            // 
        }

        // you don't get extension method polymorphism
        public static int Measure(this FooDerived derived)
        {
            return 42;
        }

        // it doesn't work as an override
        public static string ToString(this Foo foo)
        {
            return "test";
        }

        // extension methods on value tuples
        public static Person ToPerson(this (string name, int age) data)
        {
            return new Person { Name = data.name, Age = data.age };
        }

        // extension on a generic type
        public static int Measure<T, U>(this Tuple<T, U> t)
        {
            return t.Item2.ToString().Length;
        }

        // extension on a delegate
        public static Stopwatch Measure(this Func<int> action)
        {
            var st = new Stopwatch();
            st.Start();
            action();
            st.Stop();
            return st;
        }

    }

    public class Demo
    {
        public static void Main_(string[] args)
        {
            var foo = new Foo();
            Console.WriteLine(foo.Measure());

            Console.WriteLine(foo);
            Console.WriteLine(ExtensionMethods.ToString(foo));

            var derived = new FooDerived();
            Foo parent = derived;
            Console.WriteLine("As parent: " + parent.Measure());
            Console.WriteLine("As child:  " + derived.Measure());

            Console.WriteLine(42.ToBinary());

            Person p = ("Dmitri", 22).ToPerson();
            Console.WriteLine(p);

            Console.WriteLine(Tuple.Create(12, "hello").Measure());

            Func<int> calculate = delegate
            {
                Thread.Sleep(1000);
                return 42;
            };
            var st = calculate.Measure();
            Console.WriteLine($"took {st.ElapsedMilliseconds}msec");
        }

    }
}