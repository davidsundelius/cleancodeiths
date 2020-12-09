namespace ObserverPattern
{
    public class Publisher
    {
        private string message;

        public void PostNewMessage(string message)
        {
            this.message = message;
        }

        public void MarkMessageAsRead()
        {
            message = null;
        }
        
        public bool hasNewMessage()
        {
            return message != null;
        }

        public string pollMessage()
        {
            return message;
        }
    }
}