using System;

namespace Soat.CleanCoders.DipKata.Main
{
    public class EmailSender
    {
        private string _emailAddress ;

        public void Send(string message)
        {
            Send(_emailAddress, message);
        }

        public void Send(string emailAddress, string message)
        {
            Console.Write($"To:{emailAddress}, Subject: Happy birthday!, Message: {message}");
        }
    }
}
