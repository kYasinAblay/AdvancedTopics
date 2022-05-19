using System;
using System.Dynamic;

namespace DynamicObjectApp
{
    public class Widget : DynamicObject
    {
        public void WhatIsThis()
        {
            // Console.WriteLine(this.World);
            Console.WriteLine(This.World);
        }
        public dynamic This => this;
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = binder.Name;
            return true;
        }
        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            if (indexes.Length == 1)
            {
                //w[3]=>"***"
                result = new string('*', (int)indexes[0]);
                return true;
            }
            result = null;
            return false;
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //dynamic w = new Widget();
            var w = new Widget() as dynamic;
            Console.WriteLine(w.Hello);

            Console.WriteLine(w[7]);

            w.WhatIsThis();
        }
    }
}
