using Soat.CleanCoders.DipKata.Main;
using Soat.CleanCoders.DipKata.Main.Interfaces;
using System;

namespace Soat.CleanCoders.DipKata.Sender
{
    public class SmsSender : ISender
    {
        private void SendSMS(string message)
        {
            Console.Write("SMS: " + message);
        }

        public void Send(Friend friend, string message)
        {
            SendSMS(message);
        }
    }
}
