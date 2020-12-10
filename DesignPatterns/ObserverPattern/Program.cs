using System;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var publisher = new Publisher();
            var subscribers = new Subscriber[] {new Subscriber(), new Subscriber(), new Subscriber()};

            foreach (var subscriber in subscribers)
            {
                publisher.AddSubscriber(subscriber);
            }
            
            publisher.PostNewMessage("Secret message");
            
            
            /*
            
            foreach (var subscriber in subscribers)
            {
                subscriber.pollAndPrintMessage(publisher);
            }
            publisher.PostNewMessage("Secret message");
            foreach (var subscriber in subscribers)
            {
                subscriber.pollAndPrintMessage(publisher);
            }
            publisher.MarkMessageAsRead();
            foreach (var subscriber in subscribers)
            {
                subscriber.pollAndPrintMessage(publisher);
            }*/
        }
    }
}