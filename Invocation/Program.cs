using System;

namespace Invocation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "abracadabra   ";
            var t = typeof(string);
            Console.WriteLine(t);
            // [System.String]

            var trimMethod = t.GetMethod("Trim", Array.Empty<Type>());
            Console.WriteLine(trimMethod);
            // [System.String Trim()]

            var result = trimMethod.Invoke(s, Array.Empty<object>());
            Console.WriteLine(result);
            // "abracadabra"

            // bool int.TryParse(str, out int n)
            var numberString = "123";
            var parseMethod = typeof(int).GetMethod("TryParse",
               new[] { typeof(string), typeof(int).MakeByRefType() });

            Console.WriteLine(parseMethod);
            // [Boolean TryParse(System.String, Int32 ByRef)]

            object[] argsM = { numberString, null };
            var ok = parseMethod.Invoke(null, argsM);
            Console.WriteLine(ok);
            // true

            Console.WriteLine(argsM[1]);
            // 123

            var at = typeof(Activator);
            var method = at.GetMethod("CreateInstance", Array.Empty<Type>());
            Console.WriteLine(method);
            // [T CreateInstance[T]()]

            var ciGeneric = method.MakeGenericMethod(typeof(Guid));
            Console.WriteLine(ciGeneric);
            // [System.Guid CreateInstance[Guid]()]

            var guid = ciGeneric.Invoke(null, null);
            Console.WriteLine(guid);
            // [00000000-0000-0000-0000-000000000000]


        }
    }
}
