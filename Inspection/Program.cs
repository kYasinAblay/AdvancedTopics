using System;

namespace Inspection
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var t = typeof(Guid);
            Console.WriteLine(t.FullName);
            // "System.Guid"

            Console.WriteLine(t.Name);
            // "Guid"

            var ctors = t.GetConstructors();
            Console.WriteLine(ctors);
            // ConstructorInfo[6] { [Void .ctor(Byte[])], [Void .ctor(System.ReadOnlySpan`1[System.Byte])], [Void .ctor(UInt32, UInt16, UInt16, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte)], [Void .ctor(Int32, Int16, Int16, Byte[])], [Void .ctor(Int32, Int16, Int16, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte)], [Void .ctor(System.String)] }

            foreach (var ctor in ctors)
            {
                // * {

                // *   Console.WriteLine(" - Guid(");
                // *   var pars = ctor.GetParameters();
                // *   for (var i = 0; i < pars.Length; ++i)
                // *   {
                // *     var par = pars[i];
                // *     Console.Write($"{par.ParameterType.Name} {par.Name}");
                // *     if (i+1 != pars.Length) Console.Write(",");
                // *   }
                // *   Console.WriteLine(")");
                // * }
                //  - Guid(
                // Byte[] b)
                //  - Guid(
                // ReadOnlySpan`1 b)
                //  - Guid(
                // UInt32 a,UInt16 b,UInt16 c,Byte d,Byte e,Byte f,Byte g,Byte h,Byte i,Byte j,Byte k)
                //  - Guid(
                // Int32 a,Int16 b,Int16 c,Byte[] d)
                //  - Guid(
                // Int32 a,Int16 b,Int16 c,Byte d,Byte e,Byte f,Byte g,Byte h,Byte i,Byte j,Byte k)
                //  - Guid(
                // String g)
                // * }

            }
            var methods = t.GetMethods();
            Console.WriteLine(methods);
            // MethodInfo[23] { [System.Guid Parse(System.String)], [System.Guid Parse(System.ReadOnlySpan`1[System.Char])], [Boolean TryParse(System.String, System.Guid ByRef)], [Boolean TryParse(System.ReadOnlySpan`1[System.Char], System.Guid ByRef)], [System.Guid ParseExact(System.String, System.String)], [System.Guid ParseExact(System.ReadOnlySpan`1[System.Char], System.ReadOnlySpan`1[System.Char])], [Boolean TryParseExact(System.String, System.String, System.Guid ByRef)], [Boolean TryParseExact(System.ReadOnlySpan`1[System.Char], System.ReadOnlySpan`1[System.Char], System.Guid ByRef)], [Byte[] ToByteArray()], [Boolean TryWriteBytes(System.Span`1[System.Byte])], [System.String ToString()], [Int32 GetHashCode()], [Boolean Equals(System.Object)], [Boolean Equals(System.Guid)], [Int32 CompareTo(System.Object)], [Int32 CompareTo(System.Guid)], [Boolean op_Equality(System.Guid, System.Guid)], [Boolean op_Inequality(System.Guid, System.Guid)], [System.String ToString(System.String)], [System.String ToString(System.String, Sys...

            foreach (var method in methods)
                // * {

                // *   Console.WriteLine(method.Name);
                // * }
                // Parse
                // Parse
                // TryParse
                // TryParse
                // ParseExact
                // ParseExact
                // TryParseExact
                // TryParseExact
                // ToByteArray
                // TryWriteBytes
                // ToString
                // GetHashCode
                // Equals
                // Equals
                // CompareTo
                // CompareTo
                // op_Equality
                // op_Inequality
                // ToString
                // ToString
                // TryFormat
                // NewGuid
                // GetType
                t.GetProperties();
            // PropertyInfo[0] { }

            t.GetEvents();
            // EventInfo[0] { }


        }
    }
}
