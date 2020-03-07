using Soat.CleanCoders.DipKata.Main;
using System;

namespace Soat.CleanCoders.DipKata.Sender
{
    public class EmailSender : ISender
    {
        private string _emailAddress;

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
