using Soat.CleanCoders.DipKata.Interfaces;
using Soat.CleanCoders.DipKata.Main;
using System;

namespace Soat.CleanCoders.DipKata.Sender
{
    public class EmailSender : ISender
    {
        private void SendMail(string emailAddress, string message)
        {
            Console.Write($"To:{emailAddress}, Subject: Happy birthday!, Message: {message}");
        }

        public void Send(Friend friend, string message)
        {
            SendMail(friend.Email,message);
        }
    }
}
