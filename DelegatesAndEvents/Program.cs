using System;

namespace DelegatesAndEvents
{//Reflection
    public class Demo
    {
        public event EventHandler<int> MyEvent;

        public void Handler(object sender, int arg)
        {
            Console.WriteLine($"I just got {arg} from {sender?.GetType().Name}");
        }

        public static void Main_(string[] args)
        {
            var demo = new Demo();

            var eventInfo = typeof(Demo).GetEvent("MyEvent");
            var handlerMethod = demo.GetType().GetMethod("Handler");

            // we need a delegate of a particular type
            var handler = Delegate.CreateDelegate(
              eventInfo.EventHandlerType,
              null, // object that is the first argument of the method the delegate represents
              handlerMethod
            );
            eventInfo.AddEventHandler(demo, handler);

            demo.MyEvent?.Invoke(null, 312);
        }
    }
}
