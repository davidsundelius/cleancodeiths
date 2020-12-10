using System.Collections.Generic;

namespace ObserverPattern
{
    public class Publisher
    {
        //private string message;
        private List<Subscriber> subscribers = new List<Subscriber>();

        public void PostNewMessage(string message)
        {
            //this.message = message;
            foreach (var subscriber in subscribers)
            {
                subscriber.Notify(message);
            }
        }

        /*public void MarkMessageAsRead()
        {
            message = null;
        }*/
        
        /*public bool hasNewMessage()
        {
            return message != null;
        }*/

        public void AddSubscriber(Subscriber subscriber)
        {
            subscribers.Add(subscriber);
        }
        
        /*public string pollMessage()
        {
            return message;
        }*/
    }
}