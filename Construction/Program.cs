using System;

namespace Construction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = typeof(bool);
            var b = Activator.CreateInstance(t);
            Console.WriteLine(b);
            // false

            var b2 = Activator.CreateInstance<bool>();
            Console.WriteLine(b2);
            // false

            var wc = Activator.CreateInstance("System", "System.Timers.Timer");
            Console.WriteLine(wc);
            // ObjectHandle { }

            wc.Unwrap();
            // [System.Timers.Timer]

            var alType = Type.GetType("System.Collections.ArrayList");
            Console.WriteLine(alType);
            // [System.Collections.ArrayList]

            var alCtor = alType.GetConstructor(Array.Empty<Type>());
            Console.WriteLine(alCtor);
            // [Void .ctor()]

            var al = alCtor.Invoke(Array.Empty<object>());
            Console.WriteLine(al);
            // ArrayList(0) { }

            var st = typeof(string);
            var ctor = st.GetConstructor(new[] { typeof(char[]) });
            Console.WriteLine(ctor);
            // [Void .ctor(Char[])]

            var str = ctor.Invoke(new object[]
              {
                new[] { 't', 'e', 's', 't' }
                 });
            Console.WriteLine(str);
            // "test"

            //var listType = Type.GetType("System.Collection.Generic.List`1");
            //Console.WriteLine(listType);//yanlış yazım olabilir- *açıktı kapattım
            var listType = Type.GetType("System.Collections.Generic.List`1");
            Console.WriteLine(listType);
            // [System.Collections.Generic.List`1[T]]

            var listOfIntType = listType.MakeGenericType(typeof(int));
            Console.WriteLine(listOfIntType);
            // [System.Collections.Generic.List`1[System.Int32]]

            var listOfIntCtor = listOfIntType.GetConstructor(Array.Empty<Type>());
            Console.WriteLine(listOfIntCtor);
            // [Void .ctor()]

            var theList = listOfIntCtor.Invoke(Array.Empty<object>());
            Console.WriteLine(theList);
            // List<int>(0) { }

            var charType = typeof(char);
            Array.CreateInstance(charType, 10);
            // char[10] { '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0' }

            var charArrayType = charType.MakeArrayType();
            Console.WriteLine(charArrayType);
            // [System.Char[]]

            Console.WriteLine(charArrayType.FullName);
            // "System.Char[]"

            var charArrayCtor = charArrayType.GetConstructor(new[] { typeof(int) });
            Console.WriteLine(charArrayCtor);
            // [Void .ctor(Int32)]

            var arr = charArrayCtor.Invoke(new object[] { 20 });
            Console.WriteLine(arr);
            // char[20] { '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0' }

            for (int i = 0; i < arr.Length; ++i)
                // *   arr[i] = (char)('A' + i);

                new string(arr);
            Console.WriteLine(arr);
            // char[20] { '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0' }

            arr.GetType().Name;
            // "Char[]"

            char[] arr2 = (char[])arr;
            arr2
            // char[20] { '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0' }

            arr2[1] = 'Z';
            Console.WriteLine(arr2);
            // char[20] { '\0', 'Z', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0', '\0' }


        }
    }
}
