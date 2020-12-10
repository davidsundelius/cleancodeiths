using System;

namespace ObserverPattern
{
    public class Subscriber
    {
        public void Notify(string message)
        {
            Console.WriteLine(message);
        }
        /*public void pollAndPrintMessage(Publisher publisher)
        {
            if (publisher.hasNewMessage())
            {
                Console.WriteLine(publisher.pollMessage());
            }
            else
            {
                Console.WriteLine("No new messages");
            }
        }*/
    }
}