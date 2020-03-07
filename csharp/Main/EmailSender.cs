using System;

namespace Soat.CleanCoders.DipKata.Main
{
    public class EmailSender
    {
        public void Send(string emailAddress, string message)
        {
            Console.Write($"To:{emailAddress}, Subject: Happy birthday!, Message: {message}");
        }
    }
}
