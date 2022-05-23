using System;
using System.Runtime.InteropServices;

namespace SpanT_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            unsafe
            {
                byte* ptr = stackalloc byte[100];
                Span<byte> memory = new Span<byte>(ptr, 100);

                IntPtr unmanagePtr = Marshal.AllocHGlobal(123);
                Span<byte> unmanagedMemory = new Span<byte>(unmanagePtr.ToPointer(), 123);
                Marshal.FreeHGlobal(unmanagePtr);
            }
            char[] stuff = "hello".ToCharArray();
            Span<char> arrayMemory = stuff;

            ReadOnlySpan<char> more = "hi there!".AsSpan();

            Console.WriteLine($"Our span has {more.Length} elements");

            arrayMemory.Fill('x');
            Console.WriteLine(stuff);
            arrayMemory.Clear();
            Console.WriteLine(stuff);
        }
    }
}
