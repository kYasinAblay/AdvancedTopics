using System;
using System.Reflection;
using System.Text;
using Microsoft.CSharp.RuntimeBinder;
using System.Dynamic;
using System.Collections.Generic;

namespace ExpandoObjectApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            dynamic person = new ExpandoObject();
            person.FirstName = "John";
            person.Age = 22;
            Console.WriteLine($"{person.FirstName} is {person.Age} years old");

            person.Address = new ExpandoObject();
            person.Address.City = "London";
            person.Address.Country = "UK";

            person.SayHello = new Action(() => { Console.WriteLine("Hello!"); });
            person.SayHello();

            person.FallsIll = null;
            person.FallsIll = new EventHandler<dynamic>((sender, args) =>
              {
                  Console.WriteLine($"We need a doctor for {args}");
              });

            EventHandler<dynamic> e = person.FallsIll;
            e?.Invoke(person, person.FirstName);

            var dict = (IDictionary<string, object>)person;
            Console.WriteLine(dict.ContainsKey("FirstName"));
            Console.WriteLine(dict.ContainsKey("LastName"));

            dict["LastName"] = "Smith";
            Console.WriteLine(person.LastName);
        }
    }
}
